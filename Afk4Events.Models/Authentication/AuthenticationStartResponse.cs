using System;
using System.Collections.Generic;
using System.Text;

namespace Afk4Events.Models.Authentication
{
    public class AuthenticationStartResponse
    {
        public string RedirectUrl { get; set; }
        public string State { get; set; }

        public AuthenticationStartResponse(string redirectUrl, string state)
        {
            RedirectUrl = redirectUrl;
            State = state;
        }

        public AuthenticationStartResponse()
        {
            
        }
    }
}
