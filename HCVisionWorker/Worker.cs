using HCVisionWorker.Infrasturcture;
using HCVisionWorker.Monitor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HCVisionWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(
            IServiceProvider serviceProvider,
            ILogger<Worker> logger = null
            )
        {
            this._logger = logger;
            this._serviceProvider = serviceProvider;
        }

        static int count { get; set; }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Worker starting at: {0}", DateTimeOffset.Now);
            LogUtil.Write($"{DateTimeOffset.Now} Worker starting.......", "Base");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this._logger.LogInformation("Worker running at: {0}", DateTimeOffset.Now);
                using (var scope = this._serviceProvider.CreateScope())
                {
                    var expService = scope.ServiceProvider.GetRequiredService<IMonitor>();
                    await expService.ExecuteAsync();

                    LogUtil.Write($"{DateTimeOffset.Now} Worker running.......,Count:{count}", "Base");
                    ++count;
                }

                await Task.Delay(30000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Worker stopping at: {0}", DateTimeOffset.Now);
            LogUtil.Write($"{DateTimeOffset.Now} Worker stopping.......", "Base");
            return base.StopAsync(cancellationToken);
        }
    }
}
