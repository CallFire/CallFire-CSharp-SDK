using System;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastCommandMapper
    {
        internal static readonly TwoWayMapper<BroadcastCommand, CfBroadcastCommand> DicBroadcastCommands = new TwoWayMapper
            <BroadcastCommand, CfBroadcastCommand>
        {
            {BroadcastCommand.ARCHIVE, CfBroadcastCommand.Archive},
            {BroadcastCommand.STOP, CfBroadcastCommand.Stop},
            {BroadcastCommand.START, CfBroadcastCommand.Start},
        };

        internal static CfBroadcastCommand FromSoapBroadcastCommand(BroadcastCommand source)
        {
            if (DicBroadcastCommands.ContainsKey(source))
            {
                return DicBroadcastCommands[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }

        internal static BroadcastCommand ToSoapContactBatch(CfBroadcastCommand source)
        {
            if (DicBroadcastCommands.ContainsKey(source))
            {
                return DicBroadcastCommands[source];
            }
            throw new NotSupportedException(string.Format("The source {0} is not validated to be mapped", source));
        }
    }
}
