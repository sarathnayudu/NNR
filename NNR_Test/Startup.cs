using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NNR_Test.Startup))]
namespace NNR_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
