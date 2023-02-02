using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.DataAccess.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        [NotMapped]
        public bool IsNew { get; set; }

        protected BaseEntity()
        {

        }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
