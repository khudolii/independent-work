using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace ServiceAccounting.Models
{
    public class Order
    {
       
        public int OrderId { get; set; }
        public int WorkerId { get; set; }
        public Worker worker { get; set; }
        public int ClientId { get; set; }
        public Client client { get; set; }
        public int ServiceId { get; set; }
        public Service service { get; set; }
    }
}