using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical25.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public string? Email { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;

        public Department DepartmentId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
