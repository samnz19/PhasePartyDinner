using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DinnerPartyRoa.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public byte[] Image { get; set; }

        public int IsDeleted { get; set; }

        public MenuItem()
        {
            IsDeleted = 0;
        }

        public override bool Equals(object obj)
        {
            MenuItem otherItem = obj as MenuItem;
            if (otherItem == null)
            {
                return false;
            }

            return this.Title == otherItem.Title;
        }

        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }
    }
}