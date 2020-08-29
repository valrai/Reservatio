using System.Collections.Generic;

namespace Reservatio.Models
{
    public class State : LogicallyExcludableEntity
    {
        public string Name { get; set; }

        public string StateAbbreviation { get; set; }

        public Region Region { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
