using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject.Base
{
    public class RestLibrary : IRestLibrary
    {
        private readonly RestClientOptions _options;
        private RestClient _client;
        public RestLibrary()
        {
            _options = new RestClientOptions
            {
                BaseUrl = new Uri("https://localhost:5001/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true

            };
            _client = new RestClient(_options);
        }

        public RestClient RestClient { get => this._client; }

    }
}
