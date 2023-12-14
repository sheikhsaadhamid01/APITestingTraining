
using APITestProject.Base;
using FluentAssertions;
using GraphQLProductApp.Controllers;
using GraphQLProductApp.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Security;
using Xunit.Abstractions;

namespace APITestProject
{
    public class UnitTest1
    {
        private readonly  ITestOutputHelper _outputHelper;
        private IRestFactory _restFactory;
        private string _token; 
        public UnitTest1(ITestOutputHelper outputHelper, IRestFactory restFactory)
        {
            this._outputHelper = outputHelper;
            _restFactory = restFactory;
             _token = GetAuthentication();

        }
        [Fact]
        public async void GetTest()
        {
            

            var response = await _restFactory.Create()
                .WithRequest("Product/GetProductById/{id}")
                .WithUrlSegment("id", "1")
                .WithHeader("Authorization", "Bearer "+ _token)
                .WithGet<Product>();
          
            response?.Name.Should().Be("Keyboard");

            
        }

        [Fact]
        public async void PostProductTest()
        {
           
            var response = await _restFactory
                .Create()
                .WithRequest("/Product/Create")
                .WithBody(new Product
                {
                    Name = "Tablet",
                    Description = "Apple Tablet",
                    Price = 900,
                    ProductType = ProductType.PERIPHARALS

                })
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithPost<Product>();

            
          
            response?.Price.Should().Be(900);

            //_outputHelper.WriteLine($"{response.Content}");
        }
        [Fact]
        public async void FileUploadTest()
        {

            var authresponse = await _restFactory
                .Create()
                .WithRequest("Product")
                .WithFile("myFile", @"C:\Users\Administrator\Pictures\myFile1.png")
                .WithHeader("Authorization", $"Bearer {_token}")
                .WithPost();

            authresponse.StatusCode.Should().Be(HttpStatusCode.Created);
                



            /*
            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("Product", Method.Post);
            //request.AddFile("myFile", @"C:\Users\Administrator\Pictures\myFile.png", contentType: "multipart/form-data");
           // request.AddHeader("Authorization", $"Bearer {GetAuthentication().ToString()}");
            
            
            var response = await client.ExecuteAsync(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            //_outputHelper.WriteLine($"{response.Content}");*/
        }


        public string GetAuthentication()
        {

            var authResponse = _restFactory.Create()
                .WithRequest("api/Authenticate/Login")
                .WithBody(new LoginModel
                 {
                     UserName = "KK",
                     Password = "123456"
                 })
                 .WithPost().Result.Content;

           
            JToken? token = JObject.Parse(authResponse)["token"];
            return token.ToString();



            
        }
    }
}