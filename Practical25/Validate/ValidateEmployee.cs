using FluentValidation;
using Practical25.Models;

namespace Practical25.Validate
{
    public class ValidateEmployee : AbstractValidator<Employee>
    {
        public ValidateEmployee()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Employee Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Employee Email is required").MinimumLength(6).MaximumLength(50).WithMessage("Email must be within 6 to 50 length");
            RuleFor(x => x.JoinDate).NotEmpty().WithMessage("Employee join date is required");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Employee salary is required").GreaterThan(0).WithMessage("Employee salary must be greater than 0");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Employee department id is required").IsInEnum().WithMessage("Department is invalid");
        }
    }
}
