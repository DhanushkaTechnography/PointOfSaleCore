using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PizzaCore.Authentication;
using PizzaCore.Entity.AuthenticationDto;

namespace PizzaPos.DataAccess.AuthRepository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<bool> CreateNewRole(string role)
        {
           await _roleManager.CreateAsync(new IdentityRole(role));
           return true;
        }

        public async Task<IdentityResult> AddRoles(ApplicationUser user, string role)
        {
           return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByName(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null;
        }

        public async Task<bool> IsRoleExist(string role)
        {
            return await _roleManager.FindByNameAsync(role) != null;
        }
    }
}