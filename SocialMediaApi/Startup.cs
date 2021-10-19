using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SocialMediaApi.Startup))]

namespace SocialMediaApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Start of the application
            ConfigureAuth(app); 
        }
    }
}
