using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BatchStatusMapper
    {
        private static readonly TwoWayMapper<BatchStatus, CfBatchStatus> DicBatchStatus =
            new TwoWayMapper<BatchStatus, CfBatchStatus>
            {
                {BatchStatus.ACTIVE, CfBatchStatus.Active},
                {BatchStatus.ERRORS, CfBatchStatus.Errors},
                {BatchStatus.NEW, CfBatchStatus.New},
                {BatchStatus.SOURCE_ERROR, CfBatchStatus.SourceError},
                {BatchStatus.VALIDATING, CfBatchStatus.Validating}
            };

        internal static CfBatchStatus FromSoapBatchStatus(BatchStatus source)
        {
            if (DicBatchStatus.ContainsKey(source))
            {
                return DicBatchStatus[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static BatchStatus ToSoapBatchStatus(CfBatchStatus source)
        {
            if (DicBatchStatus.ContainsKey(source))
            {
                return DicBatchStatus[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
