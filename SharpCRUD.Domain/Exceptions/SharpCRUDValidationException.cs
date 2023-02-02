using SharpCRUD.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Exceptions
{
    public class SharpCRUDValidationException : Exception
    {
        public SharpCRUDValidationException(SharpCRUDValidationResult validationResult)
        {

        }
    }
}
