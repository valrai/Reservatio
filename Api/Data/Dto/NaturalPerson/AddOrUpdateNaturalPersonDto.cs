using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reservatio.Data.Dto.Address;
using Reservatio.Models.Attributes;
using Reservatio.Models.Consts;
using Reservatio.Resources;

namespace Reservatio.Data.Dto
{
    public class AddOrUpdateNaturalPersonDto
    {
        #region Consts

        public const ushort MAX_NAME_LENGTH = 100;
        public const ushort MIN_NAME_LENGTH = 3;
        public const ushort MAX_LAST_NAME_LENGTH = 200;
        public const ushort MIN_LAST_NAME_LENGTH = 3;
        public const ushort MAX_PHONE_LENGTH = 20;
        public const ushort MIN_PHONE_LENGTH = 9;

        #endregion

        public long? Id { get; set; }

        public DateTime? CancellationDate { get; set; }

        #region Name Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$",
            ErrorMessageResourceName = ValidationMessages.ONLY_LETTERS_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [StringLength(MAX_NAME_LENGTH,
            MinimumLength = MIN_NAME_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Name { get; set; }

        #region Last Name Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$",
            ErrorMessageResourceName = ValidationMessages.ONLY_LETTERS_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [StringLength(MAX_LAST_NAME_LENGTH,
            MinimumLength = MIN_LAST_NAME_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string LastName { get; set; }

        #region CPF Validations

        [CpfValidation(ErrorMessageResourceName = ValidationMessages.CPF_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Cpf { get; set; }

        public string Rg { get; set; }

        #region Phone Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [StringLength(MAX_PHONE_LENGTH,
            MinimumLength = MIN_PHONE_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[+][0-9]*$",
            ErrorMessageResourceName = ValidationMessages.PHONE_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion
       
        public string Phone { get; set; }

        #region Secondary Phone Validations

        [StringLength(MAX_PHONE_LENGTH,
            MinimumLength = MIN_PHONE_LENGTH,
            ErrorMessageResourceName = ValidationMessages.LENGTH_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[+][0-9]*$",
            ErrorMessageResourceName = ValidationMessages.PHONE_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion
        
        public string SecondaryPhone { get; set; }

        public string UserId { get; set; }

        #region Email Validations 

        [EmailAddress(ErrorMessageResourceName = ValidationMessages.EMAIL_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string Email { get; set; }

        public string Password { get; set; }

        #region Password Confirmation Validations

        [Compare(nameof(Password),
            ErrorMessageResourceName = ValidationMessages.PASSWORD_CONFIRMATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]

        #endregion

        public string PasswordConfirmation { get; set; }

        public IEnumerable<AddOrUpdateAddressDto> Addresses { get; set; }
    }
}
