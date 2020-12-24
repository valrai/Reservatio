using System;
using System.Collections.Generic;
using Reservatio.Data.Dto.Address;

namespace Reservatio.Data.Dto
{
    public class NaturalPersonDto
    {
        public long Id { get; set; }

        public DateTime? CancellationDate { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Phone { get; set; }

        public string SecondaryPhone { get; set; }

        public string UserId { get; set; }

        public IEnumerable<AddressDto> Addresses { get; set; }
    }
}
