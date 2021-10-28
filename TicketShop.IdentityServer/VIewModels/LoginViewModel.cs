using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.IdentityServer.VIewModels
{
    public class LoginViewModel
    {
        [Required]
        public string ReturnUrl { get; set; }
        
        [Required(ErrorMessage ="Заполните поле")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Password { get; set; }
    }
}
