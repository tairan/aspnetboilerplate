using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.MyProject.AppHost.HostedServices
{
    public abstract class HostedServiceBase : IHostedService
    {
        protected readonly IApplicationLifetime _appLifetime;

        public HostedServiceBase(ILoggerFactory loggerFactory,
            IApplicationLifetime applicationLifetime)
        {
            _appLifetime = applicationLifetime;
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);
            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected abstract void OnStopped();
        protected abstract void OnStarted();
        protected abstract void OnStopping();

    }
}
