using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    class BroadcastConfigMapper
    {
        internal static CfBroadcastConfig FromBroadcastConfigRetryConfig(BroadcastConfig source, BroadcastType type)
        {
            if (source == null)
            {
                return null;
            }
            CfBroadcastConfig broadcastConfig = null;
            switch (type)
            {
                case BroadcastType.IVR:
                    {
                        var item = source as IvrBroadcastConfig;
                        broadcastConfig = IvrBroadcastConfigMapper.FromSoapIvrBroadcastConfig(item);
                    }
                    break;
                case BroadcastType.TEXT:
                    {
                        var item = source as TextBroadcastConfig;
                        broadcastConfig = TextBroadcastConfigMapper.FromSoapTextBroadcastConfig(item);
                    }
                    break;
                case BroadcastType.VOICE:
                    {
                        var item = source as VoiceBroadcastConfig;
                        broadcastConfig = VoiceBroadcastConfigMapper.FromSoapVoiceBroadcastConfig(item);
                    }
                    break;
            }
            return broadcastConfig;
        }
        
        internal static BroadcastConfig ToBroadcastConfigRetryConfig(CfBroadcastConfig source, CfBroadcastType type)
        {
            if (source == null)
            {
                return null;
            }
            BroadcastConfig broadcastConfig = null;
            switch (type)
            {
                case CfBroadcastType.Ivr:
                    {
                        var item = source as CfIvrBroadcastConfig;
                        broadcastConfig = IvrBroadcastConfigMapper.ToSoapIvrBroadcastConfig(item);
                    }
                    break;
                case CfBroadcastType.Text:
                    {
                        var item = source as CfTextBroadcastConfig;
                        broadcastConfig = TextBroadcastConfigMapper.ToSoapTextBroadcastConfig(item);
                    }
                    break;
                case CfBroadcastType.Voice:
                    {
                        var item = source as CfVoiceBroadcastConfig;
                        broadcastConfig = VoiceBroadcastConfigMapper.ToSoapVoiceBroadcastConfig(item);
                    }
                    break;
            }
            return broadcastConfig;
        }
    }
}
