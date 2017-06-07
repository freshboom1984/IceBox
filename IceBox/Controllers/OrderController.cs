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
            string uid = User.Identity.Name;

            return View("Order");
        }
    }
}
