using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudExample.Startup))]
namespace CrudExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
