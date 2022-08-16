using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BookLibraryTest.StepDefinitions
{
    public class HttpSettings
    {
        public HttpClient httpClient = new HttpClient();
        public HttpResponseMessage response;
        public string responeseBody;
        public HttpContent content;
        string jsonString;
        public string token;

        void setJson()
        {
            jsonString = "{\r\n  \"emailAddress\": \"testUser@mailinator.com\",\r\n  \"password\": \"Test123!\"\r\n}";
        }

        public async Task AuthenticateUser()
        {
            string url = HttpUtility.UrlDecode("http%3A%2F%2Flocalhost%3A5000%2FAuthentication%2Flogin", Encoding.UTF8);
            setJson();
            content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync(url, content);
            responeseBody = await response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<ResponseClass>(responeseBody);
            token = responseToken.Token;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", $"Bearer {responseToken.Token}");            
        }
    }
}
