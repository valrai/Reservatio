using System;

namespace Reservatio.Models
{
    public class LogicallyExcludableEntity : Entity
    {
        public DateTime? ExclusionDate { get; set; }
    }
}
