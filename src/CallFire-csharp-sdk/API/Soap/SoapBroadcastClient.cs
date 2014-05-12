using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    internal class SoapBroadcastClient : BaseSoapClient, IBroadcastClient
    {
        internal SoapBroadcastClient(string username, string password)
            : base(username, password)
        {
        }

        internal SoapBroadcastClient(IBroadcastServicePortTypeClient client) : base(client)
        {
        }

        public long CreateBroadcast(CfBroadcast broadcast)
        {
            return BroadcastService.CreateBroadcast(new BroadcastRequest(BroadcastMapper.ToSoapBroadcast(broadcast)));
        }

        public CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts)
        {
            var type = BroadcastTypeMapper.ToSoapBroadcastType(queryBroadcasts.Type);
            return BroadcastQueryResultMapper.FromSoapBroadcastQueryResult(
                BroadcastService.QueryBroadcasts(new QueryBroadcasts(queryBroadcasts.MaxResults,
                    queryBroadcasts.FirstResult, type.ToString(), queryBroadcasts.Running.HasValue && queryBroadcasts.Running.Value,
                    queryBroadcasts.LabelName)));
        }

        public CfBroadcast GetBroadcast(long id)
        {
            return BroadcastMapper.FromSoapBroadCast(BroadcastService.GetBroadcast(new IdRequest(id)));
        }

        public void UpdateBroadcast(CfBroadcast broadcast)
        {
            BroadcastService.UpdateBroadcast(new BroadcastRequest(BroadcastMapper.ToSoapBroadcast(broadcast)));
        }

        public CfBroadcastStats GetBroadcastStats(long id)
        {
            return BroadcastStatsMapper.FromSoapBroadcastStats(BroadcastService.GetBroadcastStats(new GetBroadcastStats(id)));
        }

        public void ControlBroadcast(CfControlBroadcast controlBroadcast)
        {
            BroadcastService.ControlBroadcast(new ControlBroadcast(controlBroadcast.Id, controlBroadcast.RequestId,
                BroadcastCommandMapper.ToSoapContactBatch(controlBroadcast.Command), controlBroadcast.MaxActive));
        }
    }
}
