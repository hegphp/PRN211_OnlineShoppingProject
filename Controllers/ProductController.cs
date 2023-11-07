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

        [HttpGet]
        public IActionResult Search(string productName) {
            ViewBag.ProductSearched = productName;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = productService.searchProducts(productName);
            return View();
        }

        [HttpPost]
        public IActionResult Search(string productName, string order) {
            ViewBag.ProductSearched = productName;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();

            var productList = productService.searchProducts(productName);

            if (order == "desc") {
                productList = productList.OrderByDescending(p => p.UnitPrice).ToList();
            }


            ViewBag.ProductList = productList;
            return View();
        }
    }
}
