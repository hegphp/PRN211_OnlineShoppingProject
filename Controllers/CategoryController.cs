using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers {
    public class CategoryController : Controller {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult GetProducts(int var) {
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = categoryService.GetProductsByCateId(var);
            ViewBag.Category = categoryService.GetCategoryById(var);
            return View(); 
        }

        [HttpPost]
        public IActionResult GetProducts(int var, string order) {
            ViewBag.CateList = categoryService.GetCategories();
            List<Product> productList = categoryService.GetProductsByCateId(var);
            if (order == "desc") {
                productList = productList.OrderByDescending(p => p.UnitPrice).ToList();
            }
            ViewBag.ProductList = productList;
            ViewBag.Category = categoryService.GetCategoryById(var);
            return View();
        }
    }
}
