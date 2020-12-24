using AutoMapper;
using Reservatio.Data.Dto.PaymentMethod;
using Reservatio.Models;

namespace Reservatio.Data.MappingProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, AddOrUpdatePaymentMethodDto>();
            CreateMap<AddOrUpdatePaymentMethodDto, PaymentMethod>();
        }
    }
}
