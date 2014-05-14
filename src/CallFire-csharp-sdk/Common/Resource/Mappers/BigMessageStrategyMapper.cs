using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BigMessageStrategyMapper
    {
        internal static readonly Dictionary<BigMessageStrategy, CfBigMessageStrategy> DicSoapBigMessageStrategy = new Dictionary
            <BigMessageStrategy, CfBigMessageStrategy>
        {
            {BigMessageStrategy.DO_NOT_SEND, CfBigMessageStrategy.DoNotSend},
            {BigMessageStrategy.SEND_MULTIPLE, CfBigMessageStrategy.SendMultiple},
            {BigMessageStrategy.TRIM, CfBigMessageStrategy.Trim}
        };

        internal static readonly Dictionary<CfBigMessageStrategy, BigMessageStrategy> DicBigMessageStrategy = new Dictionary
            <CfBigMessageStrategy, BigMessageStrategy>
        {
            {CfBigMessageStrategy.DoNotSend, BigMessageStrategy.DO_NOT_SEND},
            {CfBigMessageStrategy.SendMultiple, BigMessageStrategy.SEND_MULTIPLE},
            {CfBigMessageStrategy.Trim, BigMessageStrategy.TRIM}
        };

        internal static CfBigMessageStrategy FromBigMessageStrategy(BigMessageStrategy source)
        {
            if (DicSoapBigMessageStrategy.ContainsKey(source))
            {
                return DicSoapBigMessageStrategy[source];
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
