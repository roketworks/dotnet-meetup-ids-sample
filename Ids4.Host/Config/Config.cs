using System;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Ids4.Host {
    internal static class Config {
        internal static IEnumerable<IdentityResource> GetIdentityResources () => new List<IdentityResource> {
            // some standard scopes from the OIDC spec
            new IdentityResources.OpenId (),
            new IdentityResources.Profile (),
            new IdentityResources.Email ()
        };

        internal static IEnumerable<ApiResource> GetApiResources () => new List<ApiResource> {
            new ApiResource ("sample.api", new [] { JwtClaimTypes.Name, JwtClaimTypes.Email })
        };

        internal static IEnumerable<Client> GetClients () => new List<Client> {
            new Client {
            ClientId = ""
            }
        };
    }
}