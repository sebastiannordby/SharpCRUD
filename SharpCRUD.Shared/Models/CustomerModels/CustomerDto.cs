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
        public Guid? Id { get; set; }
        public int Number { get; set; } 
        public string Name { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public List<CustomerDto.Address> Addresses { get; set; }

        public CustomerDto() 
        { 
        
        }

        public CustomerDto(
            Guid id,
            int number,
            string name,
            string organizationNumber,
            string phoneNumber,
            List<CustomerDto.Address> addresses)
        {
            Id = id;
            Number = number;
            Name = name;
            OrganizationNumber = organizationNumber;
            PhoneNumber = phoneNumber;
            Addresses = addresses;
        }

        public class Address
        {
            public Guid? Id { get; set; }
            public Guid CustomerId { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string PostalCode { get; set; }
            public string PostalLocality { get; set; }

            public Address()
            {

            }

            public Address(
                Guid id,
                Guid customerId,
                string addressLine1,
                string addressLine2,
                string addressLine3,
                string postalCode,
                string postalLocality)
            {
                Id = id;
                CustomerId = customerId;
                AddressLine1 = addressLine1;
                AddressLine2 = addressLine2;
                AddressLine3 = addressLine3;
                PostalCode = postalCode;
                PostalLocality = postalLocality;
            }
        }
    }
}
