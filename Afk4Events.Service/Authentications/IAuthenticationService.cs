using System.Threading.Tasks;
using Afk4Events.Data.Entities.Users;
using IdentityModel.OidcClient;

namespace Afk4Events.Service.Authentications
{
	public interface IAuthenticationService
	{
		Task<AuthorizeState> StartOidcLogin(string redirectUrl, bool prompt = false);
		Task<User> FinishOidcLogin(string code, string stateKey, string redirectUrl);
	}
}
