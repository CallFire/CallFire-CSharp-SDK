using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ITextClient : IClient
    {
        long SendText(CfSendText cfSendText);

        CfTextQueryResult QueryTexts(CfQueryText cfQueryText);
    }
}
