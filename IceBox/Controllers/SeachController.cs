using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceBox.Models;
namespace IceBox.Controllers
{
    public class SeachController : Controller
    {
        private readonly IceboxDBContext db;
        public SeachController(IceboxDBContext iceboxdb)
        {
            db = iceboxdb;
        }
        public IActionResult Index ()
        {
            
            return View();
        }

        public IActionResult SeachN(string Id)
        {
            var product = db.ProductTable.Where(s => s.Name.Contains(Id));
            

            return View(product);
        }

    }
}