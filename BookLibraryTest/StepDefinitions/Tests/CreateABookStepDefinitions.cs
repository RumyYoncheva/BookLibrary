using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using Ubiety.Dns.Core;
using TechTalk.SpecFlow.Infrastructure;
using NUnit.Framework;
using Newtonsoft.Json;

namespace BookLibraryTest.StepDefinitions
{
    [Binding]
    public class CreateABookStepDefinitions : HttpSettings
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        protected new HttpResponseMessage Response { get; set; }
        public string? responeseBody { get; set; }
        
        public CreateABookStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }
        
        [Given(@"I am a client")]
        public async Task GivenIAmAClientAsync()
        {
            _specFlowOutputHelper.WriteLine(token);
        }

        [When(@"I make a post request to '([^']*)' with the following data '([^']*)'")]
        public async Task WhenIMakeAPostRequestToWithTheFollowingDataAsync(string resourceEndPoint, string postDataJson)
        {
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{getToken()}");
            Response = await httpClient.PostAsync(resourceEndPoint, content).ConfigureAwait(false);
            responeseBody = await Response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responeseBody);
        }

        [Then(@"the response status code is '([^']*)'")]
        public async Task ThenTheResponseStatusCodeIsAsync(int status)
        {
            Response.EnsureSuccessStatusCode();
            responeseBody = await Response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responeseBody);

            Assert.IsTrue((int)Response.StatusCode == status);
        }

        [Then(@"the response data should be '([^']*)'")]
        public async Task ThenTheResponseDataShouldBeAsync(string expectedResponseContent)
        {            
            responeseBody = await Response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<CreateBookResponseModel>(responeseBody);
            expectedResponseContent = $"Successfully added book with id:{responseContent.BookId}";
            
            Assert.AreEqual(responseContent.OperationMessage, expectedResponseContent);            
        }
    }
}
