using AutoMapper;
using Reservatio.Data.Dto.NaturalPersonEvent;
using Reservatio.Models;

namespace Reservatio.Data.MappingProfiles
{
    public class NaturalPersonEventProfile : Profile
    {
        public NaturalPersonEventProfile()
        {
            CreateMap<NaturalPersonEvent, AddOrUpdateNaturalPersonEventDto>();
            CreateMap<AddOrUpdateNaturalPersonEventDto, NaturalPersonEvent>();
        }
    }
}
