using Reservatio.Data.Dto.Event;
using Reservatio.Models;
using Reservatio.Models.Consts;
using Reservatio.Resources;
using System.ComponentModel.DataAnnotations;

namespace Reservatio.Data.Dto.NaturalPersonEvent
{
    public class AddOrUpdateNaturalPersonEventDto
    {
        public long PersonId { get; set; }

        public long EventId { get; set; }

        public AddOrUpdateNaturalPersonDto Person { get; set; }

        public AddOrUpdateEventDto Event { get; set; }

        #region Role Type Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        #endregion

        public RoleType Role { get; set; }
    }
}
 