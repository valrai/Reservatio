using AutoMapper;
using Reservatio.Data.Dto.Event;
using Reservatio.Models;

namespace Reservatio.Data.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, AddOrUpdateEventDto>();
            CreateMap<AddOrUpdateEventDto, Event>();
        }
    }
}
