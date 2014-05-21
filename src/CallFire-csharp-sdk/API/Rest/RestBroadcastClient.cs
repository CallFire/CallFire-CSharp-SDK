using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace CallFire_csharp_sdk.API.Rest
{
    public class RestBroadcastClient : BaseRestClient<Broadcast>, IBroadcastClient
    {
        public RestBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestBroadcastClient(XmlServiceClient xmlClient)
            : base(xmlClient)
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
            var resource = BaseRequest<ResourceList>(HttpMethods.Get, null, 
                new CallfireRestRoute<Broadcast>(null, null, null, new RestRouteParameters()
                        .MaxResults(queryBroadcasts.MaxResults)
                        .FirstResult(queryBroadcasts.FirstResult)
                        .Type(type.ToString())
                        .Running(queryBroadcasts.Running)
                        .LabelName(queryBroadcasts.LabelName)));
            
            Broadcast[] broadcasts = null;
            if (resource.Resource.Any())
            {
                broadcasts = new Broadcast[resource.Resource.Count()];
                for (var i = 0; i < resource.Resource.Count(); i++)
                {
                    broadcasts[i] = resource.Resource[i] as Broadcast;
                }
            }

            var broadcastQueryResult = new BroadcastQueryResult(resource.TotalResults, broadcasts);
            return BroadcastQueryResultMapper.FromSoapBroadcastQueryResult(broadcastQueryResult);
        }

        public CfBroadcast GetBroadcast(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethods.Get, null, new CallfireRestRoute<Broadcast>(id));
            return BroadcastMapper.FromSoapBroadCast(resource.Resources as Broadcast);
        }

        public void UpdateBroadcast(CfBroadcast cfBroadcast)
        {
            var broadcast = BroadcastMapper.ToSoapBroadcast(cfBroadcast);
            BaseRequest(HttpMethods.Put, broadcast, new CallfireRestRoute<Broadcast>(broadcast.id));
        }

        public CfBroadcastStats GetBroadcastStats(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, null, BroadcastRestRouteObjects.Stats, null));
            return BroadcastStatsMapper.FromSoapBroadcastStats(resource.Resources as BroadcastStats);
        }

        public void ControlBroadcast(CfControlBroadcast cfControlBroadcast)
        {
            var controlBroadcast = new ControlBroadcast(cfControlBroadcast.Id, cfControlBroadcast.RequestId,
                BroadcastCommandMapper.ToSoapContactBatch(cfControlBroadcast.Command), cfControlBroadcast.MaxActive);
            BaseRequest(HttpMethods.Put, controlBroadcast,
                new CallfireRestRoute<Broadcast>(controlBroadcast.Id, null, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateContactBatch(CfCreateContactBatch cfCreateContactBatch)
        {
            var createContactBatch = new CreateContactBatch(cfCreateContactBatch.RequestId,
                cfCreateContactBatch.BroadcastId, cfCreateContactBatch.Name, cfCreateContactBatch.Items,
                cfCreateContactBatch.ScrubBroadcastDuplicates);
            var resource = BaseRequest<ResourceReference>(HttpMethods.Post, createContactBatch,
                new CallfireRestRoute<Broadcast>(createContactBatch.BroadcastId, null, BroadcastRestRouteObjects.Batch, null));
            return resource.Id;
        }

        public CfContactBatchQueryResult QueryContactBatches(CfQueryContactBatches cfQueryContactBatches)
        {
            var resource = BaseRequest<ResourceList>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryContactBatches.BroadcastId, null,
                    BroadcastRestRouteObjects.Batch,
                    new RestRouteParameters()
                        .MaxResults(cfQueryContactBatches.MaxResults)
                        .FirstResult(cfQueryContactBatches.FirstResult)));

            ContactBatch[] contactBatch = null;
            if (resource.Resource.Any())
            {
                contactBatch = new ContactBatch[resource.Resource.Count()];
                for (var i = 0; i < resource.Resource.Count(); i++)
                {
                    contactBatch[i] = resource.Resource[i] as ContactBatch;
                }
            }

            var contactBatchQueryResult = new ContactBatchQueryResult(resource.TotalResults, contactBatch);
            return ContactBatchQueryResultMapper.FromSoapContactBatchQueryResult(contactBatchQueryResult);
        }

        public CfContactBatch GetContactBatch(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Batch, null, null));
            return ContactBatchMapper.FromSoapContactBatch(resource.Resources as ContactBatch);
        }

        public void ControlContactBatch(CfControlContactBatch cfControlContactBatch)
        {
            var controlContactBatch = new ControlContactBatch(cfControlContactBatch.Id, cfControlContactBatch.Name, cfControlContactBatch.Enabled);
            BaseRequest(HttpMethods.Put, controlContactBatch,
                new CallfireRestRoute<Broadcast>(controlContactBatch.Id, BroadcastRestRouteObjects.Batch, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateBroadcastSchedule(CfCreateBroadcastSchedule cfCreateBroadcastSchedule)
        {
            var createBroadcastSchedule = new CreateBroadcastSchedule(cfCreateBroadcastSchedule.RequestId,
                cfCreateBroadcastSchedule.BroadcastId,
                BroadcastScheduleMapper.ToSoapBroadcastSchedule(cfCreateBroadcastSchedule.BroadcastSchedule));
            var resource = BaseRequest<ResourceReference>(HttpMethods.Post, createBroadcastSchedule,
                new CallfireRestRoute<Broadcast>(createBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule, null));
            return resource.Id;
        }

        public CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastSchedules cfQueryBroadcastSchedule)
        {
            var resource = BaseRequest<ResourceList>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(cfQueryBroadcastSchedule.BroadcastId, null,
                    BroadcastRestRouteObjects.Schedule,
                    new RestRouteParameters()
                        .MaxResults(cfQueryBroadcastSchedule.MaxResults)
                        .FirstResult(cfQueryBroadcastSchedule.FirstResult)));

            BroadcastSchedule[] broadcastSchedule = null;
            if (resource.Resource.Any())
            {
                broadcastSchedule = new BroadcastSchedule[resource.Resource.Count()];
                for (var i = 0; i < resource.Resource.Count(); i++)
                {
                    broadcastSchedule[i] = resource.Resource[i] as BroadcastSchedule;
                }
            }

            var broadcastScheduleQueryResult = new BroadcastScheduleQueryResult(resource.TotalResults, broadcastSchedule);
            return BroadcastScheduleQueryResultMapper.FromSoapBroadcastScheduleQueryResult(broadcastScheduleQueryResult);
        }

        public CfBroadcastSchedule GetBroadcastSchedule(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethods.Get, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
            return BroadcastScheduleMapper.FromSoapBroadcastSchedule(resource.Resources as BroadcastSchedule);
        }

        public void DeleteBroadcastSchedule(long id)
        {
            BaseRequest(HttpMethods.Delete, null, new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
        }
    }
}
