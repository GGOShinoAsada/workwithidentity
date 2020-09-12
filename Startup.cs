using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(workwithidentity.Startup))]
namespace workwithidentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
