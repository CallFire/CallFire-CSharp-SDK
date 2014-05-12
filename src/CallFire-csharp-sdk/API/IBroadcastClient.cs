using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IBroadcastClient
    {
        long CreateBroadcast(CfBroadcast broadcast);

        CfBroadcastQueryResult QueryBroadcasts(CfQueryBroadcasts queryBroadcasts);

        CfBroadcast GetBroadcast(long id);

        void UpdateBroadcast(CfBroadcast broadcast);

        CfBroadcastStats GetBroadcastStats(long id);

        void ControlBroadcast(CfControlBroadcast controlBroadcast);
    }
}
