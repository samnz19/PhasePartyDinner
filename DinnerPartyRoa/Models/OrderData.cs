using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class OrderData
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Order> Read()
        {
            return db.Orders.Select(s => s).ToList(); 
        }
    }
}