using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Likhachev.Pgas.Web.Areas.Common.Controllers
{
    using Core.Accounts;
    using Services;
    using Services.Dtos;

    [Area("Account")]
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return Content(User.Identity.Name); // For check only
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationAccountDto model)
        {
            if (ModelState.IsValid) {
                if (!AccountServices.IsLoginTaken(model.Login)) {
                    Account newAccount = AccountServices.CreateAccount(model);
                    await Authenticate(newAccount.FirstName, newAccount.Id.ToString(), newAccount.AccountType.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Указанный логин уже зарегистрирован в системе");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginData model)
        {
            if (ModelState.IsValid)
            {
                Account user = AccountServices.GetAccount(model);
                if (user != null) {
                    await Authenticate(user.FirstName, user.Id.ToString(), user.AccountType.ToString());
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string name, string userId, string accountType)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, accountType)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}