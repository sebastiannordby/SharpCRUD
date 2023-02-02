using SharpCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Shared.CustomerModels
{
    public class CustomerDto : BaseDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
