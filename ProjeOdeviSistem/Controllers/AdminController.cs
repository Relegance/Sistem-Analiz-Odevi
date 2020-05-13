using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeOdeviSistem.Helper;
using ProjeOdeviSistem.Models;

namespace ProjeOdeviSistem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        helperUser userHelper { get; set; }
        helperProducts pro { get; set; }
        helperCategories cat { get; set; }
        public AdminController(helperUser user,helperProducts pro, helperCategories cat)
        {
            this.userHelper = user;
            this.pro = pro;
            this.cat = cat;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = userHelper.getList().FindAll(x => x.role.Equals("kullanıcı"));
            if (users.Count > 0)
            {
                ViewBag.kullanicilar = users;
            }
            else ViewBag.kullanicilar = null;

            return View();
        }

        public IActionResult Categories()
        {
            var categories = cat.getList();
            if (categories.Count > 0)
            {
                ViewBag.products = categories;
            }
            else ViewBag.products = null;
            return View();
        }

        public IActionResult Products()
        {
            var products = pro.getList();
            if (products.Count > 0)
            {
                ViewBag.products = products;
            }
            else ViewBag.products = null;

            return View();
        }
    }
}