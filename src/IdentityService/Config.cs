using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("auctionApp", "auction app full access")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new ()
            {
            ClientId="postman",
            ClientName="Postman",
            AllowedScopes= {"openid","profile","auctionApp"},
            RedirectUris={"https://postman.com/callback"},
            ClientSecrets=new[]{new Secret("NotASecret".Sha256())},
            AllowedGrantTypes={GrantType.ResourceOwnerPassword}
            },
            new ()
            {
            ClientId="nextApp",
            ClientName="nextApp",
            AllowedScopes= {"openid","profile","auctionApp"},
            RedirectUris={"https://localhost:3000/api/auth/callback/id-server"},
            ClientSecrets=new[]{new Secret("secret".Sha256())},
            AllowedGrantTypes= GrantTypes.CodeAndClientCredentials,
            RequirePkce = false,
            AllowOfflineAccess = true,
            AccessTokenLifetime = 3600*24*30
            }

        };
}
