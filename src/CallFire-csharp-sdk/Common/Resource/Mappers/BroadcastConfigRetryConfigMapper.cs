using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastConfigRetryConfigMapper
    {
        internal static CfBroadcastConfigRetryConfig FromBroadcastConfigRetryConfig(BroadcastConfigRetryConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var retry = EnumeratedMapper.FromSoapEnumerated<CfResult>(source.RetryResults);
            var retryPhoneType = EnumeratedMapper.FromSoapEnumerated<CfRetryPhoneType>(source.RetryPhoneTypes);
            return new CfBroadcastConfigRetryConfig(source.MaxAttempts, source.MinutesBetweenAttempts, retry, retryPhoneType);
        }

        internal static BroadcastConfigRetryConfig ToBroadcastConfigRetryConfig(CfBroadcastConfigRetryConfig source)
        {
            if (source == null)
            {
                return null;
            }
            var retry = EnumeratedMapper.ToSoapEnumerated(source.RetryResults);
            var retryPhoneType = EnumeratedMapper.ToSoapEnumerated(source.RetryPhoneTypes);
            return new BroadcastConfigRetryConfig(source.MaxAttempts, source.MinutesBetweenAttempts, retry, retryPhoneType);
        }
    }
}
