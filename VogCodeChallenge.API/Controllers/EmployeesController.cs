using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VogCodeChallenge.API.Tasks;
using VogCodeChallenge.Domain.EmployeeManagement;
using VogCodeChallenge.Domain.Services;

namespace VogCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeApiTask employeeApiTask;

        public EmployeesController(IEmployeeManagementService _employeeService)
        {
            employeeApiTask = new EmployeeApiTask(_employeeService);
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return employeeApiTask.GetAllEmployees();
        }

        [HttpGet]
        [Route("department/{departmentId}")]
        public IEnumerable<Employee> GetByDepartment(string departmentId)
        {
            return employeeApiTask.GetEmployeesByDepartment(departmentId);
        }
    }
}
