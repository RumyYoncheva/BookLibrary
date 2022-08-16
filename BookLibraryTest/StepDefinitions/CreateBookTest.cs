using Gherkin;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace BookLibraryTest.StepDefinitions
{
    [Binding]
    public class CreateBookTest : HttpSettings
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public CreateBookTest(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this._specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"The book details")]
        public void GivenTheBookDetails(string json)
        {
            _ = AuthenticateUser();
            content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        [When(@"user sends a POST request with url as ""([^""]*)""")]
        public async Task WhenUserSendsAPostRequestWithUrlAsAsync(string url)
        {
            response = await httpClient.PostAsync(url, content);
        }

        [Then(@"request should be with (.*)s success codes")]
        public async Task ThenRequestShouldBeASuccessWithSCodesAsync(int status)
        {
            response.EnsureSuccessStatusCode();
            responeseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responeseBody);
            _specFlowOutputHelper.WriteLine(token);
            Assert.IsTrue((int)response.StatusCode == status);
        }
    }
}
