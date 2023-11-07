using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers { 
    using Models;
    using Services;
    public class ProductController : Controller {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            return View();
        }

        public IActionResult Info(int var) {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.Product = productService.GetProductById(var);
            return View();
        }

        public IActionResult Search(string productName) {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = productService.searchProducts(productName);
            return View();
        }
    }
}
