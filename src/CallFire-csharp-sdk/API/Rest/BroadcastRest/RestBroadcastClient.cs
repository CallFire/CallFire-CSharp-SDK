using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest.BroadcastRest
{
    public class RestBroadcastClient : BaseRestClient<Broadcast>, IBroadcastClient
    {
        public RestBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestBroadcastClient(JsonServiceClient jsonClient)
            : base(jsonClient)
        {
        }

        public long CreateBroadcast(CfBroadcast cfBroadcast)
        {
            var broadcast = BroadcastMapper.ToSoapBroadcast(cfBroadcast);
            return Create(broadcast);
        }

        public CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts)
        {
            var type = BroadcastTypeMapper.ToSoapBroadcastType(queryBroadcasts.Type);
            return BroadcastQueryResultMapper.FromSoapBroadcastQueryResult(BaseRequest<BroadcastQueryResult>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(null, null, null,
                    new BroadcastRestRouteParameters()
                        .MaxResults(queryBroadcasts.MaxResults)
                        .FirstResult(queryBroadcasts.FirstResult)
                        .Type(type.ToString())
                        .Running(queryBroadcasts.Running)
                        .LabelName(queryBroadcasts.LabelName))));
        }

        public CfBroadcast GetBroadcast(long id)
        {
            return BroadcastMapper.FromSoapBroadCast(GetById(id));
        }

        public void UpdateBroadcast(CfBroadcast cfBroadcast)
        {
            var broadcast = BroadcastMapper.ToSoapBroadcast(cfBroadcast);
            BaseRequest<string>(HttpMethods.Put, broadcast, new CallfireRestRoute<Broadcast>(broadcast.id));
        }

        public CfBroadcastStats GetBroadcastStats(long id)
        {
            return BroadcastStatsMapper.FromSoapBroadcastStats(BaseRequest<BroadcastStats>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, null, BroadcastRestRouteObjects.Stats, null)));
        }

        public void ControlBroadcast(CfControlBroadcast cfControlBroadcast)
        {
            var controlBroadcast = new ControlBroadcast(cfControlBroadcast.Id, cfControlBroadcast.RequestId,
                BroadcastCommandMapper.ToSoapContactBatch(cfControlBroadcast.Command), cfControlBroadcast.MaxActive);
            BaseRequest<string>(HttpMethods.Put, controlBroadcast,
                new CallfireRestRoute<Broadcast>(controlBroadcast.Id, null, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateContactBatch(CfCreateContactBatch cfCreateContactBatch)
        {
            var createContactBatch = new CreateContactBatch(cfCreateContactBatch.RequestId,
                cfCreateContactBatch.BroadcastId, cfCreateContactBatch.Name, cfCreateContactBatch.Items,
                cfCreateContactBatch.ScrubBroadcastDuplicates);
            return BaseRequest<long>(HttpMethods.Post, createContactBatch,
                new CallfireRestRoute<Broadcast>(createContactBatch.BroadcastId, null, BroadcastRestRouteObjects.Batch, null));
        }

        public CfContactBatchQueryResult QueryContactBatches(CfQueryContactBatches cfQueryContactBatches)
        {
            return ContactBatchQueryResultMapper.FromSoapContactBatchQueryResult(BaseRequest<ContactBatchQueryResult>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryContactBatches.BroadcastId, null, BroadcastRestRouteObjects.Batch, 
                    new BroadcastRestRouteParameters()
                        .MaxResults(cfQueryContactBatches.MaxResults)
                        .FirstResult(cfQueryContactBatches.FirstResult))));
        }

        public CfContactBatch GetContactBatch(long id)
        {
            return ContactBatchMapper.FromSoapContactBatch(BaseRequest<ContactBatch>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Batch, null, null)));
        }

        public void ControlContactBatch(CfControlContactBatch cfControlContactBatch)
        {
            var controlContactBatch = new ControlContactBatch(cfControlContactBatch.Id, cfControlContactBatch.Name, cfControlContactBatch.Enabled);
            BaseRequest<string>(HttpMethods.Put, controlContactBatch,
                new CallfireRestRoute<Broadcast>(controlContactBatch.Id, BroadcastRestRouteObjects.Batch, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateBroadcastSchedule(CfCreateBroadcastSchedule cfCreateBroadcastSchedule)
        {
            var createBroadcastSchedule = new CreateBroadcastSchedule(cfCreateBroadcastSchedule.RequestId,
                cfCreateBroadcastSchedule.BroadcastId,
                BroadcastScheduleMapper.ToSoapBroadcastSchedule(cfCreateBroadcastSchedule.BroadcastSchedule));
            return BaseRequest<long>(HttpMethods.Post, createBroadcastSchedule,
                new CallfireRestRoute<Broadcast>(createBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule, null));
        }

        public CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastSchedules cfQueryBroadcastSchedule)
        {
            return BroadcastScheduleQueryResultMapper.FromSoapBroadcastScheduleQueryResult(BaseRequest<BroadcastScheduleQueryResult>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule,
                    new BroadcastRestRouteParameters()
                        .MaxResults(cfQueryBroadcastSchedule.MaxResults)
                        .FirstResult(cfQueryBroadcastSchedule.FirstResult))));
        }

        public CfBroadcastSchedule GetBroadcastSchedule(long id)
        {
            return BroadcastScheduleMapper.FromSoapBroadcastSchedule(BaseRequest<BroadcastSchedule>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null)));
        }

        public void DeleteBroadcastSchedule(long id)
        {
            BaseRequest<string>(HttpMethods.Delete, null, new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
        }
    }
}
