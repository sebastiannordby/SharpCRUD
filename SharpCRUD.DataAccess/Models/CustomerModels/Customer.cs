using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.DataAccess.Models.CustomerModels
{
    public class Customer : BaseEntity
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
    }
}
