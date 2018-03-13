using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyGroup.Startup))]
namespace StudyGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigurationSignalR(app);
        }

        
    }
}
