using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace BookLibraryTest.StepDefinitions.Tests
{
    [Binding]
    public class CreateBookWithEmptyTitle :HttpSettings
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        protected new HttpResponseMessage Response { get; set; }
        public new string ResponeseBody { get; set; }
        public CreateBookWithEmptyTitle(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"I am an existing client")]
        public async Task GivenIAmAnExistingClientAsync()
        {
             _specFlowOutputHelper.WriteLine(token);
        }

        [When(@"I make a post request to '([^']*)' with the following wrong data '([^']*)'")]
        public async Task WhenIMakeAPostRequestToWithTheFollowingWrongDataAsync(string resourceEndPoint, string postDataJson)
        {
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{getToken()}");
            Response = await httpClient.PostAsync(resourceEndPoint, content).ConfigureAwait(false);
            ResponeseBody = await Response.Content.ReadAsStringAsync();
        }

        [Then(@"the bad request response status code is '([^']*)'")]
        public async Task ThenTheResponseStatusCodeIsAsync(int status)
        {
            ResponeseBody = await Response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(ResponeseBody);

            Assert.IsTrue((int)Response.StatusCode == status);
        }

        [Then(@"the bad request response data should be '([^']*)'")]
        public async Task ThenTheResponseDataShouldBeAsync(string expectedResponseContent)
        {            
            ResponeseBody = await Response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<CreateBookBadRequestModel>(ResponeseBody);
            expectedResponseContent = "Title must not be empty";

            Assert.AreEqual(responseContent.Errors.Title[0], expectedResponseContent);            
        }
    }
}
