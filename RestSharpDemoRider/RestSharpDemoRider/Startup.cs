using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using RestSharpDemoRider.Base;

namespace RestSharpDemoRider;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<IRestLibrary>(new RestLibrary(new WebApplicationFactory<GraphQLProductApp.Startup>()))
            .AddScoped<IRestBuilder, RestBuilder>()
            .AddScoped<IRestFactory, RestFactory>();
    }
}