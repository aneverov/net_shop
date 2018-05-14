using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetShop_cw_47.Models;

namespace NetShop_cw_47.Controllers
{
    public class HomeController : Controller
    {
        private MobileContext dbContext;
        private readonly IHostingEnvironment appEnvironment;
        //private NotFoundResult NotFoundResult = new NotFoundResult();

        public HomeController(MobileContext dbContext, IHostingEnvironment appEnvironment)
        {
            this.dbContext = dbContext;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(dbContext.Phones.ToList());
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Features(int id)
        {
            Phone phone = dbContext.Phones.Find(id);
            ViewBag.Features = phone.Features;
            ViewBag.Url = "https://" + phone.Url;
            return View();
        }

        [HttpGet]
        public IActionResult Manufacturer(string url)
        {
            return Redirect(url);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            dbContext.Orders.Add(order);
            Phone phone = dbContext.Phones.Find(order.PhoneId);
            phone.QuantityOrders++;
            phone.Quantity--;
            dbContext.Phones.Update(phone);
            dbContext.SaveChanges();
            return string.Format("Спасибо за покупку, {0}", order.user);

        }
        
        public IActionResult Download(int id)
        {
            try
            {
                Phone phone = dbContext.Phones.Find(id);
                string name = phone.Name + ".docx";
                string filePath = Path.Combine(appEnvironment.ContentRootPath, name);
                string fileType = "application/docx";
                string fileName = name;
                
                if (System.IO.File.Exists(filePath))
                {
                    return PhysicalFile(filePath, fileType, fileName);
                }
                else
                {
                    return View(new NotFoundResult().StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(new NotFoundResult()); ;
            }
            
        }

        
    }
}
