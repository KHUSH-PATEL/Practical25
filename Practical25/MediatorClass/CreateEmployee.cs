using MediatR;
using Practical25.Data;
using Practical25.Models;

namespace Practical25.MediatorClass
{
    public class CreateEmployee : IRequest<Employee>
    {
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public Department DepartmentId { get; set; }


        public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, Employee>
        {
            private readonly AppDbContext _context;
            public CreateEmployeeHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(CreateEmployee request, CancellationToken cancellationToken)
            {
                var employee = new Employee { Name = request.Name, Salary = request.Salary, Email = request.Email, DepartmentId = request.DepartmentId };
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
        }
    }
}
