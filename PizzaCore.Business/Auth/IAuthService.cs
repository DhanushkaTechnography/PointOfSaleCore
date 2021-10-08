using System.IdentityModel.Tokens.Jwt;
using PizzaCore.Entity.AuthenticationDto;
using PizzaCore.Entity.Payload.requests;

namespace PizzaCore.Business.Auth
{
    public interface IAuthService
    {
        bool EmployeeRegistration(NewEmployeeRequest employee);
        JwtSecurityToken AccessFromEmployeeId(int id);

        Employee GetEmployeeByEmpId(int id);
    }
}