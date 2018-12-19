using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace MyCompany.MyProject.Scheduler.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateGenericHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateGenericHostBuilder(string[] args) => new HostBuilder()
                .ConfigureHostConfiguration((context) =>
                {
                    context.SetBasePath(Directory.GetCurrentDirectory());
                    context.AddJsonFile("hostsettings.json", optional: true);
                    context.AddEnvironmentVariables();
                    context.AddCommandLine(args);
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        // Development service configuration
                    }
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseConsoleLifetime();

    }
}
