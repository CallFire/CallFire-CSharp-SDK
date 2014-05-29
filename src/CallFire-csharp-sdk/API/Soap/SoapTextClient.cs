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
            return TextService.SendText(new SendText(cfSendText));
        }

        public CfTextQueryResult QueryTexts(CfActionQuery cfQueryText)
        {
            var textQueryResult = TextService.QueryTexts(new ActionQuery(cfQueryText));
            return TextQueryResultMapper.FromSoapContactBatchQueryResult(textQueryResult);
        }

        public CfText GetText(long id)
        {
            var text = TextService.GetText(new IdRequest(id));
            return TextMapper.FromText(text);
        }

        public long CreateAutoReply(CfCreateAutoReply cfCreateAutoReply)
        {
            return TextService.CreateAutoReply(new CreateAutoReply(cfCreateAutoReply));
        }

        public CfAutoReplyQueryResult QueryAutoReplies(CfQueryAutoReplies cfQueryAutoReplies)
        {
            var autoReplyQueryResult = TextService.QueryAutoReplies(new QueryAutoReplies(cfQueryAutoReplies));
            return AutoReplyQueryResultMapper.FromAutoReplyQueryResult(autoReplyQueryResult);
        }

        public CfAutoReply GetAutoReply(long id) 
        { 
            return AutoReplyMapper.FromAutoReplay(TextService.GetAutoReply(new IdRequest(id)));
        }

        public void DeleteAutoReply(long id) 
        { 
            TextService.DeleteAutoReply(new IdRequest(id));
        }
    }
}
