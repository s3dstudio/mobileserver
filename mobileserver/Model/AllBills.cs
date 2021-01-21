using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.Model
{
    public class AllBills
    {
        public string idCart { get; set; }
        public int table { get; set; }
        public int totalPrice { get; set; }
        public int tableNumber { get; set; }
        public string status { get; set; }
        public Food food { get; set; }
        public string idfood { get; set; }
    }
}
