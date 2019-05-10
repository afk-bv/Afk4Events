using System;
using System.Linq;
using System.Threading.Tasks;
using Afk4Events.Data;
using Afk4Events.Data.Entities.Users;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Afk4Events.Service.Authentications
{
    /// <summary>
    /// Facilitates the Authorization Code Flow of OpenID Connect
    /// https://openid.net/specs/openid-connect-core-1_0.html#CodeFlowSteps
    /// </summary>
    public class AuthenticationService: IAuthenticationService
    {
        private readonly Afk4EventsContext _db;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly OidcOptions _oidcOptions;

        public AuthenticationService(Afk4EventsContext db, IMemoryCache memoryCache, ILogger<AuthenticationService> logger, 
            IOptions<OidcOptions> oidcOptions)
        {
            _db = db;
            _memoryCache = memoryCache;
            _logger = logger;
            _oidcOptions = oidcOptions.Value;
        }

        private OidcClient GetOidcClient(string redirectUrl)
        {
            var client = new OidcClient(new OidcClientOptions()
            {
                Authority = _oidcOptions.Authority,
                ClientId = _oidcOptions.ClientId,
                ClientSecret = _oidcOptions.Secret,
                RedirectUri = redirectUrl,
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect,
                Flow = OidcClientOptions.AuthenticationFlow.AuthorizationCode,
                Scope = "email profile"
            });

            // Fucking Google not sticking to protocol.
            client.Options.Policy.Discovery.ValidateEndpoints = false;
            client.Options.Policy.RequireAccessTokenHash = false;
            return client;
        }

        public async Task<AuthorizeState> StartOidcLogin(string redirectUrl, bool prompt = false)
        {
            var client = GetOidcClient(redirectUrl);
            // Prepares an Authentication Request containing the desired request parameters.
            var authorizeState = await client.PrepareLoginAsync(new { prompt });
            // Stores the request parameters for validation upon callback
            _memoryCache.Set(authorizeState.State, authorizeState);
            return authorizeState;
        }

        public async Task<User> FinishOidcLogin(string code, string stateKey, string redirectUrl)
        {
            var client = GetOidcClient(redirectUrl);
            // retrieves the request validation parameters (nonce etc).
            var state = _memoryCache.Get<AuthorizeState>(stateKey);
            if (state == default(AuthorizeState))
            {
                throw new ArgumentException("Authorization state not found or expired", nameof(stateKey));
            }

            // Validate the Id token provided in the callback Url from the authorization authority.
            var result = await client.ProcessResponseAsync(redirectUrl, state);
            if (result.IsError)
            {
                _logger.LogError("Oidc login failure: " + result.Error);
                return default;
            }

            // Get relevant claims from the Id token
            var googleSid = result.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var name = result.User.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
            var picture = result.User.Claims.FirstOrDefault(x => x.Type == "picture")?.Value;
            var email = result.User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            if (googleSid == default || name == default || picture == default || email == default)
            {
                throw new Exception("Missing claim"); // MissingClaimException ?
            }

            // Use unique Id to check whether this user is already created locally.
            var user = _db.Users.FirstOrDefault(x => x.GoogleId == googleSid);
            if (user == default)
            {
                user = new User(googleSid);
                await _db.Users.AddAsync(user);
            }

            // Set or update local user.
            user.ProfilePictureUrl = picture;
            user.Name = name;
            user.Email = email;
            await _db.SaveChangesAsync();

            return user;
        }

    }
}
