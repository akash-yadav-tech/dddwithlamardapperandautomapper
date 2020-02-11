using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POC.Core;
using Portal.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public HomeController(IEmployeeService employeeService, IMapper mapper)
        {
            this._employeeService = employeeService;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetData()
        {
            return Ok(_mapper.Map<Employee>(this._employeeService.Get()));
        }

    }
}
