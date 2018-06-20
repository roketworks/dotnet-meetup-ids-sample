using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Ids4.Host.Config;

namespace Ids4.Host.Services
{
    // ProfileService is used when userinfo endpoint is being called
    // or tokens are being generated 
    public class ProfileService : IProfileService
    {
        private readonly TestUserStore _userStore; 

        public ProfileService(TestUserStore userStore = null) 
        {
            _userStore = userStore ?? new TestUserStore(TestUsers.Users);
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userStore.FindBySubjectId(context.Subject.GetSubjectId()); 
            context.IssuedClaims.AddRange(user.Claims);
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}