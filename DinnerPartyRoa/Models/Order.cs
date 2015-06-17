using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPartyRoa.Models
{
    public class Order
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public virtual MenuItem Item { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
