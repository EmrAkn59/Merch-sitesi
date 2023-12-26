using AutoMapper;
using FluentValidation.Results;
using PhoenixMerch.Business.ValidationRules.FluentValidation;
using PhoenixMerch.DataAccess.Abstract;
using PhoenixMerch.Entities.Concrete;
using PhoenixMerch.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Abstract
{
    public interface ICustomerService
    {
        ICustomerDal _customerDal { get; set; }
        IMapper _mapper { get; set; }
        CustomerValidator rules { get; set; }
        public ValidationResult Validator(Customer customer)
        {
            return rules.Validate(customer);
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerDal.GetAsync(x => x.Id == id);
        }

        public async Task<IList<Customer>> CustomerListByName(string customerName)
        {
            return await _customerDal.GetAllAsync(x => x.FirstName == customerName);
        }

        public async Task<IList<Customer>> CustomerList()
        {
            return await _customerDal.GetAllAsync();
        }

        public async Task<IList<Customer>> CustomerListByState(bool customerState)
        {
            return await _customerDal.GetAllAsync(x => x.Status == customerState);
        }

        public async Task CustomerAdd(CustomerDto customerDto)
        {

            Customer customer = _mapper.Map<Customer>(customerDto);
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.AddAsync(customer);
            }

        }

        public async Task CustomerUpdate(Customer customer)
        {
            var result = Validator(customer);
            if (result.IsValid)
            {
                await _customerDal.AddAsync(customer);
            }
        }

        public async Task CustomerDelete(int customerId)
        {
            var customer = await GetCustomerById(customerId);
            await _customerDal.RemoveAsync(customer);
        }
    }
}
