using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Reservatio.Data.Dto;
using Reservatio.Data.Repositories;
using Reservatio.Models;

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

        public async Task<long> Register(NaturalPersonDto customer)
        {
            return await _repository.Create(_mapper.Map<NaturalPersonDto, NaturalPerson>(customer));
        }

        public async Task<NaturalPersonDto> Edit(NaturalPersonDto customer)
        {
            var entity = await _repository.Update(_mapper.Map<NaturalPersonDto, NaturalPerson>(customer));
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
    }
}
