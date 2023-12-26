using PhoenixMerch.Core.DataAccess.EntityFramework;
using PhoenixMerch.DataAccess.Abstract;
using PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore.Context;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore
{
    public class OrderDal : RepositoryBase<Order>, IOrderDal
    {
        public OrderDal(PhoenixMerchContext context) : base(context)
        {
            
        }
    }
}
