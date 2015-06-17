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

            var dbvalues = db.MenuItems.Where(m => m.IsDeleted == 0).ToList();

            var current = scrap.GetList();
            // List<string> dbTitles=new List<string>();
            // List<string> arroytitles=new List<string>();
            // foreach (var title in dbvalues)
            // {
            //     dbTitles.Add(title.Title);
            // }
            // foreach (var title in current)
            // {
            //     arroytitles.Add(title.Title);
            // }
            //// dbvalues.ForEach(i => i.Id = 0);


            vm.ArroyMenu = current;
            vm.DatabaseMenu = dbvalues;

            vm.ItemsAddedByArroySite = current.Except(dbvalues).ToList();
            vm.ItemsDeletedByArroySite = dbvalues.Except(current).ToList();
            //foreach (var item in diff)
            //{
            //    vm.ItemsAddedByArroySite = current.Where(x => x.Title == item).ToList();
            //}

            // vm.ItemsDeletedByArroySite =
            return View(vm);
        }
        public ActionResult Update()
        {


            foreach (var item in db.MenuItems)
            {
                item.IsDeleted = 1;
            }
            db.SaveChanges();
            Scrapper scrap = new Scrapper();
            scrap.GetAndSave();

            //  ScrapperMenuViewModel vm = new ScrapperMenuViewModel();


            return RedirectToAction("Index");

            //vm.DatabaseMenu = 


            //return View("Index", vm);


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
