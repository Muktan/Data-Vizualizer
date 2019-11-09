using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Data_Vizualizer.Startup))]
namespace Data_Vizualizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
