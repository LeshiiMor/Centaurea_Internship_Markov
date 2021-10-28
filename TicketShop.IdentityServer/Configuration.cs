using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>
            {
                new Client() // react client
                {
                    ClientId="client_react_id",
                    RequireClientSecret=false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent=false,
                    RequirePkce=true,
                    AllowedScopes=
                    {
                        "TicketShopAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = {"https://localhost:3000","https://localhost:3000/callback"},
                    PostLogoutRedirectUris ={ "https://localhost:3000" }
                },
                // new Client()
                //{
                //    ClientId="client_id_ticketshpo_api",
                //    ClientSecrets={ new Secret("client_secret_ticketshpo_api".ToSha256()) },
                //    AllowedGrantTypes = GrantTypes.Code,
                //    AllowedScopes=
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile
                //    },
                //    RedirectUris =
                //    {
                //        "https://localhost:44324/signin-oidc"
                //    },
                //    RequireConsent = false,

                //    //AlwaysIncludeUserClaimsInIdToken=true
                //}
            };
            return clients;
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var IdentityResources = new List<IdentityResource>
            {
                new IdentityResources.Profile(),
                new IdentityResources.OpenId()
            };
            return IdentityResources;
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            var apiScopes = new List<ApiScope>
            {
                new ApiScope("TicketShopAPI")
            };
            return apiScopes;
        }
    }
}
