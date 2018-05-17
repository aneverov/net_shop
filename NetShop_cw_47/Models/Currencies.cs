using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NetShop_cw_47.Models
{
    [DataContract]
    public class Currencies
    {
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public string CurrencyName { get; set; }
        [DataMember]
        public double CurrencyRate { get; set; }
    }
}
