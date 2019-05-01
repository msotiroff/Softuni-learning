using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumbersFromOneToFifty.Startup))]
namespace NumbersFromOneToFifty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
