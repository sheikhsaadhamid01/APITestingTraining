
using RestSharp;

namespace APITestProject.Base
{
    public interface IRestBuilder
    {
        IRestBuilder WithBody(object body);
        Task<T> WithDelete<T>();
        Task<T> WithGet<T>();
        IRestBuilder WithHeader(string key, string value);
        IRestBuilder WithFile(string filename, string filePath);
        Task<T> WithPath<T>();
        Task<T> WithPost<T>();
        Task<RestResponse> WithPost();
        Task<T> WithPut<T>();
        IRestBuilder WithQueryParameter(string query, string value);
        IRestBuilder WithRequest(string request);
        IRestBuilder WithUrlSegment(string name, string value);

        Task<RestResponse> WithExecuteAsync();
    }
}