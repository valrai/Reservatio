using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Reservatio.Data.Dto;
using Reservatio.Models;
using Reservatio.Models.Exceptions;

namespace Reservatio.Services.User
{
    public class UserService : IUserService
    {
        private FirebaseAuth FirebaseAdmin => FirebaseAuth.DefaultInstance;

        public UserService()
        {
            if (FirebaseApp.DefaultInstance != null) return;

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/serviceAccountKey.json"),
            });
        }

        private async Task<FirebaseToken> GetRequestTokenAsync(HttpRequest request)
        {
            var token = request.Headers[HeaderNames.Authorization].FirstOrDefault();
            return await FirebaseAdmin.VerifyIdTokenAsync(token?.Split(" ")[1]);
        }

        private async Task<bool> EmailAlreadyRegister(string email)
        {
            try
            {
                var user = await FirebaseAdmin.GetUserByEmailAsync(email);
                return user != null;
            }
            catch (FirebaseAuthException)
            {
                return false;
            }
        }

        public async Task<string> GetCurrentUserIdAsync(HttpRequest request)
        {
            var token = await GetRequestTokenAsync(request);
            return token.Uid;
        }

        public async Task<UserRecord> GetCurrentUserAsync(HttpRequest request)
        {
            var userId = await GetCurrentUserIdAsync(request);
            return await FirebaseAdmin.GetUserAsync(userId);
        }

        public async Task<string> RegisterUserAsync(AddOrUpdateNaturalPersonDto person, RoleType role)
        {
            if (await EmailAlreadyRegister(person.Email))
                throw new EmailAlreadyRegisteredException();

            var user = await FirebaseAdmin.CreateUserAsync(new UserRecordArgs()
            {
                Email = person.Email,
                Password = person.Password,
                DisplayName = person.Name,
                PhoneNumber = person.Phone,
            });

            var claims = new Dictionary<string, object>()
            {
                { role.ToString(), true }
            };

            await FirebaseAdmin.SetCustomUserClaimsAsync(user.Uid, claims);

            return user.Uid;
        }

        public async Task DeleteUserAsync(string userId)
        {
            await FirebaseAdmin.DeleteUserAsync(userId);
        }

        public async Task SetUserRoles(string userId, params RoleType[] roles)
        {
            var claims = roles.ToDictionary<RoleType, string, object>(role => role.ToString(), role => true);
            await FirebaseAdmin.SetCustomUserClaimsAsync(userId, claims);
        }
    }
}
