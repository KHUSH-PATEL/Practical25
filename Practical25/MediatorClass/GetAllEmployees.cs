using MediatR;
using Microsoft.EntityFrameworkCore;
using Practical25.Data;
using Practical25.Models;

namespace Practical25.MediatorClass
{
    public class GetAllEmployees : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesHanlder : IRequestHandler<GetAllEmployees, IEnumerable<Employee>>
        {
            private readonly AppDbContext _context;
            public GetAllEmployeesHanlder(AppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.Where(x=>x.IsDeleted == Convert.ToBoolean(0)).ToListAsync();
                return employees;
            }
        }
    }
}
