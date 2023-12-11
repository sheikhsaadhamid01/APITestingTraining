using APITestProject.Models;
using FluentAssertions;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using Xunit.Abstractions;

namespace APITestProject
{
    public class UnitTest1
    {
        private readonly  ITestOutputHelper _outputHelper;
        public UnitTest1(ITestOutputHelper outputHelper)
        {
            this._outputHelper = outputHelper;
        }
        [Fact]
        public async void GetTest()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("/Product/GetProductByIdAndName");
            request.AddQueryParameter("id", 2);
            request.AddQueryParameter("name", "Monitor");
            var response = await client.GetAsync<Product>(request);

            response?.Price.Should().Be(400);

            //_outputHelper.WriteLine($"{response.Content}");
        }

        [Fact]
        public async void PostProductTest()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("/Product/Create");
            request.AddJsonBody(new Product
            {
                Name = "Cabinet",
                Description = "Gaming Cabinet",
                Price = 300,
                ProductType = ProductType.PERIPHARALS

            });
            var response = await client.PostAsync<Product>(request);
            response?.Price.Should().Be(300);

            //_outputHelper.WriteLine($"{response.Content}");
        }
    }
}