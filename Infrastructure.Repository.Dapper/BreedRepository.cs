using POC.Core;
using POC.Core.Configuration;
using POC.Infrastructure.Repository.Dapper.Models;
using CoreModels = POC.Core.Models;
using AutoMapper;
using POC.Core.Repository;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace POC.Infrastructure.Repository.Dapper
{
    internal class BreedRepository : RepositoryBase, IBreedRepository
    {
        // private readonly ISettingsProvider _settingsProvider;
        private readonly IMapper _mapper;
        
        public BreedRepository(IDbTransaction transaction, IMapper mapper) : base(transaction)
        {
            // this._settingsProvider = settingsProvider;
               this._mapper = mapper;
        }


        //      IEnumerable<Aircraft> aircraft;

        // using (var connection = new SqlConnection(_connectionString))
        // {
        //     await connection.OpenAsync();

        //     aircraft = await connection.QueryAsync<Aircraft>("GetAircraftByModel",
        //                     new {Model = model}, 
        //                     commandType: CommandType.StoredProcedure);
        // }
        // return aircraft;

        public void Add(CoreModels.Breed entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CoreModels.Breed> All()
        {
            var breeds = Connection.Query<Breed>(
                "SELECT * FROM Breed",
                transaction: Transaction
            ).ToList();

            return _mapper.Map<List<CoreModels.Breed>>(breeds);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CoreModels.Breed entity)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public CoreModels.Breed Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public CoreModels.Breed FindByName(string name)
        {
            throw new System.NotImplementedException();
        }

        // public CoreModels.Employee Get()
        // {
        //     var e = new Models.Employee
        //     {
        //         First_Name = "Akash",
        //         Last_Name = "Yadav",
        //         Age = 10,
        //         Id = 1
        //     };
        //     var coreEmployee = this._mapper.Map<Models.Employee, CoreModels.Employee>(e);
        //     // var repoEmployee = this._mapper.Map<CoreModels.Employee, Models.Employee>(coreEmployee);
        //     return coreEmployee;
        // }

        // public string GetEmployee()
        // {
        //     return _settingsProvider.Get<string>(SettingKeys.WelcomeMessage);
        // }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Update(CoreModels.Breed entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
