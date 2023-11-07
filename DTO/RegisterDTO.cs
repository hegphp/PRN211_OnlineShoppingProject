using System.ComponentModel.DataAnnotations;

namespace Project.DTO {
    public class RegisterDTO {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your new account information!")]
        public string Account { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Phone information!")]
        [Phone(ErrorMessage = "Error: Phone attribute is invalid!")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter rephone information!")]
        [Compare(otherProperty: "Phone", ErrorMessage = "Your rephone and your phone do not match")]
        public string Rephone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your ContactName information!")]
        public string ContactName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Address information!")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your City information!")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your CompanyName information!")]
        public string CompanyName { get; set; }
    }
}
