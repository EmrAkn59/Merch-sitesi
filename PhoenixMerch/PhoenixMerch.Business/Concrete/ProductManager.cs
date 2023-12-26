using PhoenixMerch.Business.Abstract;
using PhoenixMerch.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IProductDal _productDal { get; set; }
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
    }
}
