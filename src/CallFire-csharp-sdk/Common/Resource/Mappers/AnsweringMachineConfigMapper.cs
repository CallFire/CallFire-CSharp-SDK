using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class AnsweringMachineConfigMapper
    {
        private static readonly TwoWayMapper<AnsweringMachineConfig, CfAnsweringMachineConfig> DicAnsweringMachineConfig = new TwoWayMapper<AnsweringMachineConfig, CfAnsweringMachineConfig>
        {
            {AnsweringMachineConfig.AM_AND_LIVE, CfAnsweringMachineConfig.AmAndLive},
            {AnsweringMachineConfig.AM_ONLY, CfAnsweringMachineConfig.AmOnly},
            {AnsweringMachineConfig.LIVE_IMMEDIATE, CfAnsweringMachineConfig.LiveImmediate},
            {AnsweringMachineConfig.LIVE_WITH_AMD, CfAnsweringMachineConfig.LiveWithAmd}
        };

        internal static CfAnsweringMachineConfig FromSoapAnsweringMachineConfig(AnsweringMachineConfig source)
        {
            if (DicAnsweringMachineConfig.ContainsKey(source))
            {
                return DicAnsweringMachineConfig[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static AnsweringMachineConfig ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig source)
        {
            if (DicAnsweringMachineConfig.ContainsKey(source))
            {
                return DicAnsweringMachineConfig[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
