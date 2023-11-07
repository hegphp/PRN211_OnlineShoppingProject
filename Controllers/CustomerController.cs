using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Controllers {
    public class CustomerController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Info() {
            var userInfo = HttpContext.Session.GetString("userInfo");
            Customer customer = JsonConvert.DeserializeObject<Customer>(userInfo);
            ViewBag.UserInfo = customer;
            ViewBag.User = customer.CustomerId;
            return View(); 
        }
    }
}
