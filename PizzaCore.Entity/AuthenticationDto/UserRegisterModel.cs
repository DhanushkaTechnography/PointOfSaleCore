using System.ComponentModel.DataAnnotations;

namespace PizzaCore.Entity.AuthenticationDto
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "User Name is required!")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "User Email is required!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        
        public string Role { get; set; }
    }
}