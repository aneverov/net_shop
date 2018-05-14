using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetShop_cw_47.Models
{
    public class Phone
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Features { get; set; }
        public int QuantityOrders { get; set; }
        public string Url { get; set; }
    }
}
