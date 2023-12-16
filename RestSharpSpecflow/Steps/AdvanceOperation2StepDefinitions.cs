using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpSpecflow.Steps
{
    [Binding]
    public class AdvanceOperation2StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private RestClient _restClient;
        private Product? _firstResponse;
        private Product? _secondResponse;
        private string _token;
        public AdvanceOperation2StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = _scenarioContext.Get<RestClient>("RestClient");
            _token = GetToken();

        }

        [Given(@"user perform a GET Operation of ""([^""]*)""")]
        public async Task GivenUserPerformAGETOperationOf(string path, Table table)
        {
            RestRequest request = new RestRequest(path);
            dynamic tableData = table.CreateDynamicInstance();
            request.AddUrlSegment("id", (int)tableData.ProductId);
            request.AddHeader("Authorization", $"Bearer {_token}");

            _firstResponse = await _restClient.GetAsync<Product>(request);

        }

        [Given(@"user perform another GET operation of ""([^""]*)""")]
        public async Task GivenUserPerformAnotherGETOperationOf(string path, Table table)
        {
            RestRequest request = new RestRequest(path);
            dynamic tableData = table.CreateDynamicInstance();
            request.AddUrlSegment("id", (int)tableData.ProductId);
            request.AddHeader("Authorization", $"Bearer {_token}");
            _secondResponse = await _restClient.GetAsync<Product>(request);
        }

        [Then(@"user should get a product name as ""([^""]*)""")]
        public void ThenUserShouldGetAProductNameAs(string keyboard)
        {
            _firstResponse.Should().BeEquivalentTo(_secondResponse, opt =>
            opt.Using<DateTime>(c =>
            c
            .Subject
            .Should()
            .BeCloseTo(c.Expectation, TimeSpan.FromMilliseconds(1000)))
            .WhenTypeIs<DateTime>()
            );
        }

        [Then(@"user should verify if Product(.*) and Product(.*) Address are same")]
        public void ThenUserShouldVerifyIfProductAndProductAddressAreSame(int p0, int p1)
        {
            var firstAddress  = _firstResponse.Components.First().Manufacturers.First().Addresses;
            var secondAddress = _secondResponse.Components.First().Manufacturers.First().Addresses;
            firstAddress.Should().BeEquivalentTo(secondAddress, opt => opt.Excluding(c=> c.Id));
            
        }

        private string GetToken()
        {
            //Rest Request
            var authRequest = new RestRequest("api/Authenticate/Login");

            //Typed object being passed as body in request
            authRequest.AddJsonBody(new LoginModel
            {
                UserName = "KK",
                Password = "123456"
            });

            //Perform GET operation
            var authResponse = _restClient.PostAsync(authRequest).Result.Content;

            //Token from JSON object
            return JObject.Parse(authResponse)["token"].ToString();
        }

    }

    
}
