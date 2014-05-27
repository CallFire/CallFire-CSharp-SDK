using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestBroadcastClient : BaseRestClient<Broadcast>, IBroadcastClient
    {
        public RestBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestBroadcastClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public long CreateBroadcast(CfBroadcastRequest createBroadcast)
        {
            var broadcastRequest = new BroadcastRequest(createBroadcast.RequestId, BroadcastMapper.ToSoapBroadcast(createBroadcast.Broadcast));
            var resourcerReference = BaseRequest<ResourceReference>(HttpMethod.Post, broadcastRequest, new CallfireRestRoute<Broadcast>(null));
            return resourcerReference.Id;
        }

        public CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts)
        {
            var type = EnumeratedMapper.ToSoapEnumerated(queryBroadcasts.Type);
            var resource = BaseRequest<ResourceList>(HttpMethod.Get, null, 
                new CallfireRestRoute<Broadcast>(null, null, null, new RestRouteParameters()
                        .MaxResults(queryBroadcasts.MaxResults)
                        .FirstResult(queryBroadcasts.FirstResult)
                        .Type(type)
                        .Running(queryBroadcasts.Running)
                        .LabelName(queryBroadcasts.LabelName)));


            var broadcasts = ResourceListOperations.CastResourceList<Broadcast>(resource);
            var broadcastQueryResult = new BroadcastQueryResult(resource.TotalResults, broadcasts);
            return BroadcastQueryResultMapper.FromSoapBroadcastQueryResult(broadcastQueryResult);
        }

        public CfBroadcast GetBroadcast(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Broadcast>(id));
            return BroadcastMapper.FromSoapBroadCast(resource.Resources as Broadcast);
        }

        public void UpdateBroadcast(CfBroadcastRequest updateBroadcast)
        {
            var broadcast = updateBroadcast.Broadcast;
            if (broadcast == null)
            {
                return;
            }
            var broadcastRequest = new BroadcastRequest(updateBroadcast.RequestId, BroadcastMapper.ToSoapBroadcast(broadcast));
            BaseRequest<string>(HttpMethod.Put, broadcastRequest, new CallfireRestRoute<Broadcast>(broadcast.Id));
        }

        public CfBroadcastStats GetBroadcastStats(CfGetBroadcastStats getBroadcastStats)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null,
                new CallfireRestRoute<Broadcast>(getBroadcastStats.Id, null, BroadcastRestRouteObjects.Stats, new RestRouteParameters()
                        .IntervalBegin(getBroadcastStats.IntervalBegin)
                        .IntervalEnd(getBroadcastStats.IntervalEnd)
            ));
            return BroadcastStatsMapper.FromSoapBroadcastStats(resource.Resources as BroadcastStats);
        }

        public void ControlBroadcast(CfControlBroadcast cfControlBroadcast)
        {
            var controlBroadcast = new ControlBroadcast(cfControlBroadcast.Id, cfControlBroadcast.RequestId,
                EnumeratedMapper.ToSoapEnumerated<BroadcastCommand>(cfControlBroadcast.Command.ToString()), cfControlBroadcast.MaxActive);
            BaseRequest<string>(HttpMethod.Put, controlBroadcast,
                new CallfireRestRoute<Broadcast>(controlBroadcast.Id, null, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateContactBatch(CfCreateContactBatch cfCreateContactBatch)
        {
            var createContactBatch = new CreateContactBatch(cfCreateContactBatch.RequestId,
                cfCreateContactBatch.BroadcastId, cfCreateContactBatch.Name, cfCreateContactBatch.Items,
                cfCreateContactBatch.ScrubBroadcastDuplicates);
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, createContactBatch,
                new CallfireRestRoute<Broadcast>(createContactBatch.BroadcastId, null, BroadcastRestRouteObjects.Batch, null));
            return resource.Id;
        }

        public CfContactBatchQueryResult QueryContactBatches(CfQueryBroadcastData cfQueryBroadcastData)
        {
            var resource = BaseRequest<ResourceList>(HttpMethod.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryBroadcastData.BroadcastId, null,
                    BroadcastRestRouteObjects.Batch,
                    new RestRouteParameters()
                        .MaxResults(cfQueryBroadcastData.MaxResults)
                        .FirstResult(cfQueryBroadcastData.FirstResult)));

            var contactBatch = ResourceListOperations.CastResourceList<ContactBatch>(resource);
            var contactBatchQueryResult = new ContactBatchQueryResult(resource.TotalResults, contactBatch);
            return ContactBatchQueryResultMapper.FromSoapContactBatchQueryResult(contactBatchQueryResult);
        }

        public CfContactBatch GetContactBatch(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Batch, null, null));
            return ContactBatchMapper.FromSoapContactBatch(resource.Resources as ContactBatch);
        }

        public void ControlContactBatch(CfControlContactBatch cfControlContactBatch)
        {
            var controlContactBatch = new ControlContactBatch(cfControlContactBatch.Id, cfControlContactBatch.Name, cfControlContactBatch.Enabled);
            BaseRequest<string>(HttpMethod.Put, controlContactBatch,
                new CallfireRestRoute<Broadcast>(controlContactBatch.Id, BroadcastRestRouteObjects.Batch, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateBroadcastSchedule(CfCreateBroadcastSchedule cfCreateBroadcastSchedule)
        {
            var createBroadcastSchedule = new CreateBroadcastSchedule(cfCreateBroadcastSchedule.RequestId,
                cfCreateBroadcastSchedule.BroadcastId,
                BroadcastScheduleMapper.ToSoapBroadcastSchedule(cfCreateBroadcastSchedule.BroadcastSchedule));
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, createBroadcastSchedule,
                new CallfireRestRoute<Broadcast>(createBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule, null));
            return resource.Id;
        }

        public CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastData cfQueryBroadcastData)
        {
            var resource = BaseRequest<ResourceList>(HttpMethod.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryBroadcastData.BroadcastId, null,
                    BroadcastRestRouteObjects.Schedule,
                    new RestRouteParameters()
                        .MaxResults(cfQueryBroadcastData.MaxResults)
                        .FirstResult(cfQueryBroadcastData.FirstResult)));

            var broadcastSchedule = ResourceListOperations.CastResourceList<BroadcastSchedule>(resource);
            var broadcastScheduleQueryResult = new BroadcastScheduleQueryResult(resource.TotalResults, broadcastSchedule);
            return BroadcastScheduleQueryResultMapper.FromSoapBroadcastScheduleQueryResult(broadcastScheduleQueryResult);
        }

        public CfBroadcastSchedule GetBroadcastSchedule(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
            return BroadcastScheduleMapper.FromSoapBroadcastSchedule(resource.Resources as BroadcastSchedule);
        }

        public void DeleteBroadcastSchedule(long id)
        {
            BaseRequest<string>(HttpMethod.Delete, null, new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
        }
    }
}
