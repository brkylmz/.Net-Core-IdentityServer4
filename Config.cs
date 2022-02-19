using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace _Net_Core_IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources =>
            new List<ApiResource>
            {
                new ApiResource("TestRemoteApi")
                {
                    Scopes = { "TestRemoteApi" }
                }
            };

        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> GetApiScopes =>
            new ApiScope[]
            {
                new ApiScope("TestRemoteApi")
            };

        public static IEnumerable<Client> GetClients =>
            new Client[]
            {

                new Client {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "TestRemoteApi" }
                },
                new Client
                {
                    ClientId = "client_id_js",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris = { "https://localhost:7085/home/signin" },
                    PostLogoutRedirectUris = { "https://localhost:7085" },
                    AllowedCorsOrigins = { "https://localhost:7085" },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "TestRemoteApi"
                    },
                    AccessTokenLifetime = 600,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "client_id_win_form",
                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "TestRemoteApi"
                    },
                    AccessTokenLifetime = 600,
                    AllowOfflineAccess = true,
                    AlwaysSendClientClaims = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                }
            };
    }
}