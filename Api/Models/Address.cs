namespace Reservatio.Models
{
    public class Address : Entity
    {
        private long NaturalPersonId { get; set; }

        public string Cep { get; set; }

        public string District { get; set; }

        public string Complement { get; set; }

        public NaturalPerson NaturalPerson { get; set; }

        public uint CityId { get; set; }

        public State State { get; set; }

        public ushort Number { get; set; }

        public City City { get; set; }

        public string Street { get; set; }
    }
}
