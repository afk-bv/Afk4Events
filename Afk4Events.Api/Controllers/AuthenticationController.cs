using System.Threading.Tasks;
using Afk4Events.Models.Authentication;
using Afk4Events.Models.Users;
using Afk4Events.Service.Authentications;
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
        public async Task<IActionResult> StartAuthentication(string provider)
        {
            var returnUrl = $"https://{Request.Host.Value}/login";
            var authorizationState = await _authenticationService.StartOidcLogin(returnUrl);
            var authStartResponse = new AuthenticationStartResponse(authorizationState.StartUrl, authorizationState.State);
            return Ok(authStartResponse);
        }

        [HttpPost("{provider}")]
        public async Task<IActionResult> FinishAuthentication([FromBody] AuthenticationFinishRequest requestModel)
        {
            var user = await _authenticationService.FinishOidcLogin(requestModel.Code, requestModel.State, requestModel.Url);
            if (user == default)
            {
                return Unauthorized();
            }
            // todo set session here

            var userDto = new UserDto(user.Name, user.Email, user.ProfilePictureUrl);
            return Ok(user);
        }
    }
}