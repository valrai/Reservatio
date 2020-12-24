namespace Reservatio.Data.Dto.Address
{
    public class AddressDto
    {
        public long Id { get; set; }

        public string Cep { get; set; }

        public long StateId { get; set; }

        public long CityId { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public ushort? Number { get; set; }

        public string Complement { get; set; }

        public long? PersonId { get; set; }
    }
}
