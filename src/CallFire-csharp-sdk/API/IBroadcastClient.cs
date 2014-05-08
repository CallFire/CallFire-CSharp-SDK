using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.API
{
    public interface IBroadcastClient
    {
        long CreateBroadcast(CfBroadcast broadcast);
    }
}
