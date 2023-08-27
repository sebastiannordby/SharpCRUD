using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.Shared
{
    public interface IQuery<TResult> : IRequest<TResult>
    {

    }
}
