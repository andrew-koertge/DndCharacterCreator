using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DnDCharacterCreator.Startup))]
namespace DnDCharacterCreator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
