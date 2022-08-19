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
using NUnit.Framework.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using FluentAssertions;
using SpecFlow.Internal.Json;
using NUnit.Framework;

namespace BookLibraryTest.StepDefinitions
{
    public class HttpSettings
    {
        public HttpClient httpClient = new HttpClient();
        public HttpResponseMessage? Response { get; set; }
        public string? ResponeseBody { get; set; }
        public HttpContent? Content { get; set; }
        string jsonString = "{\r\n  \"emailAddress\": \"test@mailinator.com\",\r\n  \"password\": \"Test123!\"\r\n}";
        public string? token;

        [BeforeScenario]
        public async Task AuthenticateUserAsync()
        {
            string url = HttpUtility.UrlDecode("http%3A%2F%2Flocalhost%3A5000%2FAuthentication%2Flogin", Encoding.UTF8);

            Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Response = await httpClient.PostAsync(url, Content);
            ResponeseBody = await Response.Content.ReadAsStringAsync();
            var responseToken = JsonConvert.DeserializeObject<LoggedUserResponseModel>(ResponeseBody);
            token = responseToken.Token;
        }

        public string getToken()
        {
            return token;
        }
        
        [AfterScenario]
        public void TearDown()
        {
            httpClient.Dispose();
        }        
    }
}
