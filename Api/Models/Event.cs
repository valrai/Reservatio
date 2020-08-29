using System;

namespace Reservatio.Models
{
    public class Event : LogicallyExcludableEntity
    {
        public NaturalPerson Professional { get; set; }

        public DateTime Date { get; set; }

        public long PlaceId { get; set; }

        public Address Place { get; set; }

        public long PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
