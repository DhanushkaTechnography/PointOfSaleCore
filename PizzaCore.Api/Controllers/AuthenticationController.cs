
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.Auth;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload;

namespace PizzaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("register_user")]
        public StatusCode UserRegistration([FromBody] UserRegisterModel model)
        {
            return _authService.RegisterUsers(model).Result;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var jwtSecurityToken = await _authService.CheckLogin(model);
            if (jwtSecurityToken != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    expiration = jwtSecurityToken.ValidTo,
                    User = model.Email
                });
            }
            return Unauthorized();
        }
    }
}