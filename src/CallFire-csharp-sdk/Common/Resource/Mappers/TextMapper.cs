using System;
using System.Collections.Generic;
using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class TextMapper
    {
        private const char Delimiter = '_';

        internal static CfText FromText(Text source)
        {
            if (source == null)
            {
                return null;
            }
            var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = (CfActionState) Enum.Parse(typeof(CfActionState), string.Format("{0}{1}", source.State.First(), source.State.Substring(1).ToLower()));
            //var finalResult = (CfActionState) Enum.Parse(EnumeratedMapper.EnumToLower(source.FinalResult.Split(Delimiter)));
            /*return new CfText(source.FromNumber, toNumber, state, source.BatchId, source.BroadcastId,
                    source.ContactId, source.Inbound, source.Created, source.Modified, source.FinalResult, source.Label, source.id,
                    source.Message, source.TextRecord);*/
            return null;
        }

        internal static Text ToText(CfText source)
        {
            if (source == null)
            {
                return null;
            }
            var toNumber = ToNumberMapper.ToToNumber(source.ToNumber);
            /*return new Text(source.FromNumber, toNumber, source.State.ToString().ToUpper(), source.BatchId, source.BroadcastId,
                    source.ContactId, source.Inbound, source.Created, source.Modified, source.FinalResult, source.Label, source.Id,
                    source.Message, source.TextRecord);*/
            return null;
        }
    }
}
