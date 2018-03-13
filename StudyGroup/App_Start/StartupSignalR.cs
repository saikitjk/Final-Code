using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(StudyGroup.Startup))]
namespace StudyGroup
{
    public partial class Startup

    {
        public void ConfigurationSignalR(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}