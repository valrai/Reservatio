using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservatio.Data.Dto;
using Reservatio.Models;

namespace Reservatio.Services.Business.Customer
{
    public class CustomerService : ICustomerService
    {
        public Task<long> Register(NaturalPersonDto supplier)
        {
            throw new NotImplementedException();
        }

        public Task<NaturalPersonDto> Edit(NaturalPersonDto supplier)
        {
            throw new NotImplementedException();
        }

        public Task<NaturalPersonDto> Find(Expression<Func<NaturalPerson, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NaturalPersonDto>> List(Expression<Func<NaturalPerson, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
