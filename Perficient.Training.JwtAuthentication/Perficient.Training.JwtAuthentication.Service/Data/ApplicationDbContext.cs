using Microsoft.EntityFrameworkCore;
using Perficient.Training.JwtAuthentication.Service.Enums;
using Perficient.Training.JwtAuthentication.Service.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Admin User",
                Email = "admin@example.com",
                Password = "admin",
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Manager,
                IsActiveRole = true
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Contributor User",
                Email = "contributor@example.com",
                Password = "contributor",
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Contributor,
                IsActiveRole = true
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "Reader User",
                Email = "reader@example.com",
                Password = "reader",
                CreatedAt = DateTime.UtcNow,
                Role = UserRole.Reader,
                IsActiveRole = true
            }
        );
    }
}
