using CityTimePrinter.Data;
using CityTimePrinter.HostedServices;
using CityTimePrinter.Services;
using CityTimePrinter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=cities.db"));

        services.AddTransient<ITimeService, TimeService>();
        services.AddHostedService<CityTimePrinterService>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();

    // Seed the database with initial data
    if (!dbContext.Cities.Any())
    {
        dbContext.Cities.AddRange(new[]
        {
            new City { Name = "Bogota", TimeZone = "America/Bogota" },
            new City { Name = "Chicago", TimeZone = "America/Chicago" },
            new City { Name = "Argentina", TimeZone = "America/Argentina/Buenos_Aires" },
            new City { Name = "Detroit", TimeZone = "America/Detroit" },
            new City { Name = "London", TimeZone = "Europe/London" }
        });
        dbContext.SaveChanges();
    }
}

using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (sender, e) =>
{    
    Console.WriteLine("Background service completed.");
    cts.Cancel();
};

await host.RunAsync(cts.Token);
