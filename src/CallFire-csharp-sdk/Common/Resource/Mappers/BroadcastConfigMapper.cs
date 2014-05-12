using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastConfigMapper
    {
        private static readonly Dictionary<BroadcastType, Func<BroadcastConfig, CfBroadcastConfig>>
        DictionaryFromConfig = new Dictionary<BroadcastType, Func<BroadcastConfig, CfBroadcastConfig>>
        {
            {
                BroadcastType.IVR,
                x => IvrBroadcastConfigMapper.FromSoapIvrBroadcastConfig((IvrBroadcastConfig) x)
            },

            {
                BroadcastType.TEXT,
                x => TextBroadcastConfigMapper.FromSoapTextBroadcastConfig((TextBroadcastConfig) x)
            },

            {
                BroadcastType.VOICE,
                x => VoiceBroadcastConfigMapper.FromSoapVoiceBroadcastConfig((VoiceBroadcastConfig) x)
            }
        };

        private static readonly Dictionary<CfBroadcastType, Func<CfBroadcastConfig, BroadcastConfig>>
        DictionaryToConfig = new Dictionary<CfBroadcastType, Func<CfBroadcastConfig, BroadcastConfig>>
        {
            {
                CfBroadcastType.Ivr,
                x => IvrBroadcastConfigMapper.ToSoapIvrBroadcastConfig((CfIvrBroadcastConfig) x)
            },

            {
                CfBroadcastType.Text,
                x => TextBroadcastConfigMapper.ToSoapTextBroadcastConfig((CfTextBroadcastConfig) x)
            },

            {
                CfBroadcastType.Voice,
                x => VoiceBroadcastConfigMapper.ToSoapVoiceBroadcastConfig((CfVoiceBroadcastConfig) x)
            }
        };

        internal static CfBroadcastConfig FromBroadcastConfig(BroadcastConfig source,
        BroadcastType type)
        {
            if (source == null || !DictionaryFromConfig.ContainsKey(type))
            {
                return null;
            }

            return DictionaryFromConfig[type].Invoke(source);
        }

        internal static BroadcastConfig ToBroadcastConfig(CfBroadcastConfig source, CfBroadcastType type)
        {
            if (source == null || !DictionaryToConfig.ContainsKey(type))
            {
                return null;
            }

            return DictionaryToConfig[type].Invoke(source);
        }
    }
}
