using Reservatio.Models.Consts;
using Reservatio.Resources;
using System.ComponentModel.DataAnnotations;

namespace Reservatio.Data.Dto.Address
{
    public class AddOrUpdateAddressDto
    {
        #region Consts Validations

        public const short MAX_DISTRICT_LENGTH = 200;
        public const short MAX_STREET_LENGTH = 200;
        public const short MAX_COMPLEMENT_LENGTH = 400;

        #endregion

        public long? Id { get; set; }

        #region CEP Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[0-9]{8}$",
            ErrorMessageResourceName = ValidationMessages.CEP_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Cep { get; set; }

        public long StateId { get; set; }

        public long CityId { get; set; }

        #region District Validations

        [StringLength(MAX_DISTRICT_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string District { get; set; }

        #region Street Validations

        [StringLength(MAX_STREET_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Street { get; set; }

        public ushort? Number { get; set; }

        #region Complement Validations

        [StringLength(MAX_COMPLEMENT_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Complement { get; set; }

        public long? PersonId { get; set; }
    }
}
