using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CallRecord
    {
        public CallRecord()
        {
        }
        
        public CallRecord(CfCallRecord source)
        {
            Result = EnumeratedMapper.ScreamingSnakeCase(source.Result.ToString());
            FinishTime = source.FinishTime;
            BilledAmount = source.BilledAmount;
            QuestionResponse = ActionRecordQuestionResponseMapper.ToActionRecordQuestionResponse(source.QuestionResponse);
            id = source.Id;
            if (source.OriginateTime.HasValue)
            {
                OriginateTime = source.OriginateTime.Value;
                OriginateTimeSpecified = true;
            }
            if (source.AnswerTime.HasValue)
            {
                AnswerTime = source.AnswerTime.Value;
                AnswerTimeSpecified = true;
            }
            Duration = source.Duration;
            RecordingMeta = RecordingMetaMapper.ToRecordingMeta(source.RecordingMeta);
        }
    }
}
