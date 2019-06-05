using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookCarProject.Startup))]
namespace BookCarProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
