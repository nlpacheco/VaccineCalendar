using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using VaccineCalendar.Models;

namespace VaccineCalendar.Services.Identity
{
    class IIdentity
    {
        public interface IIdentityService
        {
            string CreateAuthorizationRequest();
            string CreateLogoutRequest(string token);
            Task<UserToken> GetTokenAsync(string code);
        }
    }
}
