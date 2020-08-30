using System;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Reservatio.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly FirebaseAuth _firebaseAdmin;

        public BaseController()
        {
            if (FirebaseApp.DefaultInstance != null) return;

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/serviceAccountKey.json"),
            });

            this._firebaseAdmin = FirebaseAuth.DefaultInstance;
        }

        private async Task<FirebaseToken> GetRequestToken()
        {
            var token = Request.Headers[HeaderNames.Authorization].FirstOrDefault();
            return await _firebaseAdmin.VerifyIdTokenAsync(token?.Split(" ")[1]);
        }

        protected async Task<string> GetCurrentUserId()
        {
            var token = await GetRequestToken();
            return token.Uid;
        }

        protected async Task<UserRecord> GetCurrentUser()
        {
            var userId = await GetCurrentUserId();
            return await _firebaseAdmin.GetUserAsync(userId);
        }
    }
}
