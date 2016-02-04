using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MichalZawadzkiLibrus.Startup))]
namespace MichalZawadzkiLibrus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
