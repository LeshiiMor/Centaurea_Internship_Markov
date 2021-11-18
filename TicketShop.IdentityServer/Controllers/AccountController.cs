using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.IdentityServer.Data.Models;

namespace TicketShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("getacc")]
        public async Task<IActionResult> GetAccount(string username)
        {
            User user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound();
            else
            {
                return Ok();
            }
        }
    }
}
