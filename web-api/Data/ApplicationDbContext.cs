using EmploymentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmploymentApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
    }
}
