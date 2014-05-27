using System;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapTextClient : BaseSoapClient, ITextClient
    {
        internal ITextServicePortTypeClient TextService;

        public SoapTextClient(string username, string password)
        {
            TextService = new TextServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Subscription>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapTextClient(ITextServicePortTypeClient client)
        {
            TextService = client;
        }

        public long SendText(CfSendText cfSendText)
        {
            var type = EnumeratedMapper.ToSoapEnumerated<CfBroadcastType>(cfSendText.Type.ToString());
            var textBroadcastConfig = TextBroadcastConfigMapper.ToSoapTextBroadcastConfig(cfSendText.TextBroadcastConfig);
            var toNumber = ToNumberMapper.ToToNumber(cfSendText.ToNumber);
            return TextService.SendText(new SendText(cfSendText.RequestId, type.ToString(), cfSendText.BroadcastName, toNumber,
                cfSendText.ScrubBroadcastDuplicates, textBroadcastConfig, cfSendText.BroadcastId, cfSendText.UseDefaultBroadcast));
        }

        public CfTextQueryResult QueryTexts(CfQueryText cfQueryText)
        {
            var state = EnumeratedMapper.ScreamingSnakeCase(cfQueryText.State.ToString());
            var result = EnumeratedMapper.ToSoapEnumerated(cfQueryText.Result);
            var textQueryResult = TextService.QueryTexts(new ActionQuery(cfQueryText.MaxResults, cfQueryText.FirstResult, cfQueryText.BroadcastId,
                cfQueryText.BatchId, state, result, cfQueryText.Inbound, cfQueryText.IntervalBegin,
                cfQueryText.IntervalEnd, cfQueryText.FromNumber, cfQueryText.ToNumber, cfQueryText.LabelName));
            return TextQueryResultMapper.FromSoapContactBatchQueryResult(textQueryResult);
        }

        public CfText GetText(long id)
        {
            var text = TextService.GetText(new IdRequest(id));
            return TextMapper.FromText(text);
        }
    }
}
