using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.AuthenticationDto
{
    public class LoginModel
    {
        public int Code { get; set; }
        public string Password { get; set; }
    }
}