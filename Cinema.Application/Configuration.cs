using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Cinema.Application
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("CinemaWebAPI","Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("CinemaWebAPI","Web API", new []
                    { JwtClaimTypes.Name })
                {
                    Scopes = { "CinemaWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client()
                {
                    ClientId = "k-spot",
                    ClientName = "Cinema Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = { "http://localhost:3000/signin-oidc" },
                    AllowedCorsOrigins = { "http://localhost:3000" },
                    PostLogoutRedirectUris = { "http://localhost:3000/signout-oidc" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "CinemaWebAPI"
                    },
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false
                }
            };
    }
}
