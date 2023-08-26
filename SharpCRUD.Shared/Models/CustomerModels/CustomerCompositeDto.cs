using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Shared.Models.CustomerModels
{
    public class CustomerCompositeDto : CompositeDto<CustomerDto>
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public List<CustomerCompositeDto.Address> Addresses { get; set; }

        public override CustomerDto Composite()
        {
            return new(
                id: Id,
                number: Number,
                name: Name,
                organizationNumber: OrganizationNumber,
                phoneNumber: PhoneNumber,
                addresses: Addresses
                    ?.Select(x => x.Compose())
                    ?.ToList());
        }

        public class Address
        {
            public Guid Id { get; set; }
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

            public CustomerDto.Address Compose()
            {
                return new(
                    id: Id,
                    customerId: CustomerId,
                    addressLine1: AddressLine1,
                    addressLine2: AddressLine2,
                    addressLine3: AddressLine3,
                    postalCode: PostalCode,
                    postalLocality: PostalLocality);
            }
        }
    }
}
