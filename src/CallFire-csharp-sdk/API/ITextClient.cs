using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ITextClient : IClient
    {
        long SendText(CfSendText cfSendText);

        CfTextQueryResult QueryTexts(CfActionQuery cfActionQuery);

        CfText GetText(long id);

        long CreateAutoReply(CfCreateAutoReply cfCreateAutoReply);

        CfAutoReplyQueryResult QueryAutoReplies(CfQueryAutoReplies cfQueryAutoReplies);

        CfAutoReply GetAutoReply(long id);

        void DeleteAutoReply(long id);
    }
}
