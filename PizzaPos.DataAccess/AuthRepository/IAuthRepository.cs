using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PizzaCore.Entity.AuthenticationDto;

namespace PizzaPos.DataAccess.AuthRepository
{
    public interface IAuthRepository
    {
        Employee CheckEmployeeId(int id);
        Employee SaveNewEmployee(Employee employee);
        EmployeeRole checkRole(int id);

        EmployeeRole SaveNewRole(EmployeeRole role);
    }
}