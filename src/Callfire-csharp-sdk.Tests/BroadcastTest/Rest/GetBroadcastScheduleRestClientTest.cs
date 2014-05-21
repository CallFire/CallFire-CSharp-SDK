using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetBroadcastScheduleRestClientTest : GetBroadcastScheduleClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            BroadcastScheduleId = 1;
            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, "daysOfWeek");
            
            var broadcastSchedule = BroadcastScheduleMapper.ToSoapBroadcastSchedule(BroadcastSchedule);
            XmlServiceClientMock
                .Stub(j => j.Send<BroadcastSchedule>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/schedule/{0}", BroadcastScheduleId)),
                    Arg<object>.Is.Null))
                .Return(broadcastSchedule);
        }
    }
}
