using Microsoft.AspNetCore.Mvc;
using Project.Services;
using System.Text;

namespace Project.Controllers {
    public class HomeController : Controller {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        public IActionResult Index(int? page ) {
            var productList = productService.GetProducts();
            if(!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();

            int totalPage = (int)Math.Ceiling((decimal)productList.Count / 12);

            int pageNumber = page ?? 1;

            if (page > totalPage)
                pageNumber = 1;

            ViewBag.productList = productList.Skip((pageNumber - 1)*12).Take(12).ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPage = totalPage;

            return View();
        }
    }
}
