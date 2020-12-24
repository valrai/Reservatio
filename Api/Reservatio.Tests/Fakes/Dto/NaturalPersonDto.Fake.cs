using System.Collections.Generic;
using Bogus;
using Reservatio.Data.Dto;
using Bogus.Extensions.Brazil;
using Reservatio.Data.Dto.Address;

namespace Reservatio.Tests.Fakes.Dto
{
    public static class NaturalPersonDtoFake
    {
        public static AddOrUpdateNaturalPersonDto AddNaturalPersonDto => GetNewNaturalPerson();

        private static AddOrUpdateNaturalPersonDto GetNewNaturalPerson()
        {
            var faker = new Faker("pt_BR");
            var password = faker.Internet.Password();

            return new AddOrUpdateNaturalPersonDto
            {
                Name = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Cpf = faker.Person.Cpf(),
                Rg = faker.Random.ReplaceNumbers("#########"),
                Phone = faker.Phone.PhoneNumber("+#############"),
                SecondaryPhone = faker.Phone.PhoneNumber("+#############"),
                Email = faker.Person.Email,
                UserId = faker.Random.Guid().ToString(),
                Password = password,
                PasswordConfirmation = password,
                Addresses = new List<AddOrUpdateAddressDto>
                {
                    AddressDtoFake.AddAddressDto
                }
            };
        }
    }
}
