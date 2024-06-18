using CityTimePrinter.Models;
using Microsoft.EntityFrameworkCore;

namespace CityTimePrinter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
