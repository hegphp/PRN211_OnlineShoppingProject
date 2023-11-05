using Microsoft.AspNetCore.Mvc;
using Project.Services;

namespace Project.Controllers {
    public class CategoryController : Controller {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            return View();
        }

        public IActionResult GetProducts(int var) {
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = categoryService.GetProductsByCateId(var);
            ViewBag.Category = categoryService.GetCategoryById(var);
            return View(); 
        }
    }
}
