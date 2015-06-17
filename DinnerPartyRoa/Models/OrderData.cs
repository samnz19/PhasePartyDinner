using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
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
            List<Order> orders = db.Orders.Where(s => EntityFunctions.TruncateTime(s.CreatedOn) >= weeksOrder &&  < weeksOrder).ToList();
            return orders;
        }

        public Dictionary<MenuItem, int> ReadByQuantity()
        {
            List<Order> data = Read();
            Dictionary<MenuItem, int> orderSummary = new Dictionary<MenuItem, int>();
            foreach (var i in data)
            {
                orderSummary.Add();
            }
            return orderSummary;
        }   
    }
}