using Microsoft.EntityFrameworkCore;
using EmployeeSystem.Models;

namespace EmployeeSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
