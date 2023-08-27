using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Models.SupplierModels
{
    public class Supplier : BaseEntity
    {
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
    }
}
