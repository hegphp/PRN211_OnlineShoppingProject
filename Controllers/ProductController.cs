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
            if (TempData["Message"]!=null)
                ViewBag.Message = TempData["Message"];

            if (TempData["CurrentQuantity"] != null)
                ViewBag.CurrentQuantityMessage = TempData["CurrentQuantity"];
            
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.Product = productService.GetProductById(var);
            return View();
        }

        [HttpGet]
        public IActionResult Search(string productName, int? page) {
            ViewBag.ProductSearched = productName;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");

            var productList = productService.searchProducts(productName);

            int pageNumber = page ?? 1;
            int totalPage = (int)(Math.Ceiling((decimal)productList.Count / 12));
            if (page > totalPage)
                pageNumber = 1;
            
            ViewBag.CateList = categoryService.GetCategories();
            ViewBag.ProductList = productList.Skip((pageNumber - 1) * 12).Take(12).ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPage = totalPage;

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
