using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PizzaCore.Authentication;
using PizzaCore.Entity.AuthenticationDto;

namespace PizzaPos.DataAccess.AuthRepository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(ApplicationUser userDto, string password);
        Task<bool> CreateNewRole(string role);
        Task<IdentityResult> AddRoles(ApplicationUser user, string role);
        Task<ApplicationUser> GetUserByName(string name);
        Task<IList<string>> GetUserRoles(ApplicationUser user);
        Task<bool> IsUserNameExist(string userName);
        Task<bool> IsRoleExist(string role);
    }
}