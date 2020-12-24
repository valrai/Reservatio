using Reservatio.Data.Dto.Address;
using Reservatio.Data.Dto.PaymentMethod;
using Reservatio.Models.Attributes;
using System;

namespace Reservatio.Data.Dto.Event
{
    public class AddOrUpdateEventDto
    {
        public long? Id { get; set; }

        #region Date Validations

        [DateValidation]

        #endregion

        public DateTime Date { get; set; }

        public long? PlaceId { get; set; }

        public AddOrUpdateAddressDto Place { get; set; }

        public long PaymentMethodId { get; set; }

        public AddOrUpdatePaymentMethodDto PaymentMethod { get; set; }
    }
}
