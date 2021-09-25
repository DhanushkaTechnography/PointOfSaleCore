using PizzaPos.DataAccess.EmployeeRepository;

namespace PizzaCore.Business.EmployeeService
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}