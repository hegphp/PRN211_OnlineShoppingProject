using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages {
    public class LoginDTO{
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
