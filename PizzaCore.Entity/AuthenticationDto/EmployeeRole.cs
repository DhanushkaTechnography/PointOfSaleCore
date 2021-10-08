using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaCore.Entity.AuthenticationDto
{
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}