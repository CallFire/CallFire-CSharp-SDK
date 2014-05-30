using System;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class CallRecord
    {
        public CallRecord()
        {
        }
        
        public CallRecord(string result, DateTime finishTime, float billedAmount, ActionRecordQuestionResponse[] questionResponse, long identifier,
            DateTime originateTime, DateTime answerTime, int duration, RecordingMeta[] recordingMeta)
        {
            Result = result;
            FinishTime = finishTime;
            BilledAmount = billedAmount;
            QuestionResponse = questionResponse;
            id = identifier;
            OriginateTime = originateTime;
            AnswerTime = answerTime;
            Duration = duration;
            RecordingMeta = recordingMeta;
        }
    }
}
