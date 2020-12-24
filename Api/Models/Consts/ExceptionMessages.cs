using Reservatio.Resources;

namespace Reservatio.Models.Consts
{
    public static class ExceptionMessages
    {
        public const string NULL_ENTITIES_EXCEPTION = nameof(ExceptionMessagesResource_ptBR.Informed_entities_must_not_be_null_);
        public const string NOT_FOUND_EXCEPTION = nameof(ExceptionMessagesResource_ptBR.No_record_was_found_with_the_given_identifier_);
        public const string NULL_ENTITY_EXCEPTION = nameof(ExceptionMessagesResource_ptBR.The_informed_entity_must_not_be_null_);
        public const string NULL_FILTER_EXCEPTION = nameof(ExceptionMessagesResource_ptBR.You_must_enter_a_non_null_search_filter_);
        public const string INVALID_IDENTIFIER_EXCEPTION = nameof(ExceptionMessagesResource_ptBR.You_must_enter_a_positive_non_null_identifier_);
    }
}
