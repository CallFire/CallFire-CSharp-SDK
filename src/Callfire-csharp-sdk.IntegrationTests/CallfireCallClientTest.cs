using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireCallClientTest
    {
        protected ICallClient Client;

        protected CfSendCall SendCall;
        protected CfActionQuery ActionQuery;
        protected CfQuery QuerySoundMeta;

        //SendCall
        [Test]
        public void Test_SendCallEmpty()
        {
            //No To
        }
        [Test]
        public void Test_SendCallMandatoryVoice()
        {
            //To= valid, 2 numbers
            //all mandatory field complete

        }
        [Test]
        public void Test_SendCallVoiceComplete()
        {
            //To= valid
            //all field complete
            //ScrubBroadcastDuplicates=true

        }
        [Test]
        public void Test_SendCallMandatoryText()
        {
            //To= valid, 2 numbers
            //all mandatory field complete

        }
        [Test]
        public void Test_SendCallTextComplete()
        {
            //To= valid
            //all field complete
            //ScrubBroadcastDuplicates=true

        }
        [Test]
        public void Test_SendCallMandatoryIVR()
        {
            //To= valid, 2 numbers
            //all mandatory field complete

        }
        [Test]
        public void Test_SendCallIVRComplete()
        {
            //To= valid
            //all field complete
            //ScrubBroadcastDuplicates=true


        }

        //QueryCalls

        [Test]
        public void Test_QueryCallsNotExistNumber()
        {
            //Number= not exist
        }

        [Test]
        public void Test_QueryCallsAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryCallsComplete()
        {

            //Id Valid
            //MaxResults 20
            //FirstResult 2
            //Inbound=true
            //all fields complete

        }
        public void Test_QueryCallsInvalidBatchId()
        {

            ////BatchId
        }

        //GetCall
        [Test]
        public void Test_GetCallValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetCallInValidIdLetters()
        {
            //ID InValido= "ABC"
        }

        //CreateSound
        [Test]
        public void Test_CreateSoundInvalidData()
        {
            //Data= file .png x example
        }
        [Test]
        public void Test_CreateSoundMandatoryFields()
        {
            //all mandatory fields complete
        }
        [Test]
        public void Test_CreateSoundNoMandatoryFields()
        {
            //all mandatory fields complete
        }
        



        














        [Test]
        [Ignore]
        public void Test_SendCall()
        {
            var id = Client.SendCall(SendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_QueryCalls()
        {
            var calls = Client.QueryCalls(ActionQuery);
            Assert.IsNotNull(calls);
            Assert.IsNotNull(calls.Calls);
            Assert.IsTrue(calls.Calls.Any(c => c.FromNumber.Equals("12132609784")));
            Assert.IsTrue(calls.Calls.Any(c => c.CallRecord.Any(r => r.Id.Equals(125746517001))));
        }

        [Test]
        public void Test_QuerySoundMeta()
        {
            var soundMeta = Client.QuerySoundMeta(QuerySoundMeta);
            Assert.IsNotNull(soundMeta);
            Assert.IsNotNull(soundMeta.SoundMeta);
            Assert.IsTrue(soundMeta.SoundMeta.Any(s => s.Id.Equals(426834001)));
        }

        [Test]
        public void Test_GetSoundMeta()
        {
            var soundMeta = Client.GetSoundMeta(426834001);
            Assert.IsNotNull(soundMeta);
            Assert.AreEqual(soundMeta.Status, CfSoundStatus.Active);
        }

        [Test]
        public void Test_GetCall()
        {
            var call = Client.GetCall(209720137001);
            Assert.IsNotNull(call);
            Assert.AreEqual(call.ContactId, 165251012001);
        }

    }
}

