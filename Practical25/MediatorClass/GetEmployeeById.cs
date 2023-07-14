using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical25.Data;
using Practical25.Models;

namespace Practical25.MediatorClass
{
    public class GetEmployeeById : IRequest<Employee>
    {
        public int Id { get; set; }
        public class GetAllEmployeesHanlder : IRequestHandler<GetEmployeeById, Employee?>
        {
            private readonly AppDbContext _context;
            public GetAllEmployeesHanlder(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Employee?> Handle(GetEmployeeById request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.Where(x => x.IsDeleted == Convert.ToBoolean(0)).FirstOrDefaultAsync(emp => emp.Id == request.Id);
                return employee;
            }
        }
    }
}