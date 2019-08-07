using HCVisionWorker.DataBase;
using HCVisionWorker.Services;
using HCVisionWorker.Services.IServices;
using HCVisionWorker.Monitor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HCVisionWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    var conn = hostContext.Configuration.GetConnectionString("Connection_SqlServer");
                    services.AddDbContext<DataBaseContext>(options =>
                    {
                        options.UseSqlServer(conn);
                    });

                    services.AddServiceServices();
                    services.AddMonitorServices();
                });
    }
}
