namespace VogCodeChallenge.Domain.EmployeeManagement
{
    public class Employee
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public Address MailingAddress { get; set; }
        public Department Department { get; set; }

        public Employee(string name, string lastName, string jobTitle, Address mailingAddress)
        {
            Name = name;
            LastName = lastName;
            JobTitle = jobTitle;
            MailingAddress = mailingAddress;
        }
    }
}
