using AutoMapper;
using Portal.Models;
using CoreModels = POC.Core.Models;

namespace Portal.Models
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Employee, CoreModels.Employee>()
                .ReverseMap();
        }
    }
}
