using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaCore.Entity.AuthenticationDto
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Employee ID is required!")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName{ get; set; }

        public EmployeeRole Role { get; set; }

        public Employee()
        {
        }

        public Employee(int employeeId = default, string firstName = null, string lastName = null)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}