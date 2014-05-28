using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapCallClient : BaseSoapClient, ICallClient
    {
        internal ICallServicePortTypeClient CallService;

        public SoapCallClient(string username, string password)
        {
            CallService = new CallServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Call>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapCallClient(ICallServicePortTypeClient client)
        {
            CallService = client;
        }

        public long SendCall(CfSendCall cfSendCall)
        {
            var type = EnumeratedMapper.ScreamingSnakeCase(cfSendCall.Type.ToString());
            // TODO
            //var toNumber = ToNumberMapper.ToToNumber(cfSendCall.ToNumber);
            var broadcastConfig = BroadcastConfigMapper.ToBroadcastConfig(cfSendCall.Item, cfSendCall.Type);
            var sendCall = new SendCall(cfSendCall.RequestId, type, cfSendCall.BroadcastName, null, cfSendCall.ScrubBroadcastDuplicates, broadcastConfig);
            return CallService.SendCall(sendCall);
        }

        public CfCallQueryResult QueryCalls(CfActionQuery cfActionQuery)
        {
            var state = EnumeratedMapper.ToSoapEnumerated(cfActionQuery.State);
            var result = EnumeratedMapper.ToSoapEnumerated(cfActionQuery.Result);
            var actionQuery = new ActionQuery(cfActionQuery.MaxResults, cfActionQuery.FirstResult, cfActionQuery.BroadcastId, cfActionQuery.BatchId,
                state, result, cfActionQuery.Inbound, cfActionQuery.IntervalBegin, cfActionQuery.IntervalEnd, 
                cfActionQuery.FromNumber, cfActionQuery.ToNumber, cfActionQuery.LabelName);
            var callQueryResult = CallService.QueryCalls(actionQuery);
            return CallQueryResultMapper.FromCallQueryResult(callQueryResult);
        }

        public CfCall GetCall(long id)
        {
            var call = CallService.GetCall(new IdRequest(id));
            return CallMapper.FromCall(call);
        }
    }
}
