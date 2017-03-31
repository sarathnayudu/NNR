using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SunRise.Startup))]
namespace SunRise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
