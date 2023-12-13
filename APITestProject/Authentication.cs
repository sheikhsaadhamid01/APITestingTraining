using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace APITestProject
{
    public class Authentication
    {
        private readonly ITestOutputHelper _outputHelper;
        private RestClientOptions _options;

        public Authentication(ITestOutputHelper outputHelper)
        {
            this._outputHelper = outputHelper;
            _options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
        }

        [Fact]
        public async void GetAuthentication()
        {
            var client = new RestClient(_options);
            RestRequest authRequest = new RestRequest("api/Authenticate/Login");
            authRequest.AddJsonBody(new LoginModel
            {
                UserName = "KK",
                Password = "123456",

            });
            var authResponse = client.PostAsync(authRequest).Result.Content;
            var token = JObject.Parse(authResponse)["token"];

            var productGetRequest = new RestRequest("/Product/GetProductById/{id}");
            productGetRequest.AddUrlSegment("id", 1);
            productGetRequest.AddHeader("Authorization",  $"Bearer {token!.ToString()}");
            var productResponse = await client.GetAsync<Product>(productGetRequest);
            productResponse?.Name.Should().Be("Keyboard");



        }



    }
}
