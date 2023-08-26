using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Shared.Validation.CustomerModels
{
    public class CustomerValidationResult : SharpCRUDValidationResult
    {
        public CustomerValidationResult(
            List<ValidationFailure> failures) : base(failures)
        {

        }
    }
}
