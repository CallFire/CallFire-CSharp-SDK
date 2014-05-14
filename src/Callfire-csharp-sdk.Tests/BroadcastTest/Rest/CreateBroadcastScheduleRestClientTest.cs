using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
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
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, "daysOfWeek");
            CreateBroadcastSchedule = new CfCreateBroadcastSchedule("requestId", BroadcastScheduleId, BroadcastSchedule);

            JsonServiceClientMock.Stub(
                j =>
                    j.Send<long>(Arg<string>.Is.Equal(HttpMethods.Post),
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
                .Return(BroadcastScheduleId);
        }
    }
}
