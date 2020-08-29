using System.ComponentModel;

namespace Reservatio.Models
{
    public enum PaymentMethodType
    {
        [Description("Bank Slip")]
        BankSlip = 1,
        [Description("Mastercard Debit")]
        MastercardDebit = 2,
        [Description("Mastercard Credit")]
        MastercardCredit = 3,
        [Description("Visa Debit")]
        VisaDebit = 4,
        [Description("Visa Credit")]
        VisaCredit = 5
    }
}
