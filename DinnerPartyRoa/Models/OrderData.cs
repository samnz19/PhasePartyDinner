using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DinnerPartyRoa.Services;
using Microsoft.Owin.Security.Provider;

namespace DinnerPartyRoa.Models
{
    public class OrderData
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Order> Read()
        {
            Order newestOrder = db.Orders.OrderByDescending(n => n.CreatedOn).FirstOrDefault();
            DateTime weeksOrder = newestOrder.CreatedOn.Date;
            List<Order> orders = db.Orders.Where(s => DbFunctions.TruncateTime(s.CreatedOn) >= weeksOrder).ToList();
            return orders;
        }

        public IEnumerable<GroupedOrderViewModel> ReadByQuantity()
        {   
            //List of Orders from Read method above.
            List<Order> orders = Read();

            IEnumerable<GroupedOrderViewModel> orderSummary = orders.GroupBy(m => m.Item.Title).Select(s => new GroupedOrderViewModel(){ItemName = s.Key, Quantity = s.Count()});
      
            //GitHubApiService gitHubApi = new GitHubApiService();
            //List<GitHubUser> users =  gitHubApi.GetGitHubUsers();

            return orderSummary;

        }   
    }
}