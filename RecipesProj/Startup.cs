using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipesProj.Startup))]
namespace RecipesProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
