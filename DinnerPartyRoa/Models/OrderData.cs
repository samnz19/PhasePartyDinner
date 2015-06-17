using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class OrderData
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //Re-Arrange method to render ViewModel for view

        public List<Order> Read()
        {
            Order newestOrder = db.Orders.OrderByDescending(n => n.CreatedOn).FirstOrDefault();
            DateTime weeksOrder = newestOrder.CreatedOn.Date;
            List<Order> orders = db.Orders.Where(s => EntityFunctions.TruncateTime(s.CreatedOn) == weeksOrder).ToList();
            return orders;
        }
        
    }
}