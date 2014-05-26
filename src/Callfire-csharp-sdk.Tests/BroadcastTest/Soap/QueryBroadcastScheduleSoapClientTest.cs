using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class QueryBroadcastScheduleSoapClientTest : QueryBroadcastScheduleClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);

            BroadcastId = 1;
            QueryBroadcastSchedule = new CfQueryBroadcastData(100, 1, BroadcastId);

            CfDaysOfWeek[] daysOfWeek = {CfDaysOfWeek.Monday};
            BroadcastSchedule = new CfBroadcastSchedule(1, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, daysOfWeek);
            var broadcastSchedule = new CfBroadcastSchedule[1];
            broadcastSchedule[0] = BroadcastSchedule;
            BroadcastScheduleQueryResult = new CfBroadcastScheduleQueryResult(1, broadcastSchedule);
            
            var broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);
            GenerateMock(BroadcastId, broadcastScheduleQueryResult);

            BroadcastId = 2;
            BroadcastScheduleQueryResult.BroadcastSchedule = null;
            broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);
            GenerateMock(BroadcastId, broadcastScheduleQueryResult);
        }

        private void GenerateMock(long broadcastId, BroadcastScheduleQueryResult broadcastScheduleQueryResult)
        {
            BroadcastServiceMock
                .Stub(b => b.QueryBroadcastSchedule(Arg<QueryBroadcastSchedules>.Matches(x => x.MaxResults == QueryBroadcastSchedule.MaxResults &&
                                                                      x.FirstResult == QueryBroadcastSchedule.FirstResult &&
                                                                      x.BroadcastId == broadcastId)))
                .Return(broadcastScheduleQueryResult);
        }
    }
}
