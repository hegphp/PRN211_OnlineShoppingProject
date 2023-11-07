using Microsoft.AspNetCore.Mvc;
using Project.Services;

namespace Project.Controllers {
    public class RegisterController : Controller {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            return View();
        }
    }
}
