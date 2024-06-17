using EmploymentApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmploymentApi.Data;

namespace EmploymentApi.Repositories
{

    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer> GetByEmailAsync(string email);
        Task<IEnumerable<Developer>> SearchAsync(string firstName, string lastName, int? age, int? workedHours);
        Task AddAsync(Developer developer);       
        Task UpdateAsync(int id, Developer developer);
        Task DeleteAsync(string email);
    }

    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task<Developer> GetByEmailAsync(string email)
        {
            var developer = await _context.Developers.FirstOrDefaultAsync(d => d.Email == email);
            if (developer == null)
            {
                throw new InvalidOperationException($"Developer with email {email} not found.");
            }
            return developer;
        }

        public async Task<IEnumerable<Developer>> SearchAsync(string firstName, string lastName, int? age, int? workedHours)
        {
            var query = _context.Developers.AsQueryable();

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(d => d.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(d => d.LastName.Contains(lastName));

            if (age.HasValue)
                query = query.Where(d => d.Age == age.Value);

            if (workedHours.HasValue)
                query = query.Where(d => d.WorkedHours == workedHours.Value);

            return await query.ToListAsync();
        }

        public async Task AddAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Developer updatedDeveloper)
        {
            var existingDeveloper = await _context.Developers.FindAsync(id);
            if (existingDeveloper != null)
            {
                existingDeveloper.FirstName = updatedDeveloper.FirstName;
                existingDeveloper.LastName = updatedDeveloper.LastName;
                existingDeveloper.Age = updatedDeveloper.Age;
                existingDeveloper.WorkedHours = updatedDeveloper.WorkedHours;
                existingDeveloper.SalaryByHour = updatedDeveloper.SalaryByHour;
                existingDeveloper.DeveloperType = updatedDeveloper.DeveloperType;
                existingDeveloper.Email = updatedDeveloper.Email;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string email)
        {
            var developer = await GetByEmailAsync(email);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
