using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FitnessProgressTracker
{
    public class Program
    {
        /// <summary>
        /// Creating the Web service
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// hosting
        /// </summary>
        /// <param name="args"></param>
        /// <returns> WebHost.CreateDefaultBuilder(args).UseStartup<Startup>(); </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}
