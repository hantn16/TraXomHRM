using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TraXomHRM.Startup))]
namespace TraXomHRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
