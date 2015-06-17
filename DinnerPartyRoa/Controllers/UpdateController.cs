using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinnerPartyRoa.Models;
using DinnerPartyRoa.services;

namespace DinnerPartyRoa.Controllers
{
    public class UpdateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Scrapper scrap = new Scrapper();
            ScrapperMenuViewModel vm = new ScrapperMenuViewModel();

              var dbvalue= db.MenuItems.ToList().ForEach(i => i.Id = 0);
            var current = scrap.GetList();

            vm.ArroyMenu = current;
            vm.DatabaseMenu = dbvalue;

            vm.ItemsAddedByArroySite=current.Except(dbvalue).ToList();
            vm.ItemsDeletedByArroySite = dbvalue.Except(current).ToList();
            return View(vm);
        }
        public ActionResult update()
        {


            foreach (var item in db.MenuItems)
            {
                item.IsDeleted = 1;
            }
            db.SaveChanges();
            Scrapper scrap = new Scrapper();
            ScrapperMenuViewModel vm = new ScrapperMenuViewModel();     



            
            vm.DatabaseMenu = scrap.GetAndSave();
          
            
            return View("Index", vm);


        }

        // GET: Update/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Update/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Update/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Update/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Update/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Update/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Update/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
