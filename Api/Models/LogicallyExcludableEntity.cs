using System;

namespace Reservatio.Models
{
    public abstract class LogicallyExcludableEntity : Entity
    {
        public DateTime? ExclusionDate { get; set; }
    }
}
