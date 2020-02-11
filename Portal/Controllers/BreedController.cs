using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POC.Core;
using POC.Core.Models;
using Portal.Models;
using POC.Core.Logging;

namespace Portal.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedService _breedService;
        private readonly IMapper _mapper;

        private readonly ILoggingService _loggingService;
        public BreedController(IBreedService breedService, IMapper mapper,ILoggingService loggingService)
        {
            this._breedService = breedService;
            this._mapper = mapper;
            this._loggingService = loggingService;
        }

        public IActionResult GetBreeds()
        {
            _loggingService.Information("Get Breeds Called.");
            // _loggingService.ErrorAsync("Get error Data Called.");
            // _loggingService.Warning("Get warning Data Called.");
            return Ok(this._breedService.GetBreeds());
        }

        //  public IActionResult GetCats()
        // {
        //     return Ok(this._employeeService.GetCats());
        // }

    }
}
