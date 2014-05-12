using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class AnsweringMachineConfigMapper
    {
        private static readonly Dictionary<AnsweringMachineConfig, CfAnsweringMachineConfig> DicSoapAnsweringMachineConfig = new Dictionary<AnsweringMachineConfig, CfAnsweringMachineConfig>
        {
            {AnsweringMachineConfig.AM_AND_LIVE, CfAnsweringMachineConfig.AmAndLive},
            {AnsweringMachineConfig.AM_ONLY, CfAnsweringMachineConfig.AmOnly},
            {AnsweringMachineConfig.LIVE_IMMEDIATE, CfAnsweringMachineConfig.LiveImmediate},
            {AnsweringMachineConfig.LIVE_WITH_AMD, CfAnsweringMachineConfig.LiveWithAmd}
        };

        private static readonly Dictionary<CfAnsweringMachineConfig, AnsweringMachineConfig> DicAnsweringMachineConfig = new Dictionary<CfAnsweringMachineConfig, AnsweringMachineConfig>
        {
            {CfAnsweringMachineConfig.AmAndLive, AnsweringMachineConfig.AM_AND_LIVE},
            {CfAnsweringMachineConfig.AmOnly, AnsweringMachineConfig.AM_ONLY},
            {CfAnsweringMachineConfig.LiveImmediate, AnsweringMachineConfig.LIVE_IMMEDIATE},
            {CfAnsweringMachineConfig.LiveWithAmd, AnsweringMachineConfig.LIVE_WITH_AMD}
        };

        internal static CfAnsweringMachineConfig FromSoapAnsweringMachineConfig(AnsweringMachineConfig source)
        {
            if (DicSoapAnsweringMachineConfig.ContainsKey(source))
            {
                return DicSoapAnsweringMachineConfig[source];
            }
            throw new NotSupportedException(string.Format("Exception: Not supported. The source {0} is not validated to be mapped", source));
        }

        internal static AnsweringMachineConfig ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig source)
        {
            if (DicAnsweringMachineConfig.ContainsKey(source))
            {
                return DicAnsweringMachineConfig[source];
            }
            throw new NotSupportedException(string.Format("Exception: Not supported. The source {0} is not validated to be mapped", source));
        }
    }
}
