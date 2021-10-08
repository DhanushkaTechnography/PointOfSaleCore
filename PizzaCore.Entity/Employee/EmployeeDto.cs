using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.Employee
{
    public class EmployeeDto
    {
        [Key]
        public int EmployeeId { get; set; }
        
        public string EmployeeName { get; set; }
        public string EmployeeCreatedDate { get; set; }
        public string EmployeeUpdatedDate { get; set; }
        public int EmployeeStatus { get; set; }
    }
}