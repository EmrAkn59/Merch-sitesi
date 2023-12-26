using Microsoft.AspNetCore.Mvc;
using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Entities.Concrete;

namespace PhoenixMerch.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Categories()
        {
            List<Category> categories = await _categoryService.GetCategoriesAllAsync();
            return View(categories);
        }
    }
}
