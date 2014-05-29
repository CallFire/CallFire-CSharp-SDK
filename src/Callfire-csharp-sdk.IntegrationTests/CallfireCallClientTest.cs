//using CallFire_csharp_sdk.API;
//using CallFire_csharp_sdk.Common.Resource;
//using NUnit.Framework;

//namespace Callfire_csharp_sdk.IntegrationTests
//{
//    [TestFixture]
//    public abstract class CallfireCallClientTest
//    {
//        protected ICallClient Client;

//        protected CfSendCall SendCall;
//        protected CfActionQuery ActionQuery;

//        [Test]
//        public void Test_SendCall()
//        {
//            var id = Client.SendCall(SendCall);
//            Assert.IsNotNull(id);
//        }

//        [Test]
//        public void Test_QueryCalls()
//        {
//            var calls = Client.QueryCalls(ActionQuery);
//            Assert.IsNotNull(calls);
//            Assert.IsNotNull(calls.Calls);
//        }
//    }
//}
