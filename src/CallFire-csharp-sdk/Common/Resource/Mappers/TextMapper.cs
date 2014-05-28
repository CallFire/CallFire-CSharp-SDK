using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal class TextMapper
    {
        internal static CfText[] FromText(Text[] source)
        {
            return source == null ? null : source.Select(FromText).ToArray();
        }

        internal static Text[] ToText(CfText[] source)
        {
            return source == null ? null : source.Select(ToText).ToArray();
        }

        internal static CfText FromText(Text source)
        {
            if (source == null)
            {
                return null;
            }
            var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = EnumeratedMapper.EnumFromSoapEnumerated<CfActionState>(source.State);
            var finalResult = EnumeratedMapper.EnumFromSoapEnumerated<CfResult>(source.FinalResult);
            var label = LabelMapper.FromLabel(source.Label);
            var textRecord = TextRecordMapper.FromTextRecord(source.TextRecord);
            return new CfText(source.FromNumber, toNumber, state, source.BatchId, source.BroadcastId,
                    source.ContactId, source.Inbound, source.Created, source.Modified, finalResult, label, source.id,
                    source.Message, textRecord);
        }

        internal static Text ToText(CfText source)
        {
            if (source == null)
            {
                return null;
            }
            var toNumber = ToNumberMapper.ToToNumber(source.ToNumber);
            var state = EnumeratedMapper.ScreamingSnakeCase(source.State.ToString());
            var finalResult = EnumeratedMapper.ScreamingSnakeCase(source.FinalResult.ToString());
            var label = LabelMapper.ToLabel(source.Label);
            var textRecord = TextRecordMapper.ToTextRecord(source.TextRecord);
            return new Text(source.FromNumber, toNumber, state, source.BatchId, source.BroadcastId,
                    source.ContactId, source.Inbound, source.Created, source.Modified, finalResult, label, source.Id,
                    source.Message, textRecord);
        }
    }
}
