using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CreateBroadcastScheduleRestClientTest : CreateBroadcastScheduleClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastScheduleId = 4889;
            CfDaysOfWeek[] daysOfWeek = {CfDaysOfWeek.Monday};
            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, daysOfWeek);
            CreateBroadcastSchedule = new CfCreateBroadcastSchedule("requestId", BroadcastScheduleId, BroadcastSchedule);

            var response = string.Format(
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<r:ResourceReference xmlns=\"http://api.callfire.com/data\" xmlns:r=\"http://api.callfire.com/resource\">" +
                "<r:Id>{0}</r:Id>" +
                "<r:Location>https://www.callfire.com/api/1.1/rest//broadcast/{0}/schedule</r:Location>" +
                "</r:ResourceReference>", BroadcastScheduleId);

            HttpClientMock.Stub(
                j =>
                    j.Send(Arg<string>.Is.Equal(string.Format("/broadcast/{0}/schedule", BroadcastScheduleId)),
                        Arg<HttpMethod>.Is.Equal(HttpMethod.Post),
                        Arg<CreateBroadcastSchedule>.Matches(x => x.RequestId == CreateBroadcastSchedule.RequestId &&
                                                                  x.BroadcastId == CreateBroadcastSchedule.BroadcastId &&
                                                                  x.BroadcastSchedule.id == BroadcastSchedule.Id &&
                                                                  x.BroadcastSchedule.BeginDate == BroadcastSchedule.BeginDate &&
                                                                  x.BroadcastSchedule.EndDate == BroadcastSchedule.EndDate &&
                                                                  x.BroadcastSchedule.TimeZone == BroadcastSchedule.TimeZone &&
                                                                  x.BroadcastSchedule.StartTimeOfDay == BroadcastSchedule.StartTimeOfDay &&
                                                                  x.BroadcastSchedule.StopTimeOfDay == BroadcastSchedule.StopTimeOfDay)))
                .Return(response);
        }
    }
}
