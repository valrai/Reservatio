using System;

namespace Reservatio.Models
{
    public class CancelableEntity : Entity  
    {
        public DateTime? CancellationDate { get; set; }
    }
}
