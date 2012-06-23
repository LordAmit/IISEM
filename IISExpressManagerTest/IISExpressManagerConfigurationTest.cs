
using IISExpressManager;
using NUnit.Framework;

namespace IISExpressManagerTest
{
    [TestFixture]
    class IISExpressManagerConfigurationTest
    {
        private IISExpressConfiguration iisExpressConfiguration;

        [SetUp]
        public void Init()
        {
            iisExpressConfiguration = new IISExpressConfiguration();
            
        }

        [Test]
        public void IISConfigExistenceTest()
        {
            Assert.AreEqual(true,
                iisExpressConfiguration.CheckIISExpressConfigExistence());
        }

        [Test]
        public void IISExpressExistenceTest()
        {
            Assert.AreEqual(true,iisExpressConfiguration.CheckIISExpressExistence());
        }

    }
}
