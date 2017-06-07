using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IceBox.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using IceBox.Infrastructure;
using Newtonsoft.Json;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IceBox.Controllers
{
    public class OrderController : Controller
    {
        private readonly IceboxDBContext db;
        public OrderController(IceboxDBContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {

            ViewBag.Request = Request;
            string uid = User.Identity.Name;
            OrderViewModel ovm = new OrderViewModel();
            ovm.orders = new List<OrderInfo>();
            ovm.receivers = new List<Consignee>();
            ovm.words = new List<CustomerWords>();
            ovm.payment = new Payment();
            //获取信息以显示在页面
            ovm.curCustomer = db.Customer.Single(m => m.UserName == uid);
            ViewBag.payments = db.PaymentType.Where(m => m.ObjId > 0).ToArray<PaymentType>();
            List<int[]> curCart = HttpContext.Session.GetJson<List<int[]>>("Cart");
            ovm.orderQty = 0;
            ovm.payment.Amount = 0.0;
            foreach (var cartItem in curCart)
            {
                ovm.orderQty += cartItem[1];
                int pObjId = cartItem[0];
                for (int i = 0; i < cartItem[1]; i++)
                {
                    var product = db.Product.Single(m => m.ObjId == pObjId);
                    var price = db.PriceList.Single(m => m.TheProduct == pObjId && m.TheCustomerType == ovm.curCustomer.TheCustomerType);
                    ovm.orders.Add(new OrderInfo { theProduct = product.ObjId, price = (double)product.Price, realPrice = (double)price.RealPrice, productName = product.ProductName, productFeature = product.Feature, smallImg = product.SmallImg });
                    ovm.receivers.Add(new Consignee());
                    ovm.words.Add(new CustomerWords());
                    ovm.payment.Amount += price.RealPrice;
                }
            }
            return View("Order", ovm);

        }
    }
}
