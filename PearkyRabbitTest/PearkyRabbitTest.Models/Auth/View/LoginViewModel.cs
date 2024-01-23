using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Auth.View
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter your email ")]
        
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
