using EmploymentApi.DTOs;
using FluentValidation;
using EmploymentApi.Models;

namespace EmploymentApi.Validators
{
    public class DeveloperValidator : AbstractValidator<DeveloperDto>
    {
        public DeveloperValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .Length(3, 20).WithMessage("First Name must be between 3 and 20 characters");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .Length(3, 30).WithMessage("Last Name must be between 3 and 30 characters");

            RuleFor(d => d.Age)
                .GreaterThan(10).WithMessage("Age must be greater than 10");

            RuleFor(d => d.WorkedHours)
                .InclusiveBetween(30, 50).WithMessage("Worked Hours must be between 30 and 50");

            RuleFor(d => d.SalaryByHour)
                .GreaterThan(13).WithMessage("Salary by Hour must be greater than 13");

            RuleFor(d => d.DeveloperType)
                .NotEmpty().WithMessage("Developer Type is required")
                .Must(BeAValidDeveloperType).WithMessage("Invalid Developer Type");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email format");
        }

        private bool BeAValidDeveloperType(string developerType)
        {
            return Enum.TryParse(typeof(DeveloperType), developerType, true, out _);
        }
    }
}
