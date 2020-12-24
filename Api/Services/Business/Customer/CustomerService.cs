using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Reservatio.Data.Dto;
using Reservatio.Data.Repositories;
using Reservatio.Models;
using Reservatio.Models.Exceptions;
using Reservatio.Resources;

namespace Reservatio.Services.Business.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<NaturalPerson> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<NaturalPerson> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Register(AddOrUpdateNaturalPersonDto customer)
        {
            return await _repository.Create(_mapper.Map<AddOrUpdateNaturalPersonDto, NaturalPerson>(customer));
        }

        public async Task<NaturalPersonDto> Edit(AddOrUpdateNaturalPersonDto customer)
        {
            var entity = await _repository.Update(_mapper.Map<AddOrUpdateNaturalPersonDto, NaturalPerson>(customer));
            return _mapper.Map<NaturalPerson, NaturalPersonDto>(entity);
        }

        public async Task<NaturalPersonDto> Find(Expression<Func<NaturalPerson, bool>> filter = null)
        {
            var customer = await _repository.Find(filter);

            return _mapper.Map<NaturalPerson, NaturalPersonDto>(customer);
        }

        public async Task<IEnumerable<NaturalPersonDto>> List(Expression<Func<NaturalPerson, bool>> filter = null)
        {
            var customers = await _repository.FindAll(filter);

            return _mapper.Map<IEnumerable<NaturalPerson>, IEnumerable<NaturalPersonDto>>(customers);
        }

        public async Task Delete(long id)
        {
             await _repository.Remove(id);
        }

        public async Task CancelCustomer(long id)
        {
            var customer = await _repository.Find(c => c.Id == id);

            if (customer == null)
                throw new EntityNotFoundException(ExceptionMessagesResource_ptBR.No_record_was_found_with_the_given_identifier_);

            customer.CancelationDate = DateTime.Now;
            await _repository.Update(customer);
        }
    }
}
