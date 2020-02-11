using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using POC.Core.Models;
using POC.Core.Repository;

namespace POC.Infrastructure.Repository.Dapper
{
    internal class CatRepository : RepositoryBase, ICatRepository
    {
        
        public CatRepository(IDbTransaction transaction, IMapper mapper) : base(transaction)
        {
        }

        public void Add(Cat entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cat> All()
        {
           return new List<Cat>(){ new Cat(){
               Age=10,
               BreedId=20,
               Id=1,
               Name="Marty"
           }};
        }

        public Cat Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cat> FindByBreedId(int breedId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cat entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cat entity)
        {
            throw new NotImplementedException();
        }
    }
}
