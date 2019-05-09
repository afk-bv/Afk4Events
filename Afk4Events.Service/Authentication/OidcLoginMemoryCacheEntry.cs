using IdentityModel.OidcClient;

namespace Afk4Events.Service.Authentication
{
    public class OidcLoginMemoryCacheEntry
    {
        public string Email { get; set; }
        public string EmailClaim { get; set; }
        public string UserId { get; }
        public AuthorizeState AuthorizeState { get; set; }
        public OidcClientOptions OidcClientOptions { get; set; }

        public OidcLoginMemoryCacheEntry(string email, string emailClaim, string userId, AuthorizeState authorizeState, OidcClientOptions oidcClientOptions)
        {
            Email = email;
            EmailClaim = emailClaim;
            UserId = userId;
            AuthorizeState = authorizeState;
            OidcClientOptions = oidcClientOptions;
        }
    }
}