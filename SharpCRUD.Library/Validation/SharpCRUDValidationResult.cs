using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Library.Validation
{
    public class SharpCRUDValidationResult
    {
        public bool IsSuccessful { get; set; }
        public List<ValidationFailure>? Failures { get; set; }

        public SharpCRUDValidationResult() 
        { 
        
        }

        public SharpCRUDValidationResult(
            List<ValidationFailure> failures)
        {
            IsSuccessful = failures?.Any() == false;
            Failures = failures;
        }
    }
}
