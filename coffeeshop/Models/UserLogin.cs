using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coffeeshop.Models;
using System.ComponentModel.DataAnnotations;

namespace coffeeshop.Models
{
    public class UserLogin
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter Username for login")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password for login")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}