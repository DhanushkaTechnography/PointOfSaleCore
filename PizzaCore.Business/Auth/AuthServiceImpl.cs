using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaCore.Authentication;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaCore.Business.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        private readonly IAuthRepository _authRepository;

        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            this._configuration = configuration;
            _authRepository = authRepository;
        }

        public async Task<StatusCode> RegisterUsers(UserRegisterModel model)
        {
            if (_authRepository.IsUserNameExist(model.UserName).Result)
            {
                return new StatusCode(409, new Response
                {
                    Status = "Error", Message = "User Name Already Registered"
                });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            if (_authRepository.RegisterUser(user, model.Password).Result == null)
            {
                return new StatusCode(500,
                    new Response
                    {
                        Status = "Error",
                        Message =
                            "Sorry! We're having some technical difficulties with new registrations. Please try again later"
                    });
            }

            if (!await _authRepository.IsRoleExist(model.Role))
                await _authRepository.CreateNewRole(model.Role);
            await _authRepository.AddRoles(user, model.Role);

            return new StatusCode(200,
                new Response {Status = "Success", Message = "Registration Completed!"});
        }

        public async Task<JwtSecurityToken> CheckLogin(LoginModel model)
        {
            var byName = await _authRepository.GetUserByName(model.Email);
            if (byName != null)
            {
                var userRoles = await _authRepository.GetUserRoles(byName);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, byName.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(12),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
                return token;
            }
            return null;
        }
    }
}