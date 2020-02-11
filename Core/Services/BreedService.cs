using System.Collections.Generic;
using POC.Core.Models;
using POC.Core.Repository;
using POC.Core.Logging;

namespace POC.Core.Services
{
    public class BreedService : IBreedService
    {
       // private readonly IBreedRepository _breedRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggingService _loggingService;
        public BreedService(IUnitOfWork unitOfWork, ILoggingService loggingService)
        {
            // this._breedRepository = breedRepository;
            this._unitOfWork = unitOfWork;
            this._loggingService = loggingService;
        }

        public IEnumerable<Breed> GetBreeds()
        {
           return _unitOfWork.BreedRepository.All();
        }

        Breed IBreedService.Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
