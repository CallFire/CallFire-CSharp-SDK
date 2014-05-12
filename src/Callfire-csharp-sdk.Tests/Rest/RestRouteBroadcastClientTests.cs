using System;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.Rest
{
    [TestFixture]
    public class RestRouteBroadcastClientTests
    {
        protected IBroadcastClient Client;
        protected JsonServiceClient JsonClientMock;
        
        [SetUp]
        public void Setup()
        {
            JsonClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonClientMock);
        }

        [Test]
        public void Test_CreateBroadcast()
        {
            var cfBroadcast = new CfBroadcast(1, "broadcast1", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, null);
            Client.CreateBroadcast(cfBroadcast);

            JsonClientMock.AssertWasCalled(c => c.Send<long>(Arg<string>.Is.Equal(HttpMethods.Post),
                Arg<string>.Is.Equal("/broadcast"),
                Arg<Broadcast>.Matches(x => x.id == cfBroadcast.Id)));
        }

        [Test]
        public void Test_QueryBroadcast()
        {
            var queryBroadcast = new CfQueryBroadcasts(1000, 0, CfBroadcastType.Text, null, null);
            Client.QueryBroadcasts(queryBroadcast);

            JsonClientMock.AssertWasCalled(c => c.Send<BroadcastQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                Arg<string>.Is.Equal("/broadcast?MaxResults=1000&FirstResult=0&Type=TEXT"),
                Arg<object>.Is.Null));
            
            queryBroadcast.Running = true;
            queryBroadcast.LabelName = "labelName1";
            Client.QueryBroadcasts(queryBroadcast);
            
            JsonClientMock.AssertWasCalled(c => c.Send<BroadcastQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                Arg<string>.Is.Equal("/broadcast?MaxResults=1000&FirstResult=0&Type=TEXT&Running=True&LabelName=labelName1"),
                Arg<object>.Is.Null));
            
            queryBroadcast.FirstResult = 1;
            queryBroadcast.MaxResults = 600;
            queryBroadcast.Running = false;
            queryBroadcast.LabelName = "labelName2";
            queryBroadcast.Type = CfBroadcastType.Ivr;
            Client.QueryBroadcasts(queryBroadcast);

            JsonClientMock.AssertWasCalled(c => c.Send<BroadcastQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                Arg<string>.Is.Equal("/broadcast?MaxResults=600&FirstResult=1&Type=IVR&Running=False&LabelName=labelName2"),
                Arg<object>.Is.Null));
        }

        [Test]
        public void Test_GetBroadcast()
        {
            Client.GetBroadcast(1);
            JsonClientMock.AssertWasCalled(c => c.Send<Broadcast>(Arg<string>.Is.Equal(HttpMethods.Get),
                Arg<string>.Is.Equal("/broadcast/1"), Arg<object>.Is.Null));
        }

        [Test]
        public void Test_UpdateBroadcast()
        {
            var cfBroadcast = new CfBroadcast(1, "broadcast1", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, null);
            Client.UpdateBroadcast(cfBroadcast);
            JsonClientMock.AssertWasCalled(c => c.Send<string>(Arg<string>.Is.Equal(HttpMethods.Put), 
                Arg<string>.Is.Equal("/broadcast/1"), 
                Arg<Broadcast>.Matches(x => x.id == cfBroadcast.Id)));
        }

        [Test]
        public void Test_GetBroadcastStats()
        {
            Client.GetBroadcastStats(1);
            JsonClientMock.AssertWasCalled(c => c.Send<BroadcastStats>(Arg<string>.Is.Equal(HttpMethods.Get),
                Arg<string>.Is.Equal("/broadcast/1/stats"), Arg<object>.Is.Null));
        }

        [Test]
        public void Test_ControlBroadcast()
        {
            var controlBroadcast = new CfControlBroadcast(0, string.Empty, CfBroadcastCommand.Start, 0);
            Client.ControlBroadcast(controlBroadcast);
            JsonClientMock.AssertWasCalled(c => c.Send<string>(Arg<string>.Is.Equal(HttpMethods.Put),
                Arg<string>.Is.Equal("/broadcast/0/control"), 
                Arg<ControlBroadcast>.Matches(x => x.Id == controlBroadcast.Id)));
            
            controlBroadcast.Id = 1;
            Client.ControlBroadcast(controlBroadcast);
            JsonClientMock.AssertWasCalled(c => c.Send<string>(Arg<string>.Is.Equal(HttpMethods.Put), 
                Arg<string>.Is.Equal("/broadcast/1/control"),
                Arg<ControlBroadcast>.Matches(x => x.Id == controlBroadcast.Id)));
        }
    }
}
