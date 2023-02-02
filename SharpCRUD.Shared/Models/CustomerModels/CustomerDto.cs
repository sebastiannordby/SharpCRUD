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
        /// <summary>
        /// Readonly field. Automatically generated.
        /// </summary>
        public int Number { get; set; } 

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customers organization number.
        /// </summary>
        public string OrganizationNumber { get; set; }
       
        /// <summary>
        /// Main phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Readonly field. Standalone function for locking and unlocking.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Addresses/locations owned by the customer.
        /// </summary>
        public List<CustomerAddressDto> Addresses { get; set; }
    }
}
