using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireTextClientTest
    {
        protected ITextClient Client;

        protected CfSendText SendText;
        protected CfActionQuery CfActionQuery;

        [Test]
        [Ignore]
        public void Test_SendText()
        {
            var id = Client.SendText(SendText);
            Assert.IsNotNull(id);
        }

        [Test]
        [Ignore]
        public void Test_QueryText()
        {
            var cfTextQueryResult = Client.QueryTexts(CfActionQuery);
            Assert.IsNotNull(cfTextQueryResult);
            Assert.IsNotNull(cfTextQueryResult.Text);
        }
    }
}
