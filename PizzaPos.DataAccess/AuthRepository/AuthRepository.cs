using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaCore.Entity.AuthenticationDto;

namespace PizzaPos.DataAccess.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee CheckEmployeeId(int id)
        {
            return _dbContext.Employees.Include(r => r.Role).First(employee => employee.EmployeeId == id);
        }

        public Employee SaveNewEmployee(Employee employee)
        {
            var entity = _dbContext.Add(employee).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public EmployeeRole checkRole(int id)
        {
            return _dbContext.EmployeeRoles.Find(id);
        }

        public EmployeeRole SaveNewRole(EmployeeRole role)
        {
            var entity = _dbContext.Add(role).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}