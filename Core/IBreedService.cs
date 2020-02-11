using System.Collections.Generic;
using POC.Core.Models;

namespace POC.Core
{
    public interface IBreedService
    {
        Breed Get();
        IEnumerable<Breed> GetBreeds();
    }
}
