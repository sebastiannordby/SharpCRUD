using SharpCRUD.Library.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    internal interface IValidateService<TAssembleResult, TValidationResult>
        where TValidationResult : SharpCRUDValidationResult
        where TAssembleResult : AssembleResult
    {
        Task<TValidationResult> Validate(TAssembleResult entity);
    }
}
