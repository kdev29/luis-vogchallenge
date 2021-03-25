using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.Domain.EmployeeManagement;
using VogCodeChallenge.Domain.Services;

namespace VogCodeChallenge.API.Tasks
{
    public class EmployeeApiTask
    {
        private readonly IEmployeeManagementService employeeService;

        public EmployeeApiTask(IEmployeeManagementService service)
        {
            employeeService = service;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeService.GetAll();
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(string departmentName)
        {
            var allEmployees = employeeService.GetAll();

            return allEmployees.Where(emp => emp.DepartmentName == departmentName);
        }
    }
}
