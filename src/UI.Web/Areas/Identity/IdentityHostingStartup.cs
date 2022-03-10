using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(UI.Web.Areas.Identity.IdentityHostingStartup))]
namespace UI.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}