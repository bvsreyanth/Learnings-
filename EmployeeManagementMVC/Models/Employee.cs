using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Designation { get; set; }

        public required DateTime DOJ { get; set; }

        public required decimal Salary { get; set; }

        public required string Gender { get; set; }

        public required string State { get; set; }

    }
}
