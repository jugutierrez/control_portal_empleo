using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(control_portal_empleo.Startup))]
namespace control_portal_empleo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
