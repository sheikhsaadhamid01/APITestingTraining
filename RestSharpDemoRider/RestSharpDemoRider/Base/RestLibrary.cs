using System;
using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;

namespace RestSharpDemoRider.Base;

public interface IRestLibrary
{
    RestClient RestClient { get; }
}

public class RestLibrary : IRestLibrary
{
    public RestLibrary(WebApplicationFactory<GraphQLProductApp.Startup> webApplicationFactory)
    {
        var restClientOptions = new RestClientOptions
        {
            BaseUrl = new Uri("https://localhost:5001/"),
            RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
        };

        //Spawn our SUT
        var client = webApplicationFactory.CreateDefaultClient();
        
        //Rest Client
        RestClient = new RestClient(client, restClientOptions);
    }
    
    public RestClient RestClient { get; }
}