namespace SharpCRUD.Communication.Tests
{
    public class CommunicationTestBase
    {
        protected IServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _serviceProvider = CommunicationsTestsInstaller.GetTestServiceProvider();
        }
    }
}