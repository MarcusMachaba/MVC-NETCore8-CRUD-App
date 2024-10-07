using System.ComponentModel.DataAnnotations;

namespace MVC.CRUD.Interface.Models.ViewModels
{
    public class SigninViewModel
    {
        [DataType(DataType.EmailAddress), Required, EmailAddress, Display(Name = "Username")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, Display(Name = "Login Password")]
        public string Password { get; set; }

        [Display(Name = "Keep me Logged in?")]
        public bool RememberMe { get; set; }
        //public string? ReturnUrl { get; set; }
    }
}
