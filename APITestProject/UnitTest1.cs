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
        public async void Test1()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };
            var client = new RestClient(options);
            var request = new RestRequest("Product/GetProductById/1");
            var response = await client.GetAsync(request);

            _outputHelper.WriteLine($"{response.Content}");
        }
    }
}