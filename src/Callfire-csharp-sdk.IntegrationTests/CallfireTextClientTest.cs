using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireTextClientTest
    {
        protected CallfireClient CallfireClient;
        protected ITextClient Client;

        protected CfSendText SendText;
        protected CfActionQuery CfActionQuery;
        protected CfQueryAutoReplies QueryAutoReplies;

        //SendText

        [Test]
        public void Test_SendTextEmpty()
        {

            //
        }
        [Test]
        public void Test_SendTextWrongFormat()
        {

            //number wrong format
        }
        [Test]
        public void Test_SendTextMandatotyVoice()
        {

            //default
        }
        [Test]
        public void Test_SendTextCompleteVoice()
        {
            //ScrubBroadcastDuplicates=true
            //UseDefaultBroadcast=true
            //all fields completes
        }
        [Test]
        public void Test_SendTextMandatoryIVR()
        {
            //ScrubBroadcastDuplicates=default false
            //UseDefaultBroadcast=default false
            //all fields completes
        }
        [Test]
        public void Test_SendTextCompleteIVR()
        {
            //ScrubBroadcastDuplicates=true
            //UseDefaultBroadcast=true
            //all fields completes
        }
        [Test]
        public void Test_SendTextMandatoryText()
        {
            //ScrubBroadcastDuplicates=default
            //UseDefaultBroadcast=default
            //all fields completes
        }
        [Test]
        public void Test_SendTextCompleteText()
        {
            //
            //ScrubBroadcastDuplicates=true
            //UseDefaultBroadcast=true
            //all fields completes
        }

        //QueryTexts
       [Test]
        public void Test_QueryTextsAllResults()
        {

            //

        }

        [Test]
       public void Test_QueryTextsComplete()
        {

            //Id Valid
            //MaxResults 20
            //FirstResult 2

        }

        [Test]
        public void Test_QueryTextsOnlyFromNumber()
        {

            //From number= yes

        }
        [Test]
        public void Test_QueryTextsOnlyLabelName()
        {

            //

        }
        [Test]
        public void Test_QueryTextsOnlyState()
        {

            //State=READY

        }

        //GetText
        [Test]
        public void Test_GetTextValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetTextInValidId()
        {
            //ID InValido
        }

        //CreateAutoReply
        [Test]
        public void Test_CreateAutoReplyMandatoryFields()
        {
            //Number
        }
        [Test]
        public void Test_CreateAutoReplyComplete()
        {
            //all fields complete
            //Message with !"·"·$$% numbers and letters
            //Keyword

        }


        //QueryAutoReplies
        [Test]
        public void Test_QueryAutoRepliesNotExistNumber()
        {
            //Number= not exist
        }

        [Test]
        public void Test_QueryAutoRepliesAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryAutoRepliesComplete()
        {

            //Id Valid
            //MaxResults 20
            //FirstResult 2

        }
        //GetAutoReply
        [Test]
        public void Test_GetAutoReplyValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetAutoReplyInValidId()
        {
            //ID InValido
        }

        //DeleteAutoReply
        [Test]
        public void Test_DeleteAutoReplyIdNull()
        {
            //
        }
        [Test]
        public void Test_DeleteAutoReplyComplete()
        {
            //valid id
        }

        















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
