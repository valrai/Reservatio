namespace Reservatio.Models
{
    public class PaymentMethod
    {
        public float TotalValue;

        public ushort NumberInstallments = 1;

        public double Discount;

        public PaymentMethodType PaymentType;

        public float Change;

        public float ValueReceived;
    }
}
