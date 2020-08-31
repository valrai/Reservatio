using AutoMapper;
using Reservatio.Data.Dto;

namespace Reservatio.Data.MappingProfiles.NaturalPerson
{
    public class NaturalPersonProfileMap : Profile
    {
        public NaturalPersonProfileMap()
        {
            CreateMap<NaturalPersonDto, Models.NaturalPerson>();
            CreateMap<Models.NaturalPerson, NaturalPersonDto>();

            CreateMap<AddOrupdateNaturalPersonDto, Models.NaturalPerson>();
            CreateMap<Models.NaturalPerson, AddOrupdateNaturalPersonDto>();
        }
    }
}
