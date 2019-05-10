namespace Afk4Events.Models.Authentication
{
	public class AuthenticationStartResponse
	{
		public AuthenticationStartResponse(string redirectUrl, string state)
		{
			RedirectUrl = redirectUrl;
			State = state;
		}

		public AuthenticationStartResponse()
		{
		}

		public string RedirectUrl { get; set; }
		public string State { get; set; }
	}
}
