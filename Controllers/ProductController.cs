using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers { 
    using Models;
    using Services;
    public class ProductController : Controller {
        public IActionResult Index() {
            return View();
        }

    }
}
