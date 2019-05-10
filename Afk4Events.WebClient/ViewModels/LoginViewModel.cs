using System;
using System.Net.Http;
using System.Threading.Tasks;
using Afk4Events.Models.Authentication;
using Afk4Events.Models.Users;
using Afk4Events.WebClient.Util;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Afk4Events.WebClient.ViewModels
{
	public class LoginViewModel : ComponentBase
	{
		[Inject] private HttpClient Http { get; set; }
		[Inject] private IUriHelper UriHelper { get; set; }
		[Inject] private LocalStorage LocalStorage { get; set; }
		public UserDto User { get; set; }

		public async Task StartAuthentication()
		{
			var googleOauthUrl = await Http.GetJsonAsync<AuthenticationStartResponse>("api/authentication/google");
			await LocalStorage.SetItem("OAUTH", googleOauthUrl.State);
			UriHelper.NavigateTo(UriHelper.ToAbsoluteUri(googleOauthUrl.RedirectUrl).ToString());
		}

		protected override async Task OnInitAsync()
		{
			string absoluteUrl = UriHelper.GetAbsoluteUri();
			var uri = new Uri(absoluteUrl);
			var query = QueryHelpers.ParseQuery(uri.Query);
			bool hasQuery = query.TryGetValue("code", out var code);
			bool hasState = query.TryGetValue("state", out var state);

			// Check whether the page has been loaded as result of an OpenID Connect redirect
			if (!hasQuery || !hasState)
			{
				return;
			}

			var result = await Http.PostHttpJson<UserDto>("api/authentication/google", new AuthenticationFinishRequest(absoluteUrl, code, state));
			if (result.HttpResponse.IsSuccessStatusCode)
			{
				User = result.ResponseModel;
			}
			else
			{
				Console.WriteLine(result.HttpResponse);
			}
		}
	}
}
