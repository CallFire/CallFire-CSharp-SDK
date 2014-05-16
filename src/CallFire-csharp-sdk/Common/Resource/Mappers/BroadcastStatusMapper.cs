using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastStatusMapper
    {
        internal static readonly TwoWayMapper<BroadcastStatus, CfBroadcastStatus> DicBroadcastStatus = new TwoWayMapper
            <BroadcastStatus, CfBroadcastStatus>
        {
            {BroadcastStatus.ARCHIVED, CfBroadcastStatus.Archived},
            {BroadcastStatus.FINISHED, CfBroadcastStatus.Finished},
            {BroadcastStatus.RUNNING, CfBroadcastStatus.Running},
            {BroadcastStatus.START_PENDING, CfBroadcastStatus.StartPending},
            {BroadcastStatus.STOPPED, CfBroadcastStatus.Stopped},
        };

        internal static CfBroadcastStatus FromSoapBroadcastStatus(BroadcastStatus source)
        {
            if (DicBroadcastStatus.ContainsKey(source))
            {
                return DicBroadcastStatus[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static BroadcastStatus ToSoapBroadcastStatus(CfBroadcastStatus source)
        {
            if (DicBroadcastStatus.ContainsKey(source))
            {
                return DicBroadcastStatus[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
