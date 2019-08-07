using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace HCVisionWorker.Monitor
{
    public static class MonitorServiceExtensions
    {
        /// <summary>
        /// 添加监控器worker的service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMonitorServices(this IServiceCollection services)
        {
            services.AddScoped<IMonitor, ExperimentMonitor>();

            return services;
        }
    }
}
