using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Afk4Events.Models.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.JSInterop;
using Blazor.Extensions.Storage;

namespace Afk4Events.WebClient.ViewModels
{
    public class LoginViewModel
    {
        private readonly HttpClient _http;
        private IUriHelper _uriHelper { get; set; }
        protected LocalStorage _localStorage { get; set; }

        public LoginViewModel(HttpClient http, IUriHelper helper, LocalStorage storage) 
        {
            _http = http;
            _uriHelper = helper;
            _localStorage = storage;
        }

        public string Email { get; set; }

        public string TestVar { get; set; } = "ree";

        public async Task StartAuthentication()
        { 
            var googleOauthUrl = await _http.GetJsonAsync<AuthenticationStartResponse>("https://localhost/api/authentication/google");
            _uriHelper.NavigateTo(_uriHelper.ToAbsoluteUri(googleOauthUrl.RedirectUrl).ToString());
        }
    }
}
