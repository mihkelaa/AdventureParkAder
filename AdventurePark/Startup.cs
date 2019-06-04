using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdventurePark.Startup))]
namespace AdventurePark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
