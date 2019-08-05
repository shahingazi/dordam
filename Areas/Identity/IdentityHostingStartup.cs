using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PriceComparisonWeb.Areas.Identity.IdentityHostingStartup))]
namespace PriceComparisonWeb.Areas.Identity
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