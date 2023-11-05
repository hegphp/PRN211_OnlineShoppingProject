using Microsoft.AspNetCore.Mvc;
using Project.Services;
using System.Text;

namespace Project.Controllers {
    public class HomeController : Controller {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            ViewBag.ProductList = productService.GetProducts();
            if(!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            return View();
        }
    }
}
