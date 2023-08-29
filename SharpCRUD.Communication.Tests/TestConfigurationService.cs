using SharpCRUD.Communication.Http.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Tests
{
    internal class TestConfigurationService : ISharpCRUDConfigurationService
    {
        public async Task<string> GetBaseAPIUrl()
        {
            return await Task.FromResult("https://localhost:7081/");
        }
    }
}
