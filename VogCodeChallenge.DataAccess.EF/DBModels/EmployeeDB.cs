using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.DataAccess.EF.DBModels
{
    public class EmployeeDB
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string MailingAddress { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
    }
}
