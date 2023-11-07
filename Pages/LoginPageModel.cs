using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Services;

namespace Project.Pages {
    public class LoginPageModel : PageModel{
        CustomerService customerService = new CustomerService();

        [BindProperty]
        public LoginDTO LoginDTO { get; set; }

        public void OnGet() { }

        public IActionResult OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }

            if (customerService.checkLoginValid(LoginDTO.Account, LoginDTO.Password)) {
                return Redirect("/home");
            }
            else
                ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không hợp lệ");

            return Page();
        }
    }
}
