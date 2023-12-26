using AutoMapper;
using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Business.ValidationRules.FluentValidation;
using PhoenixMerch.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public ICustomerDal _customerDal { get; set; }
        public IMapper _mapper { get; set; }

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        public CustomerValidator rules { get; set; } = new CustomerValidator();
    }
}
