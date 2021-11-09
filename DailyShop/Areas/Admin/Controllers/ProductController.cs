using DailyShop.Data;
using DailyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Products.Include(c => c.ProductTypes).Include(f => f.SpecialTag).ToList());
        }
        //httpget Create method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //httppost Create method
        public async Task<IActionResult> Create(Products products)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);

        }
    }
}
