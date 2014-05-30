using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CallRecordMapper
    {
        internal static CfCallRecord[] FromCallRecord(CallRecord[] source)
        {
            return source == null ? null : source.Select(FromCallRecord).ToArray();
        }

        internal static CallRecord[] ToCallRecord(CfCallRecord[] source)
        {
            return source == null ? null : source.Select(ToCallRecord).ToArray();
        }

        internal static CfCallRecord FromCallRecord(CallRecord source)
        {
            if (source == null)
            {
                return null;
            }
            var result = EnumeratedMapper.EnumFromSoapEnumerated<CfResult>(source.Result);
            var questionResponse = ActionRecordQuestionResponseMapper.FromActionRecordQuestionResponse(source.QuestionResponse);
            var recordingMeta = RecordingMetaMapper.FromRecordingMeta(source.RecordingMeta);
            return new CfCallRecord(result, source.FinishTime, source.BilledAmount, questionResponse, source.id, source.OriginateTime,
                source.AnswerTime, source.Duration, recordingMeta);
        }

        internal static CallRecord ToCallRecord(CfCallRecord source)
        {
            if (source == null)
            {
                return null;
            }
            var result = EnumeratedMapper.ScreamingSnakeCase(source.Result.ToString());
            var questionResponse = ActionRecordQuestionResponseMapper.ToActionRecordQuestionResponse(source.QuestionResponse);
            var recordingMeta = RecordingMetaMapper.ToRecordingMeta(source.RecordingMeta);
            return new CallRecord(result, source.FinishTime, source.BilledAmount, questionResponse, source.Id, source.OriginateTime,
                source.AnswerTime, source.Duration, recordingMeta);
        }
    }
}
