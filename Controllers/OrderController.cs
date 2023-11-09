using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers {
    public class OrderController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult AddOrder() {
            return Redirect("/order/list");
        }

        public IActionResult List() {
            return View();
        }
    }
}
