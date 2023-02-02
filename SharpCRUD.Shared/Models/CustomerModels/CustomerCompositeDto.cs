using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Shared.Models.CustomerModels
{
    public class CustomerCompositeDto : CompositeDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
