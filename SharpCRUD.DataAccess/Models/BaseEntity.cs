using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.DataAccess.Models
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        protected BaseEntity()
        {

        }

        protected BaseEntity(Guid id)
        {
            Id = id != Guid.Empty ? id : Guid.NewGuid();
        }
    }
}
