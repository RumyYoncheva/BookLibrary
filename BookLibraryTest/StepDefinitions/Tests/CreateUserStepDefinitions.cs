using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using static System.Net.Mime.MediaTypeNames;

namespace BookLibraryTest.StepDefinitions
{
    [Binding]
    public class CreateUserStepDefinitions : HttpSettings
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public CreateUserStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"to create new User - username email password with")]
        public void GivenToCreateNewUser_UsernameEmailPasswordWith(string json)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        [When(@"user sends a post request with url as ""([^""]*)""")]
        public async Task WhenUserSendsAPostRequestWithUrlAsAsync(string url)
        {
            Response = await httpClient.PostAsync(url, Content);
        }

        [Then(@"request should be a success with (.*)s code")]
        public async Task ThenRequestShouldBeASuccessWithSCodesAsync(int status)
        {
            Response.EnsureSuccessStatusCode();
            ResponeseBody = await Response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(ResponeseBody);
            Assert.IsTrue((int)Response.StatusCode == status);
        }
    }
}
