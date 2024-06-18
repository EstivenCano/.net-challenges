using CityTimePrinter.Data;
using CityTimePrinter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityTimePrinter.HostedServices
{
    public class CityTimePrinterService : BackgroundService
    {
     
        private readonly IServiceProvider _serviceProvider;

        public CityTimePrinterService( IServiceProvider serviceProvider)
        {            
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("CityTimePrinterService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var timeService = scope.ServiceProvider.GetRequiredService<ITimeService>();

                    var cities = await dbContext.Cities.ToListAsync();

                    foreach (var city in cities)
                    {
                        var currentTime = timeService.GetCurrentTime(city.TimeZone);
                        Console.WriteLine($"City: {city.Name}");
                        Console.WriteLine($"TimeZone: {city.TimeZone}");
                        Console.WriteLine($"Time: {currentTime:yyyy-MM-dd'T'HH:mm:ss.FFFo<g>}");
                        Console.WriteLine();
                    }
                }

                await Task.Delay(30000, stoppingToken);
            }                     
        }
    }
}
