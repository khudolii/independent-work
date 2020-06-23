using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceAccounting.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public String WorkerName { get; set; }
        public int WorkerExpirience { get; set; }

    }
}