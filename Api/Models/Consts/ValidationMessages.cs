using Reservatio.Resources;

namespace Reservatio.Models.Consts
{
    public static class ValidationMessages
    {
        public const string ONLY_LETTERS_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_field__0__must_contain_only_letters_);
        public const string REQUIRED_VALIDATION = nameof(ValidationMessagesResource_ptBR.Is_necessary_inform_a_value_for_the_field__0__);
        public const string CPF_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_informed_CPF_is_invalid_);
        public const string ONLY_NUMBERS_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_field__0__must_contain_only_numbers_);
        public const string EMAIL_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_informed_Email_is_invalid_);
        public const string PASSWORD_CONFIRMATION = nameof(ValidationMessagesResource_ptBR.The_password_and_his_confirmation_must_be_equals_);
        public const string LENGTH_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_field__0__must_contain_at_least___2__and_at_most__1__characters_);
        public const string PHONE_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_informed_phone_is_invalid_);
        public const string CEP_VALIDATION = nameof(ValidationMessagesResource_ptBR.The_informed_CEP_is_invalid_);
    }
}
