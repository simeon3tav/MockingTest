using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MockingTest.Startup))]
namespace MockingTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
