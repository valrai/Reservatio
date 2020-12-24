using AutoMapper;
using Reservatio.Data.Dto.Address;
using Reservatio.Models;

namespace Reservatio.Data.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Address, AddOrUpdateAddressDto>();
            CreateMap<AddOrUpdateAddressDto, Address>();
        }
    }
}
