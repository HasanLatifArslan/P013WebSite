﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P013WebSite.Data;
using P013WebSite.Entities;
using P013WebSite.Tools;

namespace P013WebSite.Areas.Admin.Controllers
{
     [Area("Admin"), Authorize]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext; // databaseContexti boş olarak ekledik sağ klik generate contructor diyerek DI(dependenyInjection) işlemini yapıyoruz

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; // contexti kurucu metotta  doldurduk 
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            return View(_databaseContext.Products.Include(c => c.Category).ToList()); // Producs tablosundaki kayıtlara entittyframeworkcore un ınclude metoduyla kategörilerini de dahil ettik, böylece sql deki join işlemi ypaulmış oldu...
            //return View(_databaseContext.Products.ToList()); // var model oluşturmadan direk sayfaya modeli bu şekilde yollayabiliyoruz
        }

        // GET: ProductsController/Details/5
        

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(),"Id","Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product collection, IFormFile? Image)
        {
            try
            {
                collection.Image= await FileHelper.FileLoaderAsync(Image); // asenkron metotlar çağrılırken mutlaka başına awit anahtar kelimesini yazıyoruz
                await _databaseContext.Products.AddAsync(collection);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");

            return View(_databaseContext.Products.Find(id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
                _databaseContext.Products.Update(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            return View(_databaseContext.Products.Find(id));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _databaseContext.Products.Remove(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }
    }
}
