using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IceBox.Models;
namespace IceBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IceboxDBContext db;
        public HomeController(IceboxDBContext iceboxdb)
        {
            db = iceboxdb;
        }
        public IActionResult Index()
        {
            ViewModel VM = new ViewModel();
            VM.news = new List<NewsTable>();
            VM.special = new List<ProductTable>();
            VM.recom = new List<ProductList>();
            VM.coming = new List<ProductList>();
            VM.disco = new List<ProductList>();
            
            //写入NEWS
            //第一个有active 无法用foreach       
            //其他可以使用foreach
            var news = db.NewsTable;
            foreach (var p in news)
            {
                NewsTable pl = new NewsTable();
                pl.Img = p.Img;
                pl.Name = p.Name;
                
                if (p.ObjId == 1)
                {
                    ViewBag.newsname = pl.Name;
                    ViewBag.newsimg = pl.Img;
                }
                else
                    VM.news.Add(pl);
                    
            }
            //END

            //Special
            var special = db.ProductTable.Take(6);
            foreach (var p in special)
            {

                var pl = new ProductTable();
                pl.ProductId = p.ProductId;
                pl.Name = p.Name;
                pl.Price = p.Price*p.Discount;//现价
                
                pl.Hpicture = p.Hpicture;
                if (p.Discount != 1)
                {
                    pl.Discount = p.Discount * 100;//折扣
                    pl.Id = (int)p.Price;//原价（暂存）
                }
               
                
                VM.special.Add(pl);

            }
            //END

            //推荐

            var recom = db.ProductTable;
            foreach (var p in recom)
            {   
                var pl = new ProductList();
                pl.product = new ProductTable
                {
                    Typeid = p.Typeid,
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price * p.Discount,
                    Hpicture = p.Hpicture,
                    Discount = p.Discount,
                    Id = (int)p.Price                    
                };
                /////////////////类型写入///////////////////////（或许应该使用子函数）                        
                var type = db.TypeTable.Where<TypeTable>(m=>m.Typeid== pl.product.Typeid);
                pl.type = new List<TypeTable>();
                foreach (var t in type)
                {                    
                    var ty = new TypeTable();
                    ty = new TypeTable { Type = t.Type };
                    pl.type.Add(ty);             
                }


                VM.recom.Add(pl);

            }
            //END

            //即将上市
            var coming = db.ProductTable.Take(5);
            foreach (var p in coming)
            {
                var pl = new ProductList();
                pl.product = new ProductTable
                {
                    Typeid = p.Typeid,
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price * p.Discount,
                    Hpicture = p.Hpicture,
                    Discount = p.Discount,
                    Id = (int)p.Price
                };

                /////////////////类型写入///////////////////////
                var type = db.TypeTable.Where<TypeTable>(m => m.Typeid == pl.product.Typeid);
                pl.type = new List<TypeTable>();
                foreach (var t in type)
                {
                    var ty = new TypeTable();
                    ty = new TypeTable { Type = t.Type };
                    pl.type.Add(ty);
                }


                VM.coming.Add(pl);

            }
            //END

            //打折
            var disco = db.ProductTable.Take(7);
            foreach (var p in disco)
            {
                var pl = new ProductList();
                pl.product = new ProductTable
                {
                    Typeid = p.Typeid,
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price * p.Discount,
                    Hpicture = p.Hpicture,
                    Discount = p.Discount,
                    Id = (int)p.Price
                };

                /////////////////类型写入///////////////////////
                var type = db.TypeTable.Where<TypeTable>(m => m.Typeid == pl.product.Typeid);
                pl.type = new List<TypeTable>();
                foreach (var t in type)
                {
                    var ty = new TypeTable();
                    ty = new TypeTable { Type = t.Type };
                    pl.type.Add(ty);
                }


                VM.disco.Add(pl);

            }
            //END
            return View(VM);
        }

        public IActionResult Product(int Id)
        {
            var product = db.ProductTable.Where<ProductTable>(m => m.ProductId ==Id).FirstOrDefault() ;
            product.Id = (int)product.Price;
            product.Price = product.Price * product.Discount;
            product.Discount = product.Discount * 100;
            
            return View(product);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
