using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCustomerMvcAppWithAuthentication.Startup))]
namespace MovieCustomerMvcAppWithAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
