using EmployeeSystem.Models;
using EmployeeSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace EmployeeSystem.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository= employeeRepository;
        }
        [HttpPost] 
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return Created();
        }
    }
}
