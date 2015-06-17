using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinnerPartyRoa.App_Start;
using DinnerPartyRoa.Models;
using DinnerPartyRoa.services;
using DinnerPartyRoa.Services;

namespace DinnerPartyRoa.Controllers
{
    public class HomeController : Controller
    {
        Scrapper scrap = new Scrapper();
        ApplicationDbContext db = new ApplicationDbContext();
       
        //GitHubApiService github = new GitHubApiService();
        
        public ActionResult Index()
        {
            
            DBConfig.RunDbMigrations();
            //ViewBag.userNames = github.GetGitHubUsers();
            return View(db.MenuItems.ToList());

        }
        // POST: api/Home
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Order()
        {
            OrderData data = new OrderData();

            return View(data.ReadByQuantity());
        }
    }
}