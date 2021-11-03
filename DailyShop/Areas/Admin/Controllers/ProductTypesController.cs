﻿using DailyShop.Data;
using DailyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList());
        }
        //Create Action for httpget 
        public ActionResult Create()
        {
            return View();
        }
        
        //Create Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes producTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(producTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producTypes);
        }
        //Edit Action for httpget 
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        
        //Edit Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes producTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(producTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producTypes);
        }
        //Details Action for httpget 
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            return View(productType);
        }
        
        //Details Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(ProductTypes producTypes)
        {
            
                return RedirectToAction(nameof(Index));
            
        }
    }
}
