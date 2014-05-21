using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateBroadcastScheduleRestClientTest : CreateBroadcastScheduleClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            BroadcastScheduleId = 4889;
            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, "daysOfWeek");
            CreateBroadcastSchedule = new CfCreateBroadcastSchedule("requestId", BroadcastScheduleId, BroadcastSchedule);

            var response = string.Format(
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<r:ResourceReference xmlns=\"http://api.callfire.com/data\" xmlns:r=\"http://api.callfire.com/resource\">" +
                "<r:Id>{0}</r:Id>" +
                "<r:Location>https://www.callfire.com/api/1.1/rest//broadcast/{0}/schedule</r:Location>" +
                "</r:ResourceReference>", BroadcastScheduleId);

            XmlServiceClientMock.Stub(
                j =>
                    j.Send<string>(Arg<string>.Is.Equal(HttpMethods.Post),
                        Arg<string>.Is.Equal(string.Format("/broadcast/{0}/schedule", BroadcastScheduleId)),
                        Arg<CreateBroadcastSchedule>.Matches(x => x.RequestId == CreateBroadcastSchedule.RequestId &&
                                                                  x.BroadcastId == CreateBroadcastSchedule.BroadcastId &&
                                                                  x.BroadcastSchedule.id == BroadcastSchedule.Id &&
                                                                  x.BroadcastSchedule.BeginDate == BroadcastSchedule.BeginDate &&
                                                                  x.BroadcastSchedule.EndDate == BroadcastSchedule.EndDate &&
                                                                  x.BroadcastSchedule.TimeZone == BroadcastSchedule.TimeZone &&
                                                                  x.BroadcastSchedule.StartTimeOfDay == BroadcastSchedule.StartTimeOfDay &&
                                                                  x.BroadcastSchedule.StopTimeOfDay == BroadcastSchedule.StopTimeOfDay &&
                                                                  x.BroadcastSchedule.DaysOfWeek == BroadcastSchedule.DaysOfWeek)))
                .Return(response);
        }
    }
}
