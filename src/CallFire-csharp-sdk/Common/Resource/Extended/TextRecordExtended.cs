using System;
// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class TextRecord
    {
        public TextRecord()
        {
        }
        
        public TextRecord(string result, DateTime finishTime, float billedAmount, ActionRecordQuestionResponse[] questionResponse, long identifier, string message)
        {
            Result = result;
            FinishTime = finishTime;
            BilledAmount = billedAmount;
            QuestionResponse = questionResponse;
            id = identifier;
            Message = message;
        }
    }
}
