using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
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

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";
        protected const string PurchaseNumber = "+13107742289";
        protected const string PurchaseKeyword = "NETTEST";

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestTextClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// SendText
        /// </summary>
        [Test]
        [Ignore]
        public void Test_SendText()
        {
            var id = Client.SendText(SendText);
            Assert.IsNotNull(id);
        }
        
        [Test]
        public void Test_SendTextEmpty()
        {
            AssertClientException<WebException, FaultException>(() => Client.SendText(null));
        }

        [Test]
        public void Test_SendTextWrongFormat()
        {
            AssertClientException<WebException, FaultException>(() => Client.SendText(new CfSendText()));
        }
        
        [Test]
        public void Test_SendTextVoiceFaild()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendText = new CfSendText
            {
                Type = CfBroadcastType.Voice,
                ToNumber = toNumberList,
                TextBroadcastConfig = new CfTextBroadcastConfig
                {
                    Message = "Test message",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryResults = new [] {CfResult.Busy}
                    }
                }
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.SendText(sendText));
        }

        [Test]
        public void Test_SendTextIVRFaild()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendText = new CfSendText
            {
                Type = CfBroadcastType.Ivr,
                ToNumber = toNumberList,
                TextBroadcastConfig = new CfTextBroadcastConfig
                {
                    Message = "Test message",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryResults = new[] { CfResult.Busy }
                    }
                }
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.SendText(sendText));
        }

        [Test]
        [Ignore]
        public void Test_SendTextMandatoryText()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendText = new CfSendText
            {
                ToNumber = toNumberList,
                UseDefaultBroadcast = true,
                Type = CfBroadcastType.Text,
                TextBroadcastConfig = new CfTextBroadcastConfig
                {
                    Message = "Test message",
                },
            };
            var id = Client.SendText(sendText);
            Assert.IsNotNull(id);
        }

        [Test]
        [Ignore]
        public void Test_SendTextCompleteText()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendText = new CfSendText
            {
                ToNumber = toNumberList,
                ScrubBroadcastDuplicates = true,
                UseDefaultBroadcast = true,
                Type = CfBroadcastType.Text,
                BroadcastName = "BroadcastName",
                TextBroadcastConfig = new CfTextBroadcastConfig
                {
                    Message = "Test message",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend,
                    FromNumber = VerifyShortCode,
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        BeginTime = new DateTime(2014,01,01,12,00,00),
                        EndTime = new DateTime(2014,12,01,17,00,00)
                    },
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryResults = new []{CfResult.Am},
                        RetryPhoneTypes = new []{CfRetryPhoneType.FirstNumber}
                    }
                },
            };
            var id = Client.SendText(sendText);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// QueryTexts
        /// </summary>
        [Test]
        public void Test_QueryText()
        {
            var cfTextQueryResult = Client.QueryTexts(CfActionQuery);
            Assert.IsNotNull(cfTextQueryResult);
            Assert.IsNotNull(cfTextQueryResult.Text);
            Assert.IsTrue(cfTextQueryResult.Text.Any(t => t.FromNumber.Equals("67076")));
        }
        
        [Test]
        public void Test_QueryTextsAllResults()
        {
            var textQueryResult = Client.QueryTexts(new CfActionQuery());
            Assert.IsNotNull(textQueryResult);
        }

        [Test]
        public void Test_QueryTextsComplete()
        {
            var actionQuery = new CfActionQuery
            {
                MaxResults = 20,
                FirstResult = 2,
                BroadcastId = 1960056001,
                FromNumber = VerifyShortCode,
                State = new []{CfActionState.Finished},
                ToNumber = VerifyFromNumber,
                Inbound = false,
                Result = new []{CfResult.Sent}
            };
            var textQueryResult = Client.QueryTexts(actionQuery);
            Assert.IsNotNull(textQueryResult);
        }

        [Test]
        public void Test_QueryTextsOnlyFromNumber()
        {
            var actionQuery = new CfActionQuery
            {
                FromNumber = VerifyShortCode,
            };
            var textQueryResult = Client.QueryTexts(actionQuery);
            Assert.IsNotNull(textQueryResult);
        }

        [Test]
        public void Test_QueryTextsOnlyLabelName()
        {
            var actionQuery = new CfActionQuery
            {
                LabelName = "TestLabel"
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.QueryTexts(actionQuery));
        }

        [Test]
        public void Test_QueryTextsOnlyState()
        {
            var actionQuery = new CfActionQuery
            {
                State = new[] { CfActionState.Ready },
            };
            var textQueryResult = Client.QueryTexts(actionQuery);
            Assert.IsNotNull(textQueryResult);
        }

        /// <summary>
        /// GetText
        /// </summary>
        [Test]
        public void Test_GetText()
        {
            var text = Client.GetText(210128059001);
            Assert.IsNotNull(text);
            Assert.AreEqual(text.ToNumber.Value, "14252163710");
        }
        
        [Test]
        public void Test_GetTextValidId()
        {
            var text = Client.GetText(226574986001);
            Assert.IsNotNull(text);
        }

        [Test]
        public void Test_GetTextInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetText(226574986000));
        }

        /// <summary>
        /// CreateAutoReply 
        /// </summary>
        [Test] //TODO
        public void Test_CreateAutoReplyMandatoryFields() 
        {
            var createAutoReply = new CfCreateAutoReply
            {
                CfAutoReply = new CfAutoReply
                {
                    Number = PurchaseNumber,
                    Keyword = PurchaseKeyword,
                    Message = "Test AutoReply Message"
                }
            };
            var id = Client.CreateAutoReply(createAutoReply);
            Assert.IsNotNull(id);
        }

        [Test] //TODO
        public void Test_CreateAutoReplyComplete()
        {
            var createAutoReply = new CfCreateAutoReply
            {
                RequestId = "TestURI",
                CfAutoReply = new CfAutoReply
                {
                    Id = 38796,
                    Number = PurchaseNumber,
                    Keyword = PurchaseKeyword,
                    Match = "Match",
                    Message = "Te$t.Aut0Reply Me55age!"
                }
            };
            var id = Client.CreateAutoReply(createAutoReply);
            Assert.IsNotNull(id);
        }
        
        /// <summary>
        /// QueryAutoReplies
        /// </summary>
        [Test]
        public void Test_QueryAutoReplies()
        {
            var autoReplyQueryResult = Client.QueryAutoReplies(QueryAutoReplies);
            Assert.IsNotNull(autoReplyQueryResult);
            Assert.AreEqual(autoReplyQueryResult.TotalResults, 0);
        }
        
        [Test]
        public void Test_QueryAutoRepliesNotExistNumber()
        {
            var queryAutoReplies = new CfQueryAutoReplies
            {
                Number = "7819461123"
            };
            var autoReplyQueryResult = Client.QueryAutoReplies(queryAutoReplies);
            Assert.IsNotNull(autoReplyQueryResult);
        }

        [Test]
        public void Test_QueryAutoRepliesAllResults()
        {
            var autoReplyQueryResult = Client.QueryAutoReplies(new CfQueryAutoReplies());
            Assert.IsNotNull(autoReplyQueryResult);
        }

        [Test] //TODO
        public void Test_QueryAutoRepliesComplete()
        {
            var queryAutoReplies = new CfQueryAutoReplies
            {
                MaxResults = 20,
                FirstResult = 2,
                Number = "7819461123"
            };
            var autoReplyQueryResult = Client.QueryAutoReplies(queryAutoReplies);
            Assert.IsNotNull(autoReplyQueryResult);
        }

        /// <summary>
        /// GetAutoReply
        /// </summary>
        [Test] //TODO
        public void Test_GetAutoReplyValidId()
        {
            var autoReply = Client.GetAutoReply(5448992);
            Assert.IsNotNull(autoReply);
        }

        [Test]
        public void Test_GetAutoReplyInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetAutoReply(5448992));
        }

        /// <summary>
        /// DeleteAutoReply
        /// </summary>
        [Test]
        public void Test_DeleteAutoReplyIdNull()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.DeleteAutoReply(0));
        }

        [Test] //TODO
        public void Test_DeleteAutoReplyComplete()
        {
            var createAutoReply = new CfCreateAutoReply
            {
                CfAutoReply = new CfAutoReply
                {
                    Number = PurchaseNumber,
                    Keyword = PurchaseKeyword,
                    Match = "Match",
                    Message = "Test AutoReply Message"
                }
            };
            var id = Client.CreateAutoReply(createAutoReply);
            Client.DeleteAutoReply(id);
        }
    }
}
