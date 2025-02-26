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

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            var employeeEntity = await _context.Employees.FindAsync(employee.Id);
            if (employeeEntity == null)
            {
                throw new KeyNotFoundException($"Employee with id : {employee.Id} was not found");
            }
            _context.Employees.Remove(employee); // Remove method is synchronous
            await _context.SaveChangesAsync(); // Save changes asynchronously
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee?>> GetByIdAsync(int id)
        {
            return (IEnumerable<Employee>)await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee); // Update method is synchronous
            await _context.SaveChangesAsync();
        }
    }
}
