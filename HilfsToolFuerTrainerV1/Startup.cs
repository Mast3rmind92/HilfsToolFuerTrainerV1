using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HilfsToolFuerTrainerV1.Startup))]
namespace HilfsToolFuerTrainerV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
