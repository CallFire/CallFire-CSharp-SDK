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
            // TODO 
            //var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = EnumeratedMapper.EnumFromSoapEnumerated<CfActionState>(source.State);
            //var label = LabelMapper.FromLabel(source.Label);
            var callRecord = CallRecordMapper.FromCallRecord(source.CallRecord);
            return new CfCall(source.FromNumber, null, state, source.BatchId, source.BroadcastId,
                source.ContactId, source.Inbound, source.Created, source.Modified, source.FinalResult, null, source.id, callRecord);
        }

        internal static Call ToCall(CfCall source)
        {
            if (source == null)
            {
                return null;
            }
            // TODO 
            //var toNumber = ToNumberMapper.FromToNumber(source.ToNumber);
            var state = EnumeratedMapper.ScreamingSnakeCase(source.State.ToString());
            //var label = LabelMapper.FromLabel(source.Label);
            var callRecord = CallRecordMapper.ToCallRecord(source.CallRecord);
            return new Call(source.FromNumber, null, state, source.BatchId, source.BroadcastId,
                source.ContactId, source.Inbound, source.Created, source.Modified, source.FinalResult, null, source.Id, callRecord);
        }
    }
}
