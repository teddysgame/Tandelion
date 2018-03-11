using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tandelion0.Startup))]
namespace Tandelion0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
