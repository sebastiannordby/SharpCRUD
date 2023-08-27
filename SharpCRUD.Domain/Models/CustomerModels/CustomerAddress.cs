using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Models.CustomerModels
{
    public class CustomerAddress : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string AddressLine3 { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalLocality { get; private set; }

        protected CustomerAddress()
        {

        }

        public CustomerAddress(
            Guid id,
            Guid customerId,
            string addressLine1,
            string addressLine2, 
            string addressLine3, 
            string postalCode, 
            string postalLocality) : base()
        {
            Id = id;
            CustomerId = customerId;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            PostalCode = postalCode;
            PostalLocality = postalLocality;
        }

        public void Update(
            string addressLine1,
            string addressLine2,
            string addressLine3,
            string postalCode,
            string postalLocality)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            PostalCode = postalCode;
            PostalLocality = postalLocality;
        }
    }
}
