using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new("talkmanagerapi", "Talk Manager API")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new()
            {
                ClientId = "talkmanagerblazorserver",
                ClientName = "Talk Manager Blazor Server",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireConsent = false,
                AllowOfflineAccess = true,
                AccessTokenLifetime = 30 * 60, // seconds (half an hour)
                ClientSecrets = { new("secret".Sha256()) },
                RedirectUris = { "https://localhost:7125/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:7125/signout-oidc" },
                AllowedScopes = { "openid", "profile", "email", "talkmanagerapi" }
            },
            new()
            {
                ClientId = "talkmanagerblazorwasm",
                ClientName = "Talk Manager Blazor WebAssembly",
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                RequireClientSecret = false, // We can't store secrets in the client
                RedirectUris = { "https://localhost:7230/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://localhost:7230/authentication/logout-callback" },
                AllowedScopes = { "openid", "profile", "email", "talkmanagerapi" },
                AllowedCorsOrigins = { "http://localhost:5229", "https://localhost:7230" }
            }
        };
}
