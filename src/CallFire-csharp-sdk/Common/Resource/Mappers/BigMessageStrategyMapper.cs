using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BigMessageStrategyMapper
    {
        internal static readonly TwoWayMapper<BigMessageStrategy, CfBigMessageStrategy> DicBigMessageStrategy = new TwoWayMapper
            <BigMessageStrategy, CfBigMessageStrategy>
        {
            {BigMessageStrategy.DO_NOT_SEND, CfBigMessageStrategy.DoNotSend},
            {BigMessageStrategy.SEND_MULTIPLE, CfBigMessageStrategy.SendMultiple},
            {BigMessageStrategy.TRIM, CfBigMessageStrategy.Trim}
        };

        internal static CfBigMessageStrategy FromBigMessageStrategy(BigMessageStrategy source)
        {
            if (DicBigMessageStrategy.ContainsKey(source))
            {
                return DicBigMessageStrategy[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static BigMessageStrategy ToBigMessageStrategy(CfBigMessageStrategy source)
        {
            if (DicBigMessageStrategy.ContainsKey(source))
            {
                return DicBigMessageStrategy[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
