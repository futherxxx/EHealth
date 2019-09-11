using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocApp.Startup))]
namespace DocApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
