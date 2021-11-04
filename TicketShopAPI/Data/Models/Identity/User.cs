using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShopAPI.Data.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool EmailConfirmed { get; set; } = true;
        public override bool PhoneNumberConfirmed { get; set; } = true;
    }
}
