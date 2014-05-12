using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    public class BatchStatusMapper
    {
        private static readonly Dictionary<BatchStatus, CfBatchStatus> DicSoapBatchStatus =
            new Dictionary<BatchStatus, CfBatchStatus>
            {
                {BatchStatus.ACTIVE, CfBatchStatus.Active},
                {BatchStatus.ERRORS, CfBatchStatus.Errors},
                {BatchStatus.NEW, CfBatchStatus.New},
                {BatchStatus.SOURCE_ERROR, CfBatchStatus.SourceError},
                {BatchStatus.VALIDATING, CfBatchStatus.Validating}
            };

        private static readonly Dictionary<CfBatchStatus, BatchStatus> DicBatchStatus =
            new Dictionary<CfBatchStatus, BatchStatus>
            {
                {CfBatchStatus.Active, BatchStatus.ACTIVE},
                {CfBatchStatus.Errors, BatchStatus.ERRORS},
                {CfBatchStatus.New, BatchStatus.NEW},
                {CfBatchStatus.SourceError, BatchStatus.SOURCE_ERROR},
                {CfBatchStatus.Validating, BatchStatus.VALIDATING}
            };

        internal static CfBatchStatus FromSoapBatchStatus(BatchStatus source)
        {
            if (DicSoapBatchStatus.ContainsKey(source))
            {
                return DicSoapBatchStatus[source];
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
