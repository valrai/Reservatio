using System;

namespace Reservatio.Models
{
    public abstract class CancelableEntity : Entity  
    {
        public DateTime? CancellationDate { get; set; }
    }
}
