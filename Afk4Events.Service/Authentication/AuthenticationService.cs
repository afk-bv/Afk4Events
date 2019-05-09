using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Afk4Events.Data;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Afk4Events.Service.Authentication
{
    public class AuthenticationService
    {
         private readonly Afk4EventsContext _db;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly OidcOptions _oidcOptions;

        public AuthenticationService(Afk4EventsContext db, IMemoryCache memoryCache, ILogger<AuthenticationService> logger, IOptions<OidcOptions> oidcOptions)
        {
            _db = db;
            _memoryCache = memoryCache;
            _logger = logger;
            _oidcOptions = oidcOptions.Value;
        }

        private OidcClient GetOidcClient()
        {
            return  new OidcClient(new OidcClientOptions()
            {
                Authority = _oidcOptions.Authority,
                ClientId = _oidcOptions.ClientId,
                ClientSecret = _oidcOptions.ClientSecret
            });
        }

        public async Task<(string> StartOidcLogin(string redirectUrl, bool prompt = false)
        {
            var client = GetOidcClient();
            var state = await client.PrepareLoginAsync(new { prompt});
            var oidcLoginKey = Guid.NewGuid().ToString();
            
            return state.StartUrl;
        }
        

        public async Task<string> FinishOidcLogin(string code)
        {
            var client = GetOidcClient();
            var result = await client.ProcessResponseAsync(code, oidcLogin.AuthorizeState);
            if (result.IsError)
            {
                _logger.LogError("Oidc login failure: " + result.Error);
                return null;
            }

            return "";
        }
    }
}
