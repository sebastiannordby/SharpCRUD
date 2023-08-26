using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Models.SupplierModels;

namespace SharpCRUD.Domain
{
    public class SharpCrudContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public SharpCrudContext(DbContextOptions options) : base(options)
        {

        }
    }
}
