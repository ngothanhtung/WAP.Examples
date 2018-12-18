using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlobalizationSample.Startup))]
namespace GlobalizationSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
