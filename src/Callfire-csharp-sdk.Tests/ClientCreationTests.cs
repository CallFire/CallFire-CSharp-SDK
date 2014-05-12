using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests
{
    [TestFixture]
    public abstract class ClientCreationTests
    {
        protected ICallfireClient Client;

        [Test]
        public void Should_create_client_instance()
        {
            Assert.IsNotNull(Client);
        }

        [Test]
        public void Should_create_broadcast_client()
        {
            Assert.IsNotNull(Client.Broadcasts);
        }
    }
}
