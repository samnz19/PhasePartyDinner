using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinnerPartyRoa.Models;

namespace DinnerPartyRoa.Controllers
{
    public class ImagesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Image
        public ActionResult Food(int id)
        {
            var item = db.MenuItems.Find(id);
            return File(item.Image, "image/jpg");
        }
    }
}