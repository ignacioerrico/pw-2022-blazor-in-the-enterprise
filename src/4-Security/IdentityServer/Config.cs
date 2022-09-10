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
            }
        };
}
