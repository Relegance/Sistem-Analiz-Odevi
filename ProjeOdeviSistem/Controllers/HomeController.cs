using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjeOdeviSistem.Helper;
using ProjeOdeviSistem.Helpers;
using ProjeOdeviSistem.Models;
using MongoDB.Driver.Linq;
using System.Drawing;

namespace ProjeOdeviSistem.Controllers
{
    public class HomeController : Controller
    {
        helperUser userHelper { get; set; }
        helperProducts pro { get; set; }
        dataSeeder seeder { get; set; }
        helperCart cart { get; set; }
        helperOrders order { get; set; }
        helperOrderDetails od { get; set; }
        public HomeController(helperUser user, helperProducts products, helperCategories cat, helperCart ca, helperOrderDetails od, helperOrders o)
        {
            userHelper = user;
            this.pro = products;
            this.cart = ca;
            this.order = o;
            this.od = od;
            this.seeder = new dataSeeder(user, products, cat);
        }

        public IActionResult Index()
        {
            var data = pro.getList();
            if (data.Count > 0)
            {
                ViewBag.products = data;
            }
            else
            {
                seeder.productSeeder();
                seeder.userSeeder();
                ViewBag.products = null;
            }
            if (Request.Cookies.ContainsKey("LoginAuth"))
            {
                ViewBag.oneri = Oneri();
            }
            else
            {
                ViewBag.oneri = null;
            }
            return View();
        }

        public List<Product> Oneri()
        {
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var sip = order.getList().FindLast(c => c.customerID.Equals(uid));
            if (sip != null)
            {

                var list = od.getList().FindAll(c => c.orderID.Equals(sip.Id.ToString()));
                List<Product> prolist = new List<Product>();
                foreach (var item in list)
                {
                    prolist.Add(pro.getById(item.productID.ToString()));
                }

                List<Product> oneri = new List<Product>();
                var products = pro.getList();
                foreach (var item in prolist)
                {
                    oneri.Add(products.AsQueryable().Where(x => x.categoryName.Equals(item.categoryName)).ToList().OrderBy(x => Guid.NewGuid()).FirstOrDefault());
                }

                return oneri;
            }
            else
            {
                return null;
            }


        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        [Route("Sepet")]
        public IActionResult Sepet()
        {
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var sepet = cart.getList(uid);
            if (sepet.Count > 0)
            {
                ViewBag.sepet = sepet;
            }
            else
            {
                ViewBag.sepet = null;
            }
            return View();
        }

        [Authorize]
        [Route("/{id}")]
        public IActionResult SepetEkle(string id)
        {
            var urun = pro.getById(id);
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var cartvar = cart.getList(uid).Find(c => c.product.Id.Equals(urun.Id));
            if (cartvar != null)
            {
                cartvar.quantity += 1;
                cart.Update(cartvar.Id.ToString(), cartvar);
            }
            else
            {
                cart.Create(new Cart(urun, uid, 1));
            }

            return RedirectToAction("Sepet", "Home");
        }

        [Authorize]
        [Route("sepet/sil/{id}")]
        public IActionResult SepetSil(string id)
        {
            cart.Delete(id);

            return RedirectToAction("Sepet", "Home");
        }
        [Authorize]
        [Route("sepet/al")]
        public IActionResult satinAl()
        {
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var sepet = cart.getList(uid);

            double toplamFiyat = 0;

            foreach (var item in sepet)
            {
                var fiyat = item.product.productPrice * item.quantity;
                toplamFiyat += fiyat;
            }

            order.Create(new Order(uid, DateTime.Now, toplamFiyat));
            var last = order.getList().FindLast(c => c.customerID.Equals(uid));
            foreach (var item in sepet)
            {
                od.Create(new OrderDetail(last.Id.ToString(), item.product.Id.ToString(), item.quantity));
            }

            foreach (var item in sepet)
            {
                cart.Delete(item.Id.ToString());
            }


            return RedirectToAction("Siparislerim", "Home");
        }

        [Authorize]
        [Route("Siparislerim")]
        public IActionResult Siparislerim()
        {
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var siparisler = order.getList().FindAll(c => c.customerID.Equals(uid));
            if (siparisler.Count > 0)
            {
                ViewBag.siparisler = siparisler;
            }
            else
            {
                ViewBag.siparisler = null;
            }

            return View();
        }

        [Authorize]
        [Route("Siparislerim/{id}")]
        public IActionResult Detaylar(string id)
        {
            var uid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid).Value;
            var liste = od.getList().FindAll(c => c.orderID.Equals(id));
            List<string> lisid = new List<string>();
            foreach (var item in liste)
            {
                lisid.Add(item.productID);
            }
            List<Product> urunler = new List<Product>();
            foreach (var item in lisid)
            {
                urunler.Add(pro.getById(item));
            }
            List<Cart> car = new List<Cart>();
            foreach (var item in urunler)
            {
                int sayac = 0;
                car.Add(new Cart(item, uid, liste[sayac].quantity));
                sayac++;
            }


            if (liste.Count > 0)
            {
                ViewBag.detay = car;
            }
            else
            {
                ViewBag.detay = null;
            }
            return View();
        }
    }
}