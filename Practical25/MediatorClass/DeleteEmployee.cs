using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical25.Data;
using Practical25.Models;

namespace Practical25.MediatorClass
{
    public class DeleteEmployee : IRequest<Employee>
    {
        public int Id { get; set; }

        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, Employee>
        {
            private readonly AppDbContext _context;

            public DeleteEmployeeHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Employee> Handle(DeleteEmployee request, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
                if (employee is not null)
                {                    
                    employee.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    return employee;
                }
                return default;
            }
        }
    }
}
