using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestProject.Base
{
    public class RestFactory : IRestFactory
    {
        private readonly IRestBuilder restBuilder;

        public RestFactory(IRestBuilder builder)
        {
            restBuilder = builder;
        }

        public IRestBuilder Create()
        {
            return this.restBuilder;
        }

    }
}
