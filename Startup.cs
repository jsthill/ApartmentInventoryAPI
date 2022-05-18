using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ApartmentInventoryAPI.Startup))]

namespace ApartmentInventoryAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
