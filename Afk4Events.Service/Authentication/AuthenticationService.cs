using System;
using System.Threading.Tasks;
using Afk4Events.Data;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Afk4Events.Service.Authentication
{

    public interface IAuthenticationService
    {
        Task<AuthorizeState> StartOidcLogin(string redirectUrl, bool prompt = false);
        Task<string> FinishOidcLogin(string code, string stateKey, string redirectUrl);
    }

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
                Scope = "email profile"
            });
            client.Options.Policy.Discovery.ValidateEndpoints = false;
            return client;
        }

        public async Task<AuthorizeState> StartOidcLogin(string redirectUrl, bool prompt = false)
        {
            var client = GetOidcClient(redirectUrl);
            var authorizeState = await client.PrepareLoginAsync(new { prompt });
            var oidcLoginKey = Guid.NewGuid().ToString();
            _memoryCache.Set(oidcLoginKey, authorizeState);
            return authorizeState;
        }

        public async Task<string> FinishOidcLogin(string code, string stateKey, string redirectUrl)
        {
            var client = GetOidcClient(redirectUrl);
            var state = _memoryCache.Get<AuthorizeState>(stateKey);
            if (state == default(AuthorizeState))
            {
                throw new ArgumentException("Authorization state not found or expired", nameof(stateKey));
            }

            var result = await client.ProcessResponseAsync(code, state);
            if (result.IsError)
            {
                _logger.LogError("Oidc login failure: " + result.Error);
                return null;
            }

            return "";
        }

    }
}
