using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.MyProject.AppHost.HostedServices
{
    public class DefaultTimedHostedService : HostedServiceBase
    {
        private readonly ILogger<DefaultTimedHostedService> _logger;
        private Timer _timer;

        public DefaultTimedHostedService(ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
            : base(loggerFactory, applicationLifetime)
        {
            _logger = loggerFactory.CreateLogger<DefaultTimedHostedService>();
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("Service is starting.");

            _timer = new Timer((state) =>
            {
                _logger.LogInformation("Service is working.");
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        protected override void OnStopped()
        {
            _logger.LogInformation("Service is stopped");
        }

        protected override void OnStopping()
        {
            _logger.LogInformation("Service is stopping");
        }
    }
}
