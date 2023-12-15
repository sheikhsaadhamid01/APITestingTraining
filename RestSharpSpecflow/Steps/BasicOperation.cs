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
    private Product? _response;
    
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
        _response= await _restClient.GetAsync<Product>(request);
    }

    [Given(@"I should get the product name as ""(.*)""")]
    public void GivenIShouldGetTheProductNameAs(string value)
    {
        _response.Name.Should().Be(value);
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