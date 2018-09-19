using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseProject.Startup))]
namespace HouseProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
