using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CallMapper
    {
        internal static CfCall[] FromCall(Call[] source)
        {
            return source == null ? null : source.Select(FromCall).ToArray();
        }

        internal static Call[] ToCall(CfCall[] source)
        {
            return source == null ? null : source.Select(ToCall).ToArray();
        }

        internal static CfCall FromCall(Call source)
        {
            if (source == null)
            {
                return null;
            }
            var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = EnumeratedMapper.EnumFromSoapEnumerated<CfActionState>(source.State);
            var label = LabelMapper.FromLabel(source.Label);
            var callRecord = CallRecordMapper.FromCallRecord(source.CallRecord);
            var result = EnumeratedMapper.EnumFromSoapEnumerated<CfResult>(source.FinalResult);
            return new CfCall(source.FromNumber, toNumber, state, source.BatchId, source.BroadcastId,
                source.ContactId, source.Inbound, source.Created, source.Modified, result, label, source.id, callRecord);
        }

        internal static Call ToCall(CfCall source)
        {
            return source == null ? null : new Call(source);
        }
    }
}
