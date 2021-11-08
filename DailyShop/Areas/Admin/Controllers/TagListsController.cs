using DailyShop.Data;
using DailyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyShop.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TagListsController : Controller
    {
        private ApplicationDbContext _db;
        public TagListsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return View(_db.TagLists.ToList());
        }
        //Create Action for httpget 
        public ActionResult Create()
        {
            return View();
        }

        //Create Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagLists tagLists)
        {
            if (ModelState.IsValid)
            {
                _db.TagLists.Add(tagLists);
                await _db.SaveChangesAsync();
                TempData["save"] = "Tag name saved successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(tagLists);
        }
        //Edit Action for httpget 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagList = _db.TagLists.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            return View(tagList);
        }

        //Edit Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagLists tagLists)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tagLists);
                await _db.SaveChangesAsync();
                TempData["update"] = "Tag name updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(tagLists);
        }
        //Details Action for httpget 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagList = _db.TagLists.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            return View(tagList);
        }

        //Details Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(TagLists tagLists)
        {

            return RedirectToAction(nameof(Index));

        }
        //Delete Action for httpget 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagList = _db.TagLists.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            return View(tagList);
        }

        //Delete Action for httppost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, TagLists tagLists)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != tagLists.Id)
            {
                return NotFound();
            }
            var tagList = _db.TagLists.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(tagList);
                await _db.SaveChangesAsync();
                TempData["remove"] = "Tag name deleted successfully!";
                return RedirectToAction(nameof(Index));

            }
            return View(tagLists);

        }
    }

}
