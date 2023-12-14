using RestSharp;

namespace APITestProject.Base
{
    public interface IRestLibrary
    {
        RestClient RestClient { get; }
    }
}