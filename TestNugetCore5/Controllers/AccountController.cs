using Infastructure.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNugetCore5.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginWithMicrosoft()
        {
            //way 1
            /*await HttpContext.ChallengeAsync("Microsoft-AccessToken",
                new AuthenticationProperties() { RedirectUri = "/" });*/
            //way 2
            var redirectUrl = Url.Action("signin-google", null, new
            {
                ReturnUrl = "/"
            });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme, "/Account/ExternalLoginCallback");
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
            //await HttpContext.ChallengeAsync(MicrosoftAccountDefaults.AuthenticationScheme,
              //new AuthenticationProperties() { RedirectUri = "/Account/ExternalLoginCallback" });
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }
        [Route("/signin-google")]
        public async Task<ActionResult> ExternalLoginCallback1(string returnUrl = null, string remoteError = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: false, bypassTwoFactor: true);
            
            if (remoteError != null)
            {
                return null;
            }

            //Help me retrieve information here!

            return null;
        }

        public async Task<ActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: false, bypassTwoFactor: true);
            Console.WriteLine(info);
            if (remoteError != null)
            {
                return null;
            }

            //Help me retrieve information here!

            return null;
        }


    }
}
