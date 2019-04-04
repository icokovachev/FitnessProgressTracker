using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FitnessProgressTracker.Areas.Identity.IdentityHostingStartup))]
namespace FitnessProgressTracker.Areas.Identity
{
    /// <summary>
    /// This class is building and runnig the WebServices
    /// </summary>
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}