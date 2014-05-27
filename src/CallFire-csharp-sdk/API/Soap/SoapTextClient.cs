using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapTextClient : BaseSoapClient<ITextClient>, ITextClient
    {
        public SoapTextClient(string username, string password)
            : base(username, password)
        {
        }

        internal SoapTextClient(ITextServicePortTypeClient client)
            : base(client)
        {
        }

        public long SendText(CfSendText cfSendText)
        {
            var type = BroadcastTypeMapper.ToSoapBroadcastType(cfSendText.Type);
            var textBroadcastConfig = TextBroadcastConfigMapper.ToSoapTextBroadcastConfig(cfSendText.TextBroadcastConfig);
            var toNumber = ToNumberMapper.ToToNumber(cfSendText.ToNumber);
            return TextService.SendText(new SendText(cfSendText.RequestId, type.ToString(), cfSendText.BroadcastName, toNumber,
                cfSendText.ScrubBroadcastDuplicates, textBroadcastConfig, cfSendText.BroadcastId, cfSendText.UseDefaultBroadcast));
        }

        public CfTextQueryResult QueryTexts(CfQueryText cfQueryText)
        {
            var state = cfQueryText.State.ToString().ToUpper();
            var textQueryResult = TextService.QueryTexts(new ActionQuery(cfQueryText.MaxResults, cfQueryText.FirstResult, cfQueryText.BroadcastId,
                cfQueryText.BatchId, state, cfQueryText.Result, cfQueryText.Inbound, cfQueryText.IntervalBegin,
                cfQueryText.IntervalEnd, cfQueryText.FromNumber, cfQueryText.ToNumber, cfQueryText.LabelName));
            return null;//TextQueryResultMapper
        }

        public CfText GetText(long id)
        {
            return null;
        }
    }
}
