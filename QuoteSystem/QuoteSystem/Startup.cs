using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QuoteSystem.Startup))]

namespace QuoteSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}