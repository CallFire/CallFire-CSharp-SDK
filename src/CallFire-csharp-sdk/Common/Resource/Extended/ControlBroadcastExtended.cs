using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ControlBroadcast
    {
        public ControlBroadcast()
        {
        }
        
        public ControlBroadcast(CfControlBroadcast cfControlBroadcast)
            : base(cfControlBroadcast.Id)
        {
            RequestId = cfControlBroadcast.RequestId;
            if (cfControlBroadcast.Command.HasValue)
            {
                Command = EnumeratedMapper.ToSoapEnumerated<BroadcastCommand>(cfControlBroadcast.Command.ToString());
                CommandSpecified = true;
            }
            if (cfControlBroadcast.MaxActive.HasValue)
            {
                MaxActive = cfControlBroadcast.MaxActive.Value;
                MaxActiveSpecified = true;
            }
        }
    }
}
