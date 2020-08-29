using System;
using System.Collections.Generic;

namespace Reservatio.Models
{
    public class Event : LogicallyExcludableEntity
    {
        public DateTime Date { get; set; }

        public long? PlaceId { get; set; }

        public Address Place { get; set; }

        public long PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<NaturalPersonEvent> NaturalPersonEvents { get; set; }
    }
}
