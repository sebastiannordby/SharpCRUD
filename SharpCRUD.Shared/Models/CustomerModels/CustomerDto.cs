using SharpCRUD.Shared.Models;
using SharpCRUD.Shared.Models.CustomerModels;
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

        public List<CustomerAddressDto> Addresses { get; set; }
    }
}
