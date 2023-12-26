using PhoenixMerch.Business.Abstract;
using PhoenixMerch.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        public ICategoryDal _categoryDal { get; set; }
        public CategoryManager(ICategoryDal categoryDal) => _categoryDal = categoryDal;
    }
}
