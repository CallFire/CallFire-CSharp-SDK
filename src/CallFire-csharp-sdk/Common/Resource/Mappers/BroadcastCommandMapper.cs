using System;
using System.Collections.Generic;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class BroadcastCommandMapper
    {
        internal static readonly Dictionary<BroadcastCommand, CfBroadcastCommand> DicSoapBroadcastCommands = new Dictionary
            <BroadcastCommand, CfBroadcastCommand>
        {
            {BroadcastCommand.ARCHIVE, CfBroadcastCommand.Archive},
            {BroadcastCommand.STOP, CfBroadcastCommand.Stop},
            {BroadcastCommand.START, CfBroadcastCommand.Start},
        };

        internal static readonly Dictionary<CfBroadcastCommand, BroadcastCommand> DicBroadcastCommands = new Dictionary
            <CfBroadcastCommand, BroadcastCommand>
        {
            {CfBroadcastCommand.Archive, BroadcastCommand.ARCHIVE},
            {CfBroadcastCommand.Stop, BroadcastCommand.STOP},
            {CfBroadcastCommand.Start, BroadcastCommand.START},
        };

        internal static CfBroadcastCommand FromSoapBroadcastCommand(BroadcastCommand source)
        {
            if (DicSoapBroadcastCommands.ContainsKey(source))
            {
                return DicSoapBroadcastCommands[source];
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
