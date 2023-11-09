using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using Project.Services;

namespace Project.Controllers {
    public class CustomerController : Controller {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index() {
            return View();
        }

        public IActionResult Info() {
            ViewBag.CateList = categoryService.GetCategories();
            var userInfo = HttpContext.Session.GetString("userInfo");
            Customer customer = JsonConvert.DeserializeObject<Customer>(userInfo);
            ViewBag.UserInfo = customer;
            ViewBag.User = customer.CustomerId;
            return View(); 
        }
    }
}
