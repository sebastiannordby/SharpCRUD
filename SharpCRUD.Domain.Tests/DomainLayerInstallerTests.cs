using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Testing.Shared;

namespace SharpCRUD.Domain.Tests
{
    public class Tests
    {
        [Test]
        public void GetSaveServiceTest()
        {
            var serviceProvider = SharpCRUDTesting.GetTestServiceProvider();
            var saveCustomerService = serviceProvider.GetService<ISaveService<CustomerDto>>();

            Assert.IsNotNull(saveCustomerService);
        }
    }
}