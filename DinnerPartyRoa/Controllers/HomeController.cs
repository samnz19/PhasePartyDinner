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
            YetAnotherViewModel vm = new YetAnotherViewModel();
            OrderData data = new OrderData();
            var dborders = db.Orders.ToList(); 

            foreach (var stuff in dborders)
            {
                var FoodName = stuff.Item.Title;
                var UserList = dborders.Where(x => x.Item.Title == FoodName).Select(u => u.Username).ToList();

                if (!vm.dictionaryOfUserOrders.ContainsKey(FoodName))
                {
                    vm.dictionaryOfUserOrders.Add(FoodName, UserList);
                }
            }

            //foreach(var foodName in vm.dictionaryOfUserOrders.Keys)
            //{
            //    var UserList = db.Orders.Where(x => x.Item.Title == foodName).Select(u => u.Username).ToList();
            //    vm.dictionaryOfUserOrders[foodName] = UserList;
            //}



            vm.data = data.ReadByQuantity();

            return View(vm);
        }

    }
}