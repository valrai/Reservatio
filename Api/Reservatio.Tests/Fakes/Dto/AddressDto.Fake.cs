using Bogus;
using Reservatio.Data.Dto.Address;

namespace Reservatio.Tests.Fakes.Dto
{
    public static class AddressDtoFake
    {
        public static AddOrUpdateAddressDto AddAddressDto => GetNewAddress();

        private static AddOrUpdateAddressDto GetNewAddress()
        {
            var faker = new Faker("pt_BR");

            return new AddOrUpdateAddressDto
            {
                Cep = faker.Address.ZipCode("00000000"),
                StateId = 1,
                CityId = 1,
                PersonId = 1,
                District = faker.Name.FullName(),
                Street = faker.Address.StreetName(),
                Complement = faker.Address.SecondaryAddress(),
                Number = faker.Random.UShort()
            };
        }
    }
}
