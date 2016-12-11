using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WessingGuestBook.Startup))]
namespace WessingGuestBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
