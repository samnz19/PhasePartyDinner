using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DinnerPartyRoa.Startup))]
namespace DinnerPartyRoa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
