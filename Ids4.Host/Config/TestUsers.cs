using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Test;

namespace Ids4.Host.Controllers
{
    internal class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser> 
        {
            new TestUser 
            {
                SubjectId = "1",
                Username = "brian.lafeve",
                Password = "Th3G0ldenG0d!",
                Claims = new List<Claim> 
                {
                    new Claim("role", "manager"),
                    new Claim("email", "brian.lafeve@attwater.com"),
                    new Claim("first_name", "Brian"),
                    new Claim("last_name", "LaFeve")
                }
            }
        };
    }
}