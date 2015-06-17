using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPartyRoa.Models
{
    public class GroupedOrderViewModel
    {
        //Name of item
        //Number of orders for that item

        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
