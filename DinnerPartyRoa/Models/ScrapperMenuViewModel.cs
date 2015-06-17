using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class ScrapperMenuViewModel
    {
        public List<MenuItem> ArroyMenu { get; set; }
        public List<MenuItem> DatabaseMenu { get; set; }

        public List<MenuItem> ItemsDeletedByArroySite { get; set; }
        public List<MenuItem> ItemsAddedByArroySite { get; set; }

     
    }
}