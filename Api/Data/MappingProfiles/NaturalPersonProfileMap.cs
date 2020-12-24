using AutoMapper;
using Reservatio.Data.Dto;

namespace Reservatio.Data.MappingProfiles
{
    public class NaturalPersonProfileMap : Profile
    {
        public NaturalPersonProfileMap()
        {
            CreateMap<NaturalPersonDto, Models.NaturalPerson>();
            CreateMap<Models.NaturalPerson, NaturalPersonDto>();

            CreateMap<AddOrUpdateNaturalPersonDto, Models.NaturalPerson>();
            CreateMap<Models.NaturalPerson, AddOrUpdateNaturalPersonDto>();
        }
    }
}
