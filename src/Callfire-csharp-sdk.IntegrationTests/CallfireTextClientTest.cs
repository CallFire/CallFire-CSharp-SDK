using System.Linq;
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
        protected CfQueryAutoReplies QueryAutoReplies;

        [Test]
        [Ignore]
        public void Test_SendText()
        {
            var id = Client.SendText(SendText);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_QueryText()
        {
            var cfTextQueryResult = Client.QueryTexts(CfActionQuery);
            Assert.IsNotNull(cfTextQueryResult);
            Assert.IsNotNull(cfTextQueryResult.Text);
            Assert.IsTrue(cfTextQueryResult.Text.Any(t => t.FromNumber.Equals("67076")));
        }

        [Test]
        public void Test_GetText()
        {
            var text = Client.GetText(210128059001);
            Assert.IsNotNull(text);
            Assert.AreEqual(text.ToNumber.Value, "14252163710");
        }

        [Test]
        public void Test_QueryAutoReplies()
        {
            var autoReplyQueryResult = Client.QueryAutoReplies(QueryAutoReplies);
            Assert.IsNotNull(autoReplyQueryResult);
            Assert.AreEqual(autoReplyQueryResult.TotalResults, 0);
        }
    }
}
