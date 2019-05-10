using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace Afk4Events.WebClient.Util
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpJsonResult<T>> PostHttpJson<T>(this HttpClient httpClient, string url, object model)
        {
            var result = new HttpJsonResult<T>(); 
            var httpResult = await httpClient.PostAsync(url, new StringContent(Json.Serialize(model), Encoding.UTF8, "application/json"));
            result.ResponseModel = Json.Deserialize<T>(await httpResult.Content.ReadAsStringAsync());
            result.HttpResponse = httpResult;
            return result;
        }
    }

    public class HttpJsonResult<T>
    {
        public T ResponseModel { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }
    }
}
