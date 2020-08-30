using System.Collections.Generic;

namespace Reservatio.Models
{
    public class NaturalPerson : CancelableEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Phone { get; set; }

        public string SecondaryPhone { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<NaturalPersonEvent> NaturalPersonEvents { get; set; }
    }
}
