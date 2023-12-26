using Microsoft.EntityFrameworkCore;
using PhoenixMerch.Core.DataAccess.EntityFramework;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        public List<Product> ProductWithCategory() => _set.Include(x => x.Category).ToList();
        public Product GetProductWithCategoryById(int id) => _set.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
    }
}
