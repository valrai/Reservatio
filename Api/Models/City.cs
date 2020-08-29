using System.Collections.Generic;

namespace Reservatio.Models
{
    public class City : LogicallyExcludableEntity
    {
        public string Name { get; set; }

        public long Code { get; set; }

        public long StateId { get; set; }

        public string StateAbbreviation { get; set; }

        public State State { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
