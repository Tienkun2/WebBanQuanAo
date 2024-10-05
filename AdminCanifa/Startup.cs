using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminCanifa.Startup))]
namespace AdminCanifa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
