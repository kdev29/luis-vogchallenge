using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VogCodeChallenge.DataAccess.EF;
using VogCodeChallenge.Domain.EmployeeManagement;
using VogCodeChallenge.Domain.Extensions;

namespace VogCodeChallenge.Domain.Services
{
    public class EmployeeManagementEFService : IEmployeeManagementService
    {
        private readonly EmployeeDBContext dBContext;

        public EmployeeManagementEFService()
        {
            dBContext = new EmployeeDBContext();
        }
        public IEnumerable<Employee> GetAll()
        {
            var employeesDB = dBContext.GetAllEmployeesFromDB();

            return employeesDB.Select(e => e.ToDomainObject());
        }

        public IList<Employee> ListAll()
        {
            return GetAll().ToList();
        }
    }
}
