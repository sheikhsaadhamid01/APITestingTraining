using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace RestSharpSpecflow.Steps;

[Binding]
public sealed class BasicOperation
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    private RestClient _restClient;
    private Product? _firstResponse;
    private Product? _secondResponse;
    
    public BasicOperation(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _restClient = _scenarioContext.Get<RestClient>("RestClient");
    }


    [Given(@"I perform a GET operation of ""(.*)""")]
    public async Task GivenIPerformAgetOperationOf(string path, Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        var token = GetToken();

        //Rest Request
        var request = new RestRequest(path);
        request.AddUrlSegment("id", (int)data.ProductId);
        request.AddHeader("Authorization", $"Bearer {token}");
        //Perform GET operation
        _firstResponse= await _restClient.GetAsync<Product>(request);
    }
    
    [Given(@"I perform another GET operation ""(.*)""")]
    public async Task GivenIPerformAnotherGetOperation(string path, Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        var token = GetToken();

        //Rest Request
        var request = new RestRequest(path);
        request.AddUrlSegment("id", (int)data.ProductId);
        request.AddHeader("Authorization", $"Bearer {token}");
        //Perform GET operation
        _secondResponse= await _restClient.GetAsync<Product>(request);
    }

    [Given(@"I should get the product name as ""(.*)""")]
    public void GivenIShouldGetTheProductNameAs(string value)
    {
        _firstResponse.Name.Should().Be(value);
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


    [Given(@"I should verify if Product is always the same")]
    public void GivenIShouldVerifyIfProductIsAlwaysTheSame()
    {
        _firstResponse.Should().BeEquivalentTo(_secondResponse, opt => 
            opt
                .Using<DateTime>(c => 
                    c
                        .Subject
                        .Should()
                        .BeCloseTo(c.Expectation, TimeSpan.FromHours(24)))
                .WhenTypeIs<DateTime>()
        );
    }


    [Given(@"I should verify if Product(.*) and Product(.*) addresses are the same")]
    public void GivenIShouldVerifyIfProductAndProductAddressesAreTheSame(int p0, int p1)
    {
        var firstAddress = _firstResponse.Components.First().Manufacturers.First().Addresses;
        var secondAddress = _secondResponse.Components.First().Manufacturers.First().Addresses;
        firstAddress.Should().BeEquivalentTo(secondAddress, opt => 
            opt.Excluding(c => c.Id));
    }

    [Given(@"I should verify if Product(.*) and Product(.*) manufacturers are the same")]
    public void GivenIShouldVerifyIfProductAndProductManufacturersAreTheSame(int p0, int p1)
    {
        var firstManufacturers = _firstResponse.Components;
        var secondManufacturers = _secondResponse.Components;

        firstManufacturers.Should().BeEquivalentTo(secondManufacturers, opt =>
            opt.Excluding(c => c.Id)
                .Using<DateTime>(c => 
                    c
                        .Subject
                        .Should()
                        .BeCloseTo(c.Expectation, TimeSpan.FromHours(24)))
                .WhenTypeIs<DateTime>());
    }
}