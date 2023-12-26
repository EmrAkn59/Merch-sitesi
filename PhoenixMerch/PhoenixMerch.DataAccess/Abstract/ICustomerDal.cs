using PhoenixMerch.Core.DataAccess.EntityFramework;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.DataAccess.Abstract
{
    public interface ICustomerDal : IRepository<Customer>
    {
    }
}
