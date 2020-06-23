using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiceAccounting.Data
{
    public class ServiceAccountingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ServiceAccountingContext() : base("name=ServiceAccountingContext2")
        {
        }

        public System.Data.Entity.DbSet<ServiceAccounting.Models.Worker> Workers { get; set; }

        public System.Data.Entity.DbSet<ServiceAccounting.Models.Service> Services { get; set; }

        public System.Data.Entity.DbSet<ServiceAccounting.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<ServiceAccounting.Models.Order> Orders { get; set; }
    }
}
