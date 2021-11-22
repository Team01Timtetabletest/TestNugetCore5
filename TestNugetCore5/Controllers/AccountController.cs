using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNugetCore5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public async void LoginWithMicrosoft()
        {
            //way 1
            /*await HttpContext.ChallengeAsync("Microsoft-AccessToken",
                new AuthenticationProperties() { RedirectUri = "/" });*/
            //way 2
            await HttpContext.ChallengeAsync(MicrosoftAccountDefaults.AuthenticationScheme,
              new AuthenticationProperties() { RedirectUri = "Home/Index" });
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }
    }
}
