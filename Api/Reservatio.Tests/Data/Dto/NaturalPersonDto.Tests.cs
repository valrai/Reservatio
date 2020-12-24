using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bogus;
using Bogus.Extensions.Brazil;
using Reservatio.Data.Dto;
using Reservatio.Resources;
using Reservatio.Tests.Fakes.Dto;
using Xunit;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Reservatio.Tests.Data.Dto
{
    public class NaturalPersonDto
    {

        #region Test Cases Data

        public static IEnumerable<object[]> GetNamesData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { faker.Random.Replace("##??#?##???#"), false },
                new object[] { faker.Random.ReplaceNumbers("#######").ToString(), false },

                new object[] { faker.Name.FirstName(), true }
            };
        }

        public static IEnumerable<object[]> GetLastNamesData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { faker.Random.AlphaNumeric(5), false },
                new object[] { faker.Random.ReplaceNumbers("#######").ToString(), false },

                new object[] { faker.Name.LastName(), true }
            };
        }

        public static IEnumerable<object[]> GetCpfData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { faker.Random.AlphaNumeric(11), false },
                new object[] { faker.Random.Word(), false },
                new object[] { faker.Random.ReplaceNumbers("############").ToString(), false },
                new object[] { faker.Random.ReplaceNumbers("##########").ToString(), false },

                new object[] { faker.Person.Cpf(), true }
            };
        }

        public static IEnumerable<object[]> GetPhoneLengthData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { faker.Phone.PhoneNumber("+###"), false },
                new object[] { faker.Phone.PhoneNumber("+#########################"), false },

                new object[] { faker.Phone.PhoneNumber("+#############"), true }
            };
        }

        public static IEnumerable<object[]> GetRequiredPhoneData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { null, false },
                new object[] { string.Empty, false },

                new object[] { faker.Phone.PhoneNumber("+#############"), true }
            };
        }

        public static IEnumerable<object[]> GetValidationPhoneData()
        {
            var faker = new Faker("pt_BR");

            return new List<object[]>
            {
                new object[] { '+' + faker.Random.Replace("###???##?##"), false },
                new object[] { faker.Phone.PhoneNumber("#############"), false },
                new object[] { "12.456@8$0", false },

                new object[] { faker.Phone.PhoneNumber("+#############"), true }
            };
        }

        #endregion


        [Theory]
        [MemberData(nameof(GetNamesData))]
        public void Person_Name_Must_Have_Only_Letters(string name, bool isValidCase)
        {
            //Arrange
            const string FIELD_NAME = nameof(AddOrUpdateNaturalPersonDto.Name);

            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage = 
                string.Format(ValidationMessagesResource_ptBR.The_field__0__must_contain_only_letters_, FIELD_NAME);
            person.Name = name;

            //Act
            var isValid = Validator.TryValidateProperty(person.Name,
                new ValidationContext(person) { MemberName = FIELD_NAME },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }

        [Theory]
        [MemberData(nameof(GetLastNamesData))]
        public void Person_Last_Name_Must_Have_Only_Letters(string lastName, bool isValidCase)
        {
            //Arrange
            const string FIELD_NAME = nameof(AddOrUpdateNaturalPersonDto.LastName);

            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage =
                string.Format(ValidationMessagesResource_ptBR.The_field__0__must_contain_only_letters_, FIELD_NAME);
            person.LastName = lastName;

            //Act
            var isValid = Validator.TryValidateProperty(person.LastName,
                new ValidationContext(person) { MemberName = FIELD_NAME },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }

        [Theory]
        [MemberData(nameof(GetCpfData))]
        public void Person_Must_Have_a_Valid_Cpf(string cpf, bool isValidCase)
        {
            //Arrange
            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage = ValidationMessagesResource_ptBR.The_informed_CPF_is_invalid_;

            person.Cpf = cpf;

            //Act
            var isValid = Validator.TryValidateProperty(person.Cpf,
                new ValidationContext(person) { MemberName = nameof(AddOrUpdateNaturalPersonDto.Cpf) },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }

        [Theory]
        [MemberData(nameof(GetRequiredPhoneData))]
        public void Person_Must_Have_a_Phone(string phone, bool isValidCase)
        {
            //Arrange
            const string FIELD_NAME = nameof(AddOrUpdateNaturalPersonDto.Phone);

            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage = 
                string.Format(ValidationMessagesResource_ptBR.Is_necessary_inform_a_value_for_the_field__0__, FIELD_NAME);

            person.Phone = phone;

            //Act
            var isValid = Validator.TryValidateProperty(person.Phone,
                new ValidationContext(person) { MemberName = FIELD_NAME },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }

        [Theory]
        [MemberData(nameof(GetPhoneLengthData))]
        public void Person_Phone_Must_Have_a_Valid_Length(string phone, bool isValidCase)
        {
            //Arrange
            const string FIELD_NAME = nameof(AddOrUpdateNaturalPersonDto.Phone);

            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage = 
                string.Format(ValidationMessagesResource_ptBR
                        .The_field__0__must_contain_at_least___2__and_at_most__1__characters_,
                    FIELD_NAME,
                    AddOrUpdateNaturalPersonDto.MAX_PHONE_LENGTH,
                    AddOrUpdateNaturalPersonDto.MIN_PHONE_LENGTH);

            person.Phone = phone;

            //Act
            var isValid = Validator.TryValidateProperty(person.Phone,
                new ValidationContext(person) { MemberName = FIELD_NAME },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }

        [Theory]
        [MemberData(nameof(GetValidationPhoneData))]
        public void Person_Must_Have_a_Valid_Phone(string phone, bool isValidCase)
        {
            //Arrange
            const string FIELD_NAME = nameof(AddOrUpdateNaturalPersonDto.Phone);

            var result = new List<ValidationResult>();
            var person = NaturalPersonDtoFake.AddNaturalPersonDto;
            var errorMessage = 
                string.Format(ValidationMessagesResource_ptBR.The_informed_phone_is_invalid_, FIELD_NAME);

            person.Phone = phone;

            //Act
            var isValid = Validator.TryValidateProperty(person.Phone,
                new ValidationContext(person) { MemberName = FIELD_NAME },
                result);

            //Assert
            if (isValidCase)
            {
                Assert.True(isValid);
                Assert.Empty(result);
            }
            else
            {
                Assert.False(isValid);
                Assert.Single(result);
                Assert.Equal(errorMessage, result[0].ErrorMessage);
            }
        }
    }
}
