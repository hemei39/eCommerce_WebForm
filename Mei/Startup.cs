using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mei.Startup))]
namespace Mei
{
    public partial class Startup {
        //public void Configuration(IAppBuilder app) {
        //    ConfigureAuth(app);
        //}
    }
}
