using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Pages;
using Project.Services;
using System.Text.Json.Serialization;

namespace Project.Controllers {
    public class LoginController : Controller {
        CategoryService categoryService = new CategoryService();
        CustomerService customerService = new CustomerService();
        [HttpGet]
        public IActionResult Index() {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                ViewBag.User = HttpContext.Session.GetString("user");
            ViewBag.CateList = categoryService.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDTO loginDTO) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("loginFailed", "Tài khoản hoặc mật khẩu không hợp lệ");
                return Redirect("/login");
            }

            if (customerService.checkLoginValid(loginDTO.Account, loginDTO.Password)) {
                HttpContext.Session.SetString("user", loginDTO.Account);
                var userInfo = JsonConvert.SerializeObject(customerService.GetCustomer(loginDTO.Account));
                HttpContext.Session.SetString("userInfo", userInfo);
                return Redirect("/home");
            }
            else
                ModelState.AddModelError("loginFailed", "Tài khoản hoặc mật khẩu không hợp lệ");

            return Redirect("/login");
        }
    }
}
