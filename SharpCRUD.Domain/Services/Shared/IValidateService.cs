using SharpCRUD.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    internal interface IValidateService<TEntity, TValidationResult>
        where TValidationResult : SharpCRUDValidationResult
    {
        Task<TValidationResult> Validate(TEntity entity);
    }
}
