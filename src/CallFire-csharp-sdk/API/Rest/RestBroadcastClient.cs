using System;
using System.Linq;
using System.Xml;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using ServiceStack.Common;
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
            var resource = BaseRequest<ResourceList<Broadcast>>(HttpMethods.Get, null, 
                new CallfireRestRoute<Broadcast>(null, null, null, new RestRouteParameters()
                        .MaxResults(queryBroadcasts.MaxResults)
                        .FirstResult(queryBroadcasts.FirstResult)
                        .Type(type.ToString())
                        .Running(queryBroadcasts.Running)
                        .LabelName(queryBroadcasts.LabelName)));
            var broadcastQueryResult = new BroadcastQueryResult(resource.TotalResults, resource.Resource);
            return BroadcastQueryResultMapper.FromSoapBroadcastQueryResult(broadcastQueryResult);
        }

        public CfBroadcast GetBroadcast(long id)
        {
            return null;//BroadcastMapper.FromSoapBroadCast(GetById(id));
        }

        public void UpdateBroadcast(CfBroadcast cfBroadcast)
        {
            var broadcast = BroadcastMapper.ToSoapBroadcast(cfBroadcast);
            //BaseRequest(HttpMethods.Put, broadcast, new CallfireRestRoute<Broadcast>(broadcast.id));
        }

        public CfBroadcastStats GetBroadcastStats(long id)
        {
            return null;/*BroadcastStatsMapper.FromSoapBroadcastStats(BaseRequest<BroadcastStats>(Method.GET, null,
                new CallfireRestRoute<Broadcast>(id, null, BroadcastRestRouteObjects.Stats, null)));*/
        }

        public void ControlBroadcast(CfControlBroadcast cfControlBroadcast)
        {
            var controlBroadcast = new ControlBroadcast(cfControlBroadcast.Id, cfControlBroadcast.RequestId,
                BroadcastCommandMapper.ToSoapContactBatch(cfControlBroadcast.Command), cfControlBroadcast.MaxActive);
           // BaseRequest(HttpMethods.Put, controlBroadcast,
             //   new CallfireRestRoute<Broadcast>(controlBroadcast.Id, null, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateContactBatch(CfCreateContactBatch cfCreateContactBatch)
        {
            var createContactBatch = new CreateContactBatch(cfCreateContactBatch.RequestId,
                cfCreateContactBatch.BroadcastId, cfCreateContactBatch.Name, cfCreateContactBatch.Items,
                cfCreateContactBatch.ScrubBroadcastDuplicates);
            return 0;/*BaseRequest<long>(Method.POST, createContactBatch,
                new CallfireRestRoute<Broadcast>(createContactBatch.BroadcastId, null, BroadcastRestRouteObjects.Batch, null));*/
        }

        public CfContactBatchQueryResult QueryContactBatches(CfQueryContactBatches cfQueryContactBatches)
        {
            return null;/*ContactBatchQueryResultMapper.FromSoapContactBatchQueryResult(BaseRequest<ContactBatchQueryResult>(Method.GET, null,
               new CallfireRestRoute<Broadcast>(cfQueryContactBatches.BroadcastId, null, BroadcastRestRouteObjects.Batch, 
                    new RestRouteParameters()
                      .MaxResults(cfQueryContactBatches.MaxResults)
                      .FirstResult(cfQueryContactBatches.FirstResult))));*/
        }

        public CfContactBatch GetContactBatch(long id)
        {
            return null;/*ContactBatchMapper.FromSoapContactBatch(BaseRequest<ContactBatch>(Method.GET, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Batch, null, null)));*/
        }

        public void ControlContactBatch(CfControlContactBatch cfControlContactBatch)
        {
            var controlContactBatch = new ControlContactBatch(cfControlContactBatch.Id, cfControlContactBatch.Name, cfControlContactBatch.Enabled);
           // BaseRequest(HttpMethods.Put, controlContactBatch,
             //   new CallfireRestRoute<Broadcast>(controlContactBatch.Id, BroadcastRestRouteObjects.Batch, BroadcastRestRouteObjects.Control, null));
        }

        public long CreateBroadcastSchedule(CfCreateBroadcastSchedule cfCreateBroadcastSchedule)
        {
            var createBroadcastSchedule = new CreateBroadcastSchedule(cfCreateBroadcastSchedule.RequestId,
                cfCreateBroadcastSchedule.BroadcastId,
                BroadcastScheduleMapper.ToSoapBroadcastSchedule(cfCreateBroadcastSchedule.BroadcastSchedule));
            return 0;/*BaseRequest<long>(Method.POST, createBroadcastSchedule,
                new CallfireRestRoute<Broadcast>(createBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule, null));*/
        }

        public CfBroadcastScheduleQueryResult QueryBroadcastSchedule(CfQueryBroadcastSchedules cfQueryBroadcastSchedule)
        {
            return null;/*BroadcastScheduleQueryResultMapper.FromSoapBroadcastScheduleQueryResult(BaseRequest<BroadcastScheduleQueryResult>(Method.GET, null,
                new CallfireRestRoute<Broadcast>(cfQueryBroadcastSchedule.BroadcastId, null, BroadcastRestRouteObjects.Schedule,
                    new RestRouteParameters()
                       .MaxResults(cfQueryBroadcastSchedule.MaxResults)
                       .FirstResult(cfQueryBroadcastSchedule.FirstResult))));*/
        }

        public CfBroadcastSchedule GetBroadcastSchedule(long id)
        {
            return null;/*BroadcastScheduleMapper.FromSoapBroadcastSchedule(BaseRequest<BroadcastSchedule>(Method.GET, null,
                new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null)));*/
        }

        public void DeleteBroadcastSchedule(long id)
        {
           // BaseRequest(HttpMethods.Delete, null, new CallfireRestRoute<Broadcast>(id, BroadcastRestRouteObjects.Schedule, null, null));
        }
    }
}
