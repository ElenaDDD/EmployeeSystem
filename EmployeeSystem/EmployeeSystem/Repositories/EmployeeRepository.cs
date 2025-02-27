using EmployeeSystem.Data;
using EmployeeSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
       private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeEntity = await _context.Employees.FindAsync(id);
            if (employeeEntity == null)
            {
                throw new KeyNotFoundException($"Employee with id : {id} was not found");
            }
            _context.Employees.Remove(employeeEntity); // Remove method is synchronous
            await _context.SaveChangesAsync(); // Save changes asynchronously
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return (Employee)await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee); // Update method is synchronous
            await _context.SaveChangesAsync();
        }
    }
}
