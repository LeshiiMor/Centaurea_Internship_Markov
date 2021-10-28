using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using TicketShop.IdentityServer.Data.Models;

namespace TicketShop.IdentityServer.Data
{
    public class DbInit
    {
        public static async Task Init(IServiceProvider provider)
        {
            UserManager<User> userManager = provider.GetService<UserManager<User>>();
            RoleManager<IdentityRole<int>> rolemanager = provider.GetService<RoleManager<IdentityRole<int>>>();

            var role = await rolemanager.FindByNameAsync("admin");
            if (role == null)
            {
                role = new IdentityRole<int>()
                {
                    Name = "admin"
                };
                var result = await rolemanager.CreateAsync(role);
            }
            var userRole = await rolemanager.FindByNameAsync("user");
            if(userRole==null)
            {
                userRole = new IdentityRole<int>()
                {
                    Name = "user"
                };
                var result = await rolemanager.CreateAsync(userRole);
            }
            var user = await userManager.FindByNameAsync("admin");
            if(user==null)
            {
                User admin = new User()
                {
                    LastName = "admin",
                    FirstName = "admin",
                    UserName = "admin"
                };
                var result = await userManager.CreateAsync(admin, "admin");
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin,"admin");
                }
            }
        }
    }
}
