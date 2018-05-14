using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetShop_cw_47.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string user { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
