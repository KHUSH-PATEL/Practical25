using Microsoft.EntityFrameworkCore;
using Practical25.Models;

namespace Practical25.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        public DbSet<Employee> Employees { get; set; }        
    }
}
