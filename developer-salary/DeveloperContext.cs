using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace developer_salary
{
    public class DeveloperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Developer> DevInfo { get; set; }


        public DeveloperContext (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Database"]);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .Property(d => d.Type)
                .HasConversion<string>(); // Store enum as string
        }
    }

}