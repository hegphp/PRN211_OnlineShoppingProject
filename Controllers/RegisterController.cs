using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.DTO;
using Project.Models;
using Project.Pages;
using Project.Services;

namespace Project.Controllers {
    public class RegisterController : Controller {
        CategoryService categoryService = new CategoryService();
        CustomerService customerService = new CustomerService();
        
        [HttpGet]
        public IActionResult Index() {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return Redirect("/home");
            ViewBag.CateList = categoryService.GetCategories();
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(RegisterDTO registerDTO) {
            
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
                return Redirect("/home");

            ViewBag.CateList = categoryService.GetCategories();

            if (ModelState.IsValid) {
                Customer customer = new Customer();

                customer.CustomerId = registerDTO.Account;
                customer.Phone = registerDTO.Phone;
                customer.City = registerDTO.City;
                customer.Address = registerDTO.Address;
                customer.ContactName = registerDTO.ContactName;
                customer.CompanyName = registerDTO.CompanyName;

                customerService.AddCustomer(customer);

                HttpContext.Session.SetString("user", customer.CustomerId);
                var userInfo = JsonConvert.SerializeObject(customerService.GetCustomer(registerDTO.Account));
                HttpContext.Session.SetString("userInfo", userInfo);

                return Redirect("/home");
            }

            return View();
        }

    }
}
