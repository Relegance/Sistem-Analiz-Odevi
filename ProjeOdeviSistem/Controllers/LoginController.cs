using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeOdeviSistem.Helper;
using ProjeOdeviSistem.Models;

namespace ProjeOdeviSistem.Controllers
{
    public class LoginController : Controller
    {
        helperUser userHelper { get; set; }
        public LoginController(helperUser user)
        {
            userHelper = user;
        }
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string email,string password)
        {
            if (userControl(email,password))
            {
                User user = userHelper.getList().FirstOrDefault(r=> r.email.Equals(email));
                var userClaims = new List<Claim>() { new Claim(ClaimTypes.Email, user.email), new Claim(ClaimTypes.Role, user.role), new Claim(ClaimTypes.Name,user.name), new Claim(ClaimTypes.PrimarySid,user.Id.ToString()) };
                var identity = new ClaimsIdentity(userClaims, DefaultAuthenticationTypes.ApplicationCookie);

                var principal = new ClaimsPrincipal(new[] { identity });

                Thread.CurrentPrincipal = principal;

                await HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
                {
                    return Redirect(HttpContext.Request.Query["ReturnUrl"]);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }

            
            ViewBag.err = "Giriş bilgileriniz yanlış!";
            return View();
        }

        [AllowAnonymous][Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(string name,string email, string password, string city, string adress)
        {
            bool kontrol = emailControl(email);
            if (kontrol == true)
            {
                userHelper.Create(new User(name, password, email, city, adress, "kullanıcı"));
                return RedirectToAction("Login","Login");
            }
            else
            {
                ViewBag.err = "Sistemde bu mail ile kayıtlı kullanıcı var.";
                return View();
            }
        }

        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        private bool userControl(string email, string password)
        {
            User user = userHelper.getList().FirstOrDefault(r => r.email.Equals(email) && r.password.Equals(password));
            if (user != null)
            {
                return true;
            }
            else return false;
        }

        private bool emailControl(string email)
        {
            User user = userHelper.getList().FirstOrDefault(r => r.email.Equals(email));

            if (user == null)
            {
                return true;
            } else return false;

        }
    }
}