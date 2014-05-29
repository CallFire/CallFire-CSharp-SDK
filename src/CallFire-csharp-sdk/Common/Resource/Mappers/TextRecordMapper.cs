using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class TextRecordMapper
    {
        internal static CfTextRecord[] FromTextRecord(TextRecord[] source)
        {
            return source == null ? null : source.Select(FromTextRecord).ToArray();
        }

        internal static TextRecord[] ToTextRecord(CfTextRecord[] source)
        {
            return source == null ? null : source.Select(ToTextRecord).ToArray();
        }

        internal static CfTextRecord FromTextRecord(TextRecord source)
        {
            if (source == null)
            {
                return null;
            }
            var result = EnumeratedMapper.EnumFromSoapEnumerated<CfResult>(source.Result);
            var questionResponse = ActionRecordQuestionResponseMapper.FromActionRecordQuestionResponse(source.QuestionResponse);
            return new CfTextRecord(result, source.FinishTime, source.BilledAmount, questionResponse, source.id, source.Message);
        }

        internal static TextRecord ToTextRecord(CfTextRecord source)
        {
            if (source == null)
            {
                return null;
            }
            var result = EnumeratedMapper.ScreamingSnakeCase(source.Result.ToString());
            var questionResponse = ActionRecordQuestionResponseMapper.ToActionRecordQuestionResponse(source.QuestionResponse);
            return new TextRecord(result, source.FinishTime, source.BilledAmount, questionResponse, source.Id, source.Message);
        }
    }
}
