using System.Collections.Generic;

namespace Reservatio.Models
{
    public class PaymentMethod: LogicallyExcludableEntity
    {
        public float TotalValue { get; set; }

        public ushort NumberInstallments { get; set; } = 1;

        public double? Discount { get; set; }

        public float Change { get; set; }

        public float ValueReceived { get; set; }

        public PaymentMethodType PaymentType { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
