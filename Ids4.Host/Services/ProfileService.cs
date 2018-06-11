using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace Ids4.Host.Services
{
    public class ProfileService : IProfileService
    {
        public ProfileService() 
        {

        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}