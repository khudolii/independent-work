using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceAccounting.Startup))]
namespace ServiceAccounting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
