namespace Reservatio.Models
{
    public class NaturalPersonEvent : CancelableEntity
    {
        public long PersonId { get; set; }

        public long EventId { get; set; }

        public NaturalPerson Person { get; set; }

        public Event Event { get; set; }

        public RoleType Role { get; set; }
    }
}
