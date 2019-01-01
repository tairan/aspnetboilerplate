using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyCompany.MyProject.AppHost.HostedServices;
using System;
using System.IO;

namespace MyCompany.MyProject.AppHost
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateGenericHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateGenericHostBuilder(string[] args) => new HostBuilder()
            .ConfigureHostConfiguration((context) =>
            {
                context.SetBasePath(Directory.GetCurrentDirectory());
                context.AddJsonFile("hostsettings.json", optional: true);
                context.AddEnvironmentVariables(prefix: "GENERICHOST_");
                context.AddCommandLine(args);
            })
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables(prefix: "GENERICHOST_");
                config.AddCommandLine(args);
            })
            .ConfigureServices((context, services) =>
            {
                if (context.HostingEnvironment.IsDevelopment())
                {
                    // Development service configuration
                    services.AddHostedService<DefaultTimedHostedService>();
                }
                else
                {
                    // Non-development service configuration
                    services.AddHttpClient();
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
