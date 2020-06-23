using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceAccounting.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public String ClientName { get; set; }
        public String ClientNumberPhone { get; set; }
        public String ClientCity { get; set; }
    }
}