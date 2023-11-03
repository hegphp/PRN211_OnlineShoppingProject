using Microsoft.AspNetCore.Mvc;
using Project.Services;

namespace Project.Controllers {
    public class HomeController : Controller {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            ViewBag.ProductList = productService.GetProducts();
            ViewBag.User = "Hello";
            ViewBag.CateList = categoryService.GetCategories();
            return View();
        }
    }
}
