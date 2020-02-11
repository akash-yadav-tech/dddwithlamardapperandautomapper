using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POC.Core;
using POC.Core.Models;
using Portal.Models;
using POC.Core.Logging;

namespace Portal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        private readonly ILoggingService _loggingService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper,ILoggingService loggingService)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
            this._loggingService = loggingService;
        }

        public IActionResult GetData()
        {
            _loggingService.Information("Get Data Called.");
            // _loggingService.ErrorAsync("Get error Data Called.");
            // _loggingService.Warning("Get warning Data Called.");
            return Ok(_mapper.Map<Models.Employee>(this._employeeService.Get()));
        }

        //  public IActionResult GetCats()
        // {
        //     // return Ok(this._employeeService.GetCats());
        // }

    }
}
