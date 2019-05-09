using System.Threading.Tasks;
using Afk4Events.Models.Authentication;
using Afk4Events.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Afk4Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("{provider}")]
        public async Task<IActionResult> StartAuth(string provider)
        {
            var returnUrl = $"https://{Request.Host.Value}/login";
            var authorizationState = await _authenticationService.StartOidcLogin(returnUrl);
            var authStartResponse = new AuthenticationStartResponse(authorizationState.StartUrl, authorizationState.State);
            return Ok(authStartResponse);
        }
    }
}