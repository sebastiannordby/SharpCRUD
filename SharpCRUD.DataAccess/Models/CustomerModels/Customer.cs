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
        public bool IsLocked { get; private set; }

        protected Customer()
        {

        }

        public Customer(
            Guid id,
            int number,
            string name) : base(id)
        {
            Number = number;
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
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
