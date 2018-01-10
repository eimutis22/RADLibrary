using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RADLibrary.Startup))]
namespace RADLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
