using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class GetBroadcastScheduleSoapClientTest : GetBroadcastScheduleClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            BroadcastScheduleId = 1;
            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, "daysOfWeek");

            var broadcastSchedule = BroadcastScheduleMapper.ToSoapBroadcastSchedule(BroadcastSchedule);
            BroadcastServiceMock
                .Stub(b => b.GetBroadcastSchedule(Arg<IdRequest>.Matches(x => x.Id == BroadcastScheduleId)))
                .Return(broadcastSchedule);
        }
    }
}
