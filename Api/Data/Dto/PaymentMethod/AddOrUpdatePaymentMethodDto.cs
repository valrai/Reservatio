using Reservatio.Models;
using Reservatio.Models.Consts;
using Reservatio.Resources;
using System.ComponentModel.DataAnnotations;

namespace Reservatio.Data.Dto.PaymentMethod
{
    public class AddOrUpdatePaymentMethodDto
    {
        public float TotalValue { get; set; }

        public ushort NumberInstallments { get; set; } = 1;

        public double? Discount { get; set; }

        public float Change { get; set; }

        public float ValueReceived { get; set; }

        #region Payment Method Validations

        [Required(ErrorMessageResourceName = ValidationMessages.REQUIRED_VALIDATION,
            ErrorMessageResourceType = typeof(ValidationMessagesResource_ptBR))]
        #endregion

        public PaymentMethodType PaymentType { get; set; }
    }
}
