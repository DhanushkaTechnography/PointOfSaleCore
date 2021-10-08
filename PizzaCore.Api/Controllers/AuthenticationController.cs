
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PizzaCore.Business.Auth;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("register_user")]
        public bool UserRegistration([FromBody] NewEmployeeRequest model)
        {
            return _authService.EmployeeRegistration(model);
        }


        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public async Task<IActionResult> Login(int model)
        {
            Console.WriteLine(model);
            var jwtSecurityToken =  _authService.AccessFromEmployeeId(model);
            if (jwtSecurityToken != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    expiration = jwtSecurityToken.ValidTo,
                    User =  _authService.GetEmployeeByEmpId(model),
                });
            }
            return Unauthorized();
        }
    }
}