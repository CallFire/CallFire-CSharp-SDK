using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastStatusMapper
    {
        internal static readonly Dictionary<BroadcastStatus, CfBroadcastStatus> DicSoapBroadcastStatus = new Dictionary
            <BroadcastStatus, CfBroadcastStatus>
        {
            {BroadcastStatus.ARCHIVED, CfBroadcastStatus.Archived},
            {BroadcastStatus.FINISHED, CfBroadcastStatus.Finished},
            {BroadcastStatus.RUNNING, CfBroadcastStatus.Running},
            {BroadcastStatus.START_PENDING, CfBroadcastStatus.StartPending},
            {BroadcastStatus.STOPPED, CfBroadcastStatus.Stopped},
        };

        internal static readonly Dictionary<CfBroadcastStatus, BroadcastStatus> DicBroadcastStatus = new Dictionary
            <CfBroadcastStatus, BroadcastStatus>
        {
            {CfBroadcastStatus.Archived, BroadcastStatus.ARCHIVED},
            {CfBroadcastStatus.Finished, BroadcastStatus.FINISHED},
            {CfBroadcastStatus.Running, BroadcastStatus.RUNNING},
            {CfBroadcastStatus.StartPending, BroadcastStatus.START_PENDING},
            {CfBroadcastStatus.Stopped, BroadcastStatus.STOPPED},
        };

        internal static CfBroadcastStatus FromSoapBroadcastStatus(BroadcastStatus source)
        {
            if (DicSoapBroadcastStatus.ContainsKey(source))
            {
                return DicSoapBroadcastStatus[source];
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
