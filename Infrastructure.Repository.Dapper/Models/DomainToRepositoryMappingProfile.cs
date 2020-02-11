using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CoreModels = POC.Core.Models;

namespace POC.Infrastructure.Repository.Dapper.Models
{
    public class DomainToRepositoryMappingProfile : Profile
    {
        public DomainToRepositoryMappingProfile()
        {
            CreateMap<Employee, CoreModels.Employee>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.First_Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Last_Name))
                .ReverseMap();

            CreateMap<Breed, CoreModels.Breed>();
            CreateMap<Cat, CoreModels.Cat>();
        }
    }
}
