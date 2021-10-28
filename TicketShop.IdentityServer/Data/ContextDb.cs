using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.IdentityServer.Data.Models;

namespace TicketShop.IdentityServer.Data
{
    public class ContextDb:IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ContextDb(DbContextOptions<ContextDb> options):base(options)
        {

        }
    }
}
