using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(doanchithang_lab456_1711061719.Startup))]
namespace doanchithang_lab456_1711061719
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
