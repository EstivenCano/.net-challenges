using developer_salary;
using Microsoft.Extensions.Configuration;


// Exercise: 1 - Read data from CSV File

Console.WriteLine("Read data from CSV File");

var csvDevelopers = FileReader.ReadDevelopersFromCsv("developers.csv");

Printer.PrintDevelopers(csvDevelopers);

/*-----------------------------------------------------------------------------------------------*/
Console.WriteLine("\n/*-----------------------------------------------------------------------------------------------*/\n");

// Exercise: 2 - Read data from Database

Console.WriteLine("Read data from Database");

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration config = builder.Build();

using (var context = new DeveloperContext(config))
{
    var dbDevelopers = context.DevInfo.ToList();

    Printer.PrintDevelopers(dbDevelopers);
}