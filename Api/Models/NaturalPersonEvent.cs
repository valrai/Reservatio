namespace Reservatio.Models
{
    public class NaturalPersonEvents : CancelableEntity
    {
        public long NaturalPersonId { get; set; }

        public NaturalPerson Person { get; set; }

        public long EventId { get; set; }

        public Event Event { get; set; }

        public RoleType Role { get; set; }
    }
}
