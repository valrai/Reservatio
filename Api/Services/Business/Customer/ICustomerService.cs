using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Reservatio.Data.Dto;
using Reservatio.Models;

namespace Reservatio.Services.Business.Customer
{
    public interface ICustomerService
    {
        Task<long> Register(AddOrupdateNaturalPersonDto customer);
        Task<NaturalPersonDto> Edit(AddOrupdateNaturalPersonDto customer);
        Task<NaturalPersonDto> Find(Expression<Func<NaturalPerson, bool>> filter);
        Task<IEnumerable<NaturalPersonDto>> List(Expression<Func<NaturalPerson, bool>> filter = null);
        Task Delete(long id);
        Task CancelCustomer(long id);
    }
}
