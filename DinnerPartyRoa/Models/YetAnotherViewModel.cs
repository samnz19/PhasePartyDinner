using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class YetAnotherViewModel
    {
        public IEnumerable<GroupedOrderViewModel> data { get; set; }
        public Dictionary<string, List<string>> dictionaryOfUserOrders = new Dictionary<string, List<string>>();
    }
}