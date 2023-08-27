using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http.Tools
{
    public interface ISharpCRUDConfigurationService
    {
        Task<string> GetBaseAPIUrl();
    }
}
