using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class OrderViewModel
    {
        public String Item { get; set; }
        public int ItemId { get; set; }
        public String User { get; set; }
    }
}