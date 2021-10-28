using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.IdentityServer.VIewModels
{
    public class RegisterVIewModel
    {
        public string returnUrl { get; set; }

        [Required(ErrorMessage ="Заполните поле")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string ReentryPassword { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Email { get; set; }
    }
}
