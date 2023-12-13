
using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
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
            request.AddHeader("Authorization", $"Bearer {GetAuthentication().ToString()}");
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
            request.AddHeader("Authorization", $"Bearer {GetAuthentication().ToString()}");
            var response = await client.PostAsync<Product>(request);
            response?.Price.Should().Be(300);

            //_outputHelper.WriteLine($"{response.Content}");
        }
        [Fact]
        public async void FileUploadTest()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("Product", Method.Post);
            request.AddFile("myFile", @"C:\Users\Administrator\Pictures\myFile.png", contentType: "multipart/form-data");
            request.AddHeader("Authorization", $"Bearer {GetAuthentication().ToString()}");
            
            // request.AddJsonBody("{\r\n  \"userName\": \"string\",\r\n  \"password\": \"string\"\r\n}");
            var response = await client.ExecuteAsync(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //_outputHelper.WriteLine($"{response.Content}");
        }


        public JToken GetAuthentication()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            var client = new RestClient(options);
            var request = new RestRequest("api/Authenticate/Login");
            request.AddJsonBody(new LoginModel
            {
                UserName = "KK",
                Password = "123456"
            });

            var response = client.PostAsync(request).Result.Content;
            JToken? token = JObject.Parse(response)["token"];
            return token;



            
        }
    }
}