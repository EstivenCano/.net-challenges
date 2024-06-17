using System.ComponentModel.DataAnnotations;

namespace EmploymentApi.DTOs
{
    public class DeveloperDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public int WorkedHours { get; set; }

        [Required]
        public decimal SalaryByHour { get; set; }

        [Required]
        public string DeveloperType { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
