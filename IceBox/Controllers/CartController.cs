using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceBox.Models;
using Microsoft.AspNetCore.Http;
using IceBox.Infrastructure;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IceBox.Controllers
{
    public class CartController : Controller
    {
        private readonly IceboxDBContext db;
        public CartController(IceboxDBContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            /*
            if (Request.Query["retUrl"].ToString() != "")
            {
                ViewBag.continueBuy = Request.Query["retUrl"].ToString();
            }
            else
            {
                ViewBag.continueBuy = Request.Headers["Referer"].ToString();
            }
            */
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            if (curCart == null) curCart = new List<int[]>();
            List<CartItem> cart = new List<CartItem>();
            foreach (int [] i in curCart)
            {
                int curId = i[0];
                int curQty = i[1];
                CartItem cartItem = (from p in db.ProductTable
                                     where p.ProductId == curId
                                     select
                                         new CartItem
                                         {
                                             Name = p.Name,
                                             Price = p.Price,
                                             Discount = p.Discount,
                                             RealPrice = p.Price * p.Discount,
                                             Hpicture = p.Hpicture,
                                             
                                         }).FirstOrDefault<CartItem>();
                cart.Add(cartItem);
            }
            ViewBag.cart = cart;
            return View("Cart");
        }

        public IActionResult AddCart(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            if (curCart == null)
                HttpContext.Session.SetJson("Cart", new List<int[]> { new int[] { id, 1 } });
            else
            {
                bool found = false;
                foreach (var p in curCart)
                {
                    if (p[0] == id)
                    {
                        found = true;
                        p[1] += 1;
                        break;
                    }
                }
                if (!found)
                {
                    curCart.Add(new int[] { id, 1 });
                }
                HttpContext.Session.SetJson("Cart", curCart);
            }
            return Index();

        }

        public RedirectResult deleCartRow(int id)
        {
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            curCart.RemoveAt(id);
            HttpContext.Session.SetJson("Cart", curCart);
            return Redirect("/Cart?retUrl=" + Request.Query["retUrl"].ToString());
        }
    }
}
