using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers { 
    using Models;
    using Services;
    public class ProductController : Controller {
        ProductService productService = new ProductService();
        public IActionResult Index() {
            return View();
        }

        public IActionResult Info(int var) {
            ViewBag.Product = productService.GetProductById(var);
            return View();
        }

        public IActionResult Search(string productName) {
            ViewBag.ProductList = productService.searchProducts(productName);
            return View();
        }
    }
}
