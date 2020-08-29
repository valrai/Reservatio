using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservatio.Data.Dto;
using Reservatio.Models;

namespace Reservatio.Services.Business.Customer
{
    public interface ICustomerService
    {
        Task<long> Register(NaturalPersonDto supplier);
        Task<NaturalPersonDto> Edit(NaturalPersonDto supplier);
        Task<NaturalPersonDto> Find(Expression<Func<NaturalPerson, bool>> filter = null);
        Task<IEnumerable<NaturalPersonDto>> List(Expression<Func<NaturalPerson, bool>> filter = null);
        Task<IActionResult> Delete(long id);
    }
}
