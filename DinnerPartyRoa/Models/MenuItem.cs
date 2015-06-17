using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }

        public int IsDeleted { get; set; }

        public MenuItem()
        {
            IsDeleted = 0;
        }
    }
}