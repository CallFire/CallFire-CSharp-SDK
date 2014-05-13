using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class CreateBroadcastScheduleSoapClientTest : CreateBroadcastScheduleClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, "daysOfWeek");
            CreateBroadcastSchedule = new CfCreateBroadcastSchedule("requestId", BroadcastScheduleId, BroadcastSchedule);

            BroadcastServiceMock
                .Stub(
                    b =>
                        b.CreateBroadcastSchedule(
                            Arg<CreateBroadcastSchedule>.Matches(
                                x => x.RequestId == CreateBroadcastSchedule.RequestId &&
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
