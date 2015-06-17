using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinnerPartyRoa.services;

namespace DinnerPartyRoa.Controllers
{
    public class UpdateController : Controller
    {
        Scrapper scrap = new Scrapper();
        // GET: Update
        public ActionResult Index()
        {
            //scrap.GetAndSave();
            return View();
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
