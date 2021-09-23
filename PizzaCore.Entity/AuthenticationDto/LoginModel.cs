using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.AuthenticationDto
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        public string Password { get; set; }
    }
}