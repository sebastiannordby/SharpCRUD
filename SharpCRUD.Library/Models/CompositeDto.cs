using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Library.Models
{
    public abstract class CompositeDto<TDto> : BaseDto
    {
        public abstract TDto Composite();
    }
}
