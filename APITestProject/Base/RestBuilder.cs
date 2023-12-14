using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject.Base
{
    public class RestBuilder : IRestBuilder
    {
        IRestLibrary _library;
       

        public RestBuilder(IRestLibrary library)
        {
            this._library = library;
        }

        private RestRequest RestRequest { get; set; } = null!;

        public IRestBuilder WithRequest(string request)
        {
            RestRequest = new RestRequest(request);
            return this;
        }


        public IRestBuilder WithHeader(string key, string value)
        {
            RestRequest.AddHeader(key, value);
            return this;
        }

        public IRestBuilder WithQueryParameter(string query, string value)
        {
            RestRequest.AddQueryParameter(query, value);
            return this;
        }

        public IRestBuilder WithUrlSegment(string name, string value)
        {
            RestRequest.AddUrlSegment(name, value);
            return this;
        }

        public IRestBuilder WithBody(Object body)
        {
            RestRequest.AddJsonBody(body);
            return this;
        }

        public IRestBuilder WithFile(string filename, string filePath)
        {
            RestRequest.AddFile(filename, filePath);
            return this;
        }


        public async Task<T?> WithGet<T>()
        {
            return await _library.RestClient.GetAsync<T>(RestRequest);
        }

        public async Task<T?> WithPost<T>()
        {
            return await _library.RestClient.PostAsync<T>(RestRequest);
        }

        public async Task<RestResponse> WithPost()
        {
            return await _library.RestClient.PostAsync(RestRequest);
        }

        public async Task<T> WithPut<T>()
        {
            return await _library.RestClient.PutAsync<T>(RestRequest);
        }
        public async Task<RestResponse> WithExecuteAsync()
        {
            return await _library.RestClient.ExecuteAsync(RestRequest);
        }

        public async Task<T> WithDelete<T>()
        {
            return await _library.RestClient.DeleteAsync<T>(RestRequest);
        }

        public async Task<T> WithPath<T>()
        {
            return await _library.RestClient.PatchAsync<T>(RestRequest);
        }


       
    }
}
