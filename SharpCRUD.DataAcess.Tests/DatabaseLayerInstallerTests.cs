using System;
using System.ComponentModel.Design;
using Microsoft.Extensions.Configuration;
using SharpCRUD.Testing.Shared;
using SharpCRUD.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace SharpCRUD.DataAcess.Tests
{
    public class DatabaseLayerInstallerTests
    {
        [Test]
        public void GetDbContextTest()
        {
            var serviceProvider = SharpCRUDTesting.GetTestServiceProvider();
            var dbContext = serviceProvider.GetService<SharpCrudContext>();

            Assert.IsNotNull(dbContext);
        }
    }
}