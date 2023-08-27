using SharpCRUD.Library.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Models
{
    public class EditCustomer : EditCompositeBase<CustomerCompositeDto>
    {
        public Guid? Id => Model.Id;
        public int Number => Model.Number;

        public string Name
        {
            get => Model.Name;

            set
            {
                Model.Name = value;
                FieldChanged(nameof(Name));
            }
        }

        public string OrganizationNumber
        {
            get => Model.OrganizationNumber;

            set
            {
                Model.OrganizationNumber = value;
                FieldChanged(nameof(OrganizationNumber));
            }
        }

        public string PhoneNumber
        {
            get => Model.PhoneNumber;

            set
            {
                Model.PhoneNumber = value;
                FieldChanged(nameof(PhoneNumber));
            }
        }


        internal EditCustomer(
            CustomerCompositeDto existingModel, 
            bool isNew) : base(existingModel, isNew)
        {

        }

        public class Address : EditCompositeBase<CustomerCompositeDto.Address>
        {
            public Guid? Id => Model.Id;

            public string AddressLine1
            {
                get => Model.AddressLine1;

                set
                {
                    Model.AddressLine1 = value;
                    FieldChanged(nameof(AddressLine1));
                }
            }

            public string AddressLine2
            {
                get => Model.AddressLine2;

                set
                {
                    Model.AddressLine2 = value;
                    FieldChanged(nameof(AddressLine2));
                }
            }

            public string AddressLine3
            {
                get => Model.AddressLine3;

                set
                {
                    Model.AddressLine3 = value;
                    FieldChanged(nameof(AddressLine3));
                }
            }

            public string PostalCode
            {
                get => Model.PostalCode;

                set
                {
                    Model.PostalCode = value;
                    FieldChanged(nameof(PostalCode));
                }
            }

            public string PostalLocality
            {
                get => Model.PostalLocality;

                set
                {
                    Model.PostalLocality = value;
                    FieldChanged(nameof(PostalLocality));
                }
            }

            internal Address(
                CustomerCompositeDto.Address existingModel,
                bool isNew) : base(existingModel, isNew)
            {

            }
        }
    }
}
