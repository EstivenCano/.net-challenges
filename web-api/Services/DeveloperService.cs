using EmploymentApi.DTOs;
using EmploymentApi.Models;
using EmploymentApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmploymentApi.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer> GetByEmailAsync(string email);
        Task<IEnumerable<Developer>> SearchAsync(string firstName, string lastName, int? age, int? workedHours);
        Task AddAsync(DeveloperDto developerDto);
        Task UpdateAsync(int id, DeveloperDto developerDto);
        Task DeleteAsync(string email);
    }

    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _repository;

        public DeveloperService(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Developer> GetByEmailAsync(string email)
        {
            var developer = await _repository.GetByEmailAsync(email);
            if (developer == null)
            {
                throw new InvalidOperationException($"Developer with email {email} not found.");
            }
            return developer;
        }

        public async Task<IEnumerable<Developer>> SearchAsync(string firstName, string lastName, int? age, int? workedHours)
        {
            return await _repository.SearchAsync(firstName, lastName, age, workedHours);
        }

        public async Task AddAsync(DeveloperDto developerDto)
        {
            if (developerDto.DeveloperType == null)
            {
                throw new ArgumentException("Developer Type is required", nameof(developerDto.DeveloperType));
            }

            var developer = new Developer
            {
                FirstName = developerDto.FirstName,
                LastName = developerDto.LastName,
                Age = developerDto.Age,
                WorkedHours = developerDto.WorkedHours,
                SalaryByHour = developerDto.SalaryByHour,
                DeveloperType = Enum.Parse<DeveloperType>(developerDto.DeveloperType, true),
                Email = developerDto.Email
            };

            await _repository.AddAsync(developer);
        }

        public async Task UpdateAsync(int id,DeveloperDto developerDto)
        {
            if (developerDto.DeveloperType == null)
            {
                throw new ArgumentException("Developer Type is required", nameof(developerDto.DeveloperType));
            }

            var developer = new Developer
            {
                FirstName = developerDto.FirstName,
                LastName = developerDto.LastName,
                Age = developerDto.Age,
                WorkedHours = developerDto.WorkedHours,
                SalaryByHour = developerDto.SalaryByHour,
                DeveloperType = Enum.Parse<DeveloperType>(developerDto.DeveloperType, true),
                Email = developerDto.Email
            };

            await _repository.UpdateAsync(id, developer);
        }

        public async Task DeleteAsync(string email)
        {
            await _repository.DeleteAsync(email);
        }
    }
}
