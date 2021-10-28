using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.IdentityServer.Data.Models;
using TicketShop.IdentityServer.VIewModels;

namespace TicketShop.IdentityServer.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signin;
        private readonly IIdentityServerInteractionService _interactServ;
        public AuthController(SignInManager<User> signin, UserManager<User> userManager, IIdentityServerInteractionService interactServ)
        {
            _signin = signin;
            _userManager = userManager;
            _interactServ = interactServ;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "private";
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if(user == null)
                {
                    ModelState.AddModelError("", "Пользователь не найден");
                    return View(model);
                }
                var result = await _signin.PasswordSignInAsync(user, model.Password, false, false);
                if(result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Возникла ошибка во время аутентификации ");
                    return View(model);
                }
            }
            else return View(model);
        }
        
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            RegisterVIewModel model = new RegisterVIewModel()
            {
                returnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVIewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if(user !=null)
                {
                    ModelState.AddModelError("","Пользователь с таким логином уже существует");
                    return View(model);
                }
                if(model.ReentryPassword != model.Password)
                {
                    ModelState.AddModelError("ReentryPassword", "Пароли не совпадают");
                    ModelState.AddModelError("Password", "Пароли не совпадают");
                    return View(model);
                }
                User newUser = new User()
                {
                    UserName = model.Username,
                    LastName=model.LastName,
                    FirstName=model.FirstName,
                    Email = model.Email,
                    PhoneNumber= model.Phone
                };
                var result = await _userManager.CreateAsync(newUser,model.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser,"user");
                    var signinRes = await _signin.PasswordSignInAsync(newUser,model.Password, false, false);
                    return Redirect(model.returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "");
                    return View(model);
                }
            }
            else return View(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signin.SignOutAsync();
            var logoutResult = await _interactServ.GetLogoutContextAsync(logoutId);
            if (string.IsNullOrEmpty(logoutResult.PostLogoutRedirectUri))
            {
                return RedirectToAction("Login");
            }
            else
            {
                return Redirect(logoutResult.PostLogoutRedirectUri);
            }
        }
    }
}
