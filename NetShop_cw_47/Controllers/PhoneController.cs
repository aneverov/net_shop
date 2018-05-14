using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using NetShop_cw_47.Models;

namespace NetShop_cw_47.Controllers
{
    public class PhoneController : Controller 
    {
        private MobileContext context;

        public PhoneController(MobileContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Phone> phones = context.Phones.ToList();
            var result = phones.OrderByDescending(C => C.QuantityOrders);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            context.Phones.Add(phone);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Features(int id)
        {
            Phone phone = context.Phones.Find(id);
            ViewBag.Features = phone.Features;
            return View(phone);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Phone phone = context.Phones.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            context.Phones.Update(phone);
            context.SaveChanges();
            return View(phone);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Phone phone = context.Phones.Find(id);
            return View(phone);
        }

        [HttpPost]
        public IActionResult Delete(Phone phone)
        {
            context.Phones.Remove(phone);
            context.SaveChanges();
            return View();
        }

        public IActionResult Search(string qwery, int priceFrom, int priceTo)
        {
            List<Phone> phones = context.Phones.ToList();

            if (!string.IsNullOrEmpty(qwery))
            {
                phones = phones.Where(
                    p =>
                        p.Name.Contains(qwery) ||
                        p.Company.Contains(qwery)).ToList();
            }

            phones = phones.Where(p => p.Price >= priceFrom && p.Price <= priceTo).ToList();
            return View("Index", phones);
        }
        
        public IActionResult Sort(string sortMethod)
        {
            List<Phone> phones = context.Phones.ToList();
            switch (sortMethod)
            {
                case "price": phones = phones.OrderBy(p => p.Price).ToList(); break;
                case "name": phones = phones.OrderBy(p => p.Company).ToList(); break;
                
            }
            return View("Index", phones);
        }

        
    }
}