
namespace EmploymentApi.Models
{
    public enum DeveloperType
    {
        Junior,
        Intermediate,
        Senior,
        Lead
    }

    public class Developer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
        public int WorkedHours { get; set; }
        public decimal SalaryByHour { get; set; }
        public DeveloperType DeveloperType { get; set; }
        public string? Email { get; set; }
    }
}
