using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcHomeWork.Startup))]
namespace mvcHomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
