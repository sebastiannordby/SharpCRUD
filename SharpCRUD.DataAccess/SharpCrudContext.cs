using Microsoft.EntityFrameworkCore;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.DataAccess.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.DataAccess
{
    public class SharpCrudContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
