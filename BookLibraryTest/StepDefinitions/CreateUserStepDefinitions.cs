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
                
        public CreateUserStepDefinitions( ISpecFlowOutputHelper specFlowOutputHelper)
        {
            this._specFlowOutputHelper = specFlowOutputHelper;
        }
        
        [Given(@"to create new User - username email password with")]
        public void GivenToCreateNewUser_UsernameEmailPasswordWith(string json)
        {
            content = new StringContent(json, Encoding.UTF8, "application/json");            
        }

        [When(@"user sends a post request with url as ""([^""]*)""")]
        public async Task WhenUserSendsAPostRequestWithUrlAsAsync(string url)
        {
            response = await httpClient.PostAsync(url, content);
        }

        [Then(@"request should be a success with (.*)s code")]
        public async Task ThenRequestShouldBeASuccessWithSCodesAsync(int status)
        {            
            response.EnsureSuccessStatusCode();
            responeseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responeseBody);
            Assert.IsTrue((int)response.StatusCode == status);
        }
    }
}
