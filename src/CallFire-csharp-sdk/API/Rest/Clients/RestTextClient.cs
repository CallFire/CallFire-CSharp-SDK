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
    public class RestTextClient : BaseRestClient<Text>, ITextClient
    {
        public RestTextClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestTextClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public long SendText(CfSendText cfSendText)
        {
            var type = EnumeratedMapper.EnumFromSoapEnumerated<BroadcastType>(cfSendText.Type.ToString());
            var toNumber = ToNumberMapper.ToToNumber(cfSendText.ToNumber);
            var textBroadcastConfig = TextBroadcastConfigMapper.ToSoapTextBroadcastConfig(cfSendText.TextBroadcastConfig);
            var sendText = new SendText(cfSendText.RequestId, type.ToString(), cfSendText.BroadcastName, toNumber,
                cfSendText.ScrubBroadcastDuplicates, textBroadcastConfig, cfSendText.BroadcastId, cfSendText.UseDefaultBroadcast);
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, sendText, new CallfireRestRoute<Text>(null));
            return resource.Id;
        }

        public CfTextQueryResult QueryTexts(CfQueryText cfQueryText)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, null, 
                new CallfireRestRoute<Text>(null, null, null, new RestRouteParameters()
                    .MaxResults(cfQueryText.MaxResults)
                    .FirstResult(cfQueryText.FirstResult)
                    .BroadcastId(cfQueryText.BroadcastId)
                    .BatchId(cfQueryText.BatchId)
                    .State(EnumeratedMapper.ToSoapEnumerated(cfQueryText.State))
                    .Result(EnumeratedMapper.ToSoapEnumerated(cfQueryText.Result))
                    .Inbound(cfQueryText.Inbound)
                    .IntervalBegin(cfQueryText.IntervalBegin)
                    .IntervalEnd(cfQueryText.IntervalEnd)
                    .FromNumber(cfQueryText.FromNumber)
                    .ToNumber(cfQueryText.ToNumber)
                    .LabelName(cfQueryText.LabelName)));

            var text = ResourceListOperations.CastResourceList<Text>(resourceList);
            var textQueryResult = new TextQueryResult(resourceList.TotalResults, text);
            return TextQueryResultMapper.FromSoapContactBatchQueryResult(textQueryResult);
        }

        public CfText GetText(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Text>(id));
            return TextMapper.FromText(resource.Resources as Text);
        }
    }
}
