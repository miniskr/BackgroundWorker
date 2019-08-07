using HCVisionWorker.Services.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace HCVisionWorker.Services
{
    public static class ServicesServiceExtensions
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IExperimentTaskService, ExperimentTaskService>();

            return services;
        }
    }
}
