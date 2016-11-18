using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityBooking.Startup))]
namespace UniversityBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
