using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Reservatio.Data.Dto;
using Reservatio.Models;

namespace Reservatio.Services.User
{
    public interface IUserService
    {
        Task<string> GetCurrentUserIdAsync(HttpRequest request);
        Task<UserRecord> GetCurrentUserAsync(HttpRequest request);
        Task<string> RegisterUserAsync(AddOrupdateNaturalPersonDto person, RoleType role);
        Task DeleteUserAsync(string userId);
        Task SetUserRoles(string userId, params RoleType[] roles);
    }
}