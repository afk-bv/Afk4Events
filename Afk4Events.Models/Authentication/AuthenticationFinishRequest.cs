namespace Afk4Events.Models.Authentication
{
    public class AuthenticationFinishRequest
    {
        public string Url { get; set; }
        public string Code { get; set; }
        public string State { get; set; }

        public AuthenticationFinishRequest(string url, string code, string state)
        {
            Url = url;
            Code = code;
            State = state;
        }

        public AuthenticationFinishRequest()
        {
            
        }
    }
}