using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO {
    public class LoginDTO{
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username information!")]
        public string Account { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password information!")]
        public string Password { get; set; }
    }
}
