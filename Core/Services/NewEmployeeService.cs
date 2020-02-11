using System.Collections.Generic;
using POC.Core.Models;

namespace POC.Core.Services
{
    public class NewEmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public NewEmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public Employee Get()
        {
            var employee = new Employee
            {
                FirstName = this._employeeRepository.GetEmployee()
            };
            return employee;
        }

        public IEnumerable<Cat> GetCats()
        {
            throw new System.NotImplementedException();
        }
    }
}
