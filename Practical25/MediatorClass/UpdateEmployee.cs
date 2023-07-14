using MediatR;
using Practical25.Data;
using Practical25.Models;

namespace Practical25.MediatorClass
{
    public class UpdateEmployee : IRequest<Employee>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public Department DepartmentId { get; set; }
        public bool DeleteStatus { get; set; }

        public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, Employee>
        {
            private readonly AppDbContext _context;
            public UpdateEmployeeHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(UpdateEmployee request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
                if (employee is not null)
                {
                    employee.Name = request.Name;
                    employee.Salary = request.Salary;
                    employee.Email = request.Email;
                    employee.DepartmentId = request.DepartmentId;
                    employee.IsDeleted = request.DeleteStatus;
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return default;
            }
        }
    }
}
