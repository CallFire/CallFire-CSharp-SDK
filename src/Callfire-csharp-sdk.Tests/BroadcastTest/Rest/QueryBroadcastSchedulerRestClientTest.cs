using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class QueryBroadcastSchedulerRestClientTest : QueryBroadcastScheduleClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            BroadcastId = 1;
            QueryBroadcastSchedule = new CfQueryBroadcastSchedules(100, 1, BroadcastId);

            BroadcastSchedule = new CfBroadcastSchedule(1, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now,
                DateTime.Now, "daysOfweek");
            var broadcastSchedule = new CfBroadcastSchedule[1];
            broadcastSchedule[0] = BroadcastSchedule;
            BroadcastScheduleQueryResult = new CfBroadcastScheduleQueryResult(1, broadcastSchedule);

            var broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);

            GenerateMock(broadcastScheduleQueryResult);

            BroadcastId = 2;
            BroadcastScheduleQueryResult.BroadcastSchedule = null;
            broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);

            GenerateMock(broadcastScheduleQueryResult);
        }

        private void GenerateMock(BroadcastScheduleQueryResult broadcastScheduleQueryResult)
        {
            XmlServiceClientMock
                .Stub(j => j.Send<BroadcastScheduleQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}/schedule?MaxResults={1}&FirstResult={2}",
                        BroadcastId, QueryBroadcastSchedule.MaxResults, QueryBroadcastSchedule.FirstResult)),
                    Arg<object>.Is.Null))
                .Return(broadcastScheduleQueryResult);
        }
    }
}
