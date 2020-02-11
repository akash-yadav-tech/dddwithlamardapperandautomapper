using System.Collections.Generic;
using POC.Core.Models;
using POC.Core.Repository;
using POC.Core.Logging;

namespace POC.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggingService _loggingService;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, ILoggingService loggingService)
        {
            this._employeeRepository = employeeRepository;
            this._unitOfWork = unitOfWork;
            this._loggingService = loggingService;
        }
        public Employee Get()
        {
            this._loggingService.Information("Employee Service Called.");
            int a = 0;
            int b = 10/a;
            throw new System.Exception("Unhandled exception from employee service");
            //return this._employeeRepository.Get();
        }

        // public IEnumerable<Cat> GetCats()
        // {
        //     return this._unitOfWork.CatRepository.All();
        // }
    }
}
