using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface ICallClient : IClient
    {
        long SendCall(CfSendCall cfSendCall);

        CfCallQueryResult QueryCalls(CfActionQuery cfActionQuery);

        CfCall GetCall(long id);

        long CreateSound(CfCreateSound cfCreateSound);

        CfSoundMetaQueryResult QuerySoundMeta(CfQuery cfQuerySoundMeta);

        CfSoundMeta GetSoundMeta(long id);
    }
}
