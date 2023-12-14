﻿using APITestProject.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IRestLibrary, RestLibrary>()           
                .AddScoped<IRestBuilder, RestBuilder>()
                .AddScoped<IRestFactory, RestFactory>();

        }
    }
}
