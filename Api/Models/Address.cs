using System.Collections.Generic;

namespace Reservatio.Models
{
    public class Address : Entity
    {
        public string Cep { get; set; }

        public long StateId { get; set; }

        public long CityId { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public ushort? Number { get; set; }

        public string Complement { get; set; }

        public long? PersonId { get; set; }

        public State State { get; set; }

        public City City { get; set; }

        public NaturalPerson Person { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
