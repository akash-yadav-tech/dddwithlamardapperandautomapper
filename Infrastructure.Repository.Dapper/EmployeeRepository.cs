using POC.Core;
using POC.Core.Configuration;
using POC.Infrastructure.Repository.Dapper.Models;
using CoreModels = POC.Core.Models;
using AutoMapper;
using POC.Core.Logging;

namespace POC.Infrastructure.Repository.Dapper
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly IMapper _mapper;

        private readonly ILoggingService _loggingService;
        public EmployeeRepository(ISettingsProvider settingsProvider, IMapper mapper, ILoggingService loggingService)
        {
            this._settingsProvider = settingsProvider;
            this._mapper = mapper;
            this._loggingService = loggingService;
        }
        public CoreModels.Employee Get()
        {
            this._loggingService.Information("Repo Get Called");
            var e = new Models.Employee
            {
                First_Name = "Akash",
                Last_Name = "Yadav",
                Age = 10,
                Id = 1
            };
            var coreEmployee = this._mapper.Map<Models.Employee, CoreModels.Employee>(e);
            // var repoEmployee = this._mapper.Map<CoreModels.Employee, Models.Employee>(coreEmployee);
            return coreEmployee;
        }

        public string GetEmployee()
        {
            return _settingsProvider.Get<string>(SettingKeys.WelcomeMessage);
        }
    }
}
