using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Models.CustomerModels
{
    public class CustomerId
    {
        public Guid Value { get; private set; }

        public CustomerId(Guid value) 
        { 
            Value = value;
        }
    }

    public class Customer : BaseEntity
    {
        public CustomerId Id { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string OrganizationNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsLocked { get; private set; }

        protected Customer() : base()
        {

        }

        public Customer(
            CustomerId id,
            int number,
            string name,
            string organizationNumber,
            string phoneNumber) : base()
        {
            Id = id;
            Number = number;
            Name = name;
            OrganizationNumber = organizationNumber;
            PhoneNumber = phoneNumber;
        }

        public void Update(
            string name,
            string organizationNumber,
            string phoneNumber)
        {
            Name = name;
            OrganizationNumber = organizationNumber;
            PhoneNumber = phoneNumber;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public void Lock()
        {
            IsLocked = true;
        }
    }
}
