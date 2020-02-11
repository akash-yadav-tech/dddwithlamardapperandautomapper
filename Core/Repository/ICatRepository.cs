using System.Collections.Generic;
using POC.Core.Models;

namespace POC.Core.Repository
{
    public interface ICatRepository
    {
        void Add(Cat entity);
        IEnumerable<Cat> All();
        Cat Find(int id);
        IEnumerable<Cat> FindByBreedId(int breedId);
        void Remove(int id);
        void Remove(Cat entity);
        void Update(Cat entity);
    }
}
