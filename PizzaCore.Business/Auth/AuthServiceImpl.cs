using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload.requests;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaCore.Business.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        private readonly IAuthRepository _authRepository;

        public AuthService(IConfiguration configuration, IAuthRepository authRepository, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            _authRepository = authRepository;
        }

        public bool EmployeeRegistration(NewEmployeeRequest employee)
        {
            Employee employee1 = new Employee(employee.EmployeeId, employee.FirstName, employee.LastName);
            employee1.Role = getEmployeeRole(employee.Role);
            return _authRepository.SaveNewEmployee(employee1) != null;
        }
        private EmployeeRole getEmployeeRole(int employeeRole)
        {
            var role = _authRepository.checkRole(employeeRole);
            if (role == null)
            {
                role = new EmployeeRole();
                role.Id = employeeRole;
                role.Name = employeeRole switch
                {
                    1 => UserRoles.SuperAdmin,
                    2 => UserRoles.Admin,
                    3 => UserRoles.Manager,
                    4 => UserRoles.Cashier,
                    5 => UserRoles.Driver,
                    6 => UserRoles.Customer,
                    _ => role.Name
                };
                return _authRepository.SaveNewRole(role);
            }
            return role;
        }
        
        public JwtSecurityToken AccessFromEmployeeId(int id)
        {
            var employee = _authRepository.CheckEmployeeId(id);
            if (employee !=null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, employee.FirstName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                authClaims.Add(new Claim(ClaimTypes.Role,employee.Role.Name));
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

        public Employee GetEmployeeByEmpId(int id)
        {
            return _authRepository.CheckEmployeeId(id);
        }
    }
}