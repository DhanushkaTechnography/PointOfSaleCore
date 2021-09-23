using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload;
using Microsoft.AspNetCore.Mvc;

namespace PizzaCore.Business.Auth
{
    public interface IAuthService
    {
        Task<StatusCode> RegisterUsers(UserRegisterModel model);
        Task<JwtSecurityToken> CheckLogin(LoginModel model);
    }
}