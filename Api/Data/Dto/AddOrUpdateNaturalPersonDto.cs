using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reservatio.Models;
using Reservatio.Models.Attributes;
using Reservatio.Models.Consts;
using Reservatio.Resources;

namespace Reservatio.Data.Dto
{
    public class AddOrupdateNaturalPersonDto
    {
        public long? Id { get; set; }

        [Display(Name = "Data de Cancelamento")]
        public DateTime? CancellationDate { get; set; }

        [Required(ErrorMessageResourceName = ValidationMessages.IsNecessaryInformAValueForTheField,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$",
            ErrorMessageResourceName = ValidationMessages.TheFieldMustContainOnlyLetters,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = ValidationMessages.IsNecessaryInformAValueForTheField,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$",
            ErrorMessageResourceName = ValidationMessages.TheFieldMustContainOnlyLetters,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string LastName { get; set; }

        [CpfValidation(ErrorMessageResourceName = ValidationMessages.TheInformedCpfIsInvalid,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string Cpf { get; set; }

        public string Rg { get; set; }

        [Required(ErrorMessageResourceName = ValidationMessages.IsNecessaryInformAValueForTheField,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        [RegularExpression(@"^[+][0-9]*$",
            ErrorMessageResourceName = ValidationMessages.TheFieldMustContainOnlyNumbers,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string Phone { get; set; }

        [RegularExpression(@"^[+][0-9]*$",
            ErrorMessageResourceName = ValidationMessages.TheFieldMustContainOnlyNumbers,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string SecondaryPhone { get; set; }

        public string UserId { get; set; }

        [EmailAddress(ErrorMessageResourceName = ValidationMessages.TheInformedEmailIsInvalid,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password),
            ErrorMessageResourceName = ValidationMessages.ThePasswordAndHisConfirmationMustBeEquals,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        public string PasswordConfirmation { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
