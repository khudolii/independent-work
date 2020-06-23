using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceAccounting.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public String ServiceType { get; set; }
    }
}