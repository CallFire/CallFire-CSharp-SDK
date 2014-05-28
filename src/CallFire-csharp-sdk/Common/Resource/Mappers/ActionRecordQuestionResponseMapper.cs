using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ActionRecordQuestionResponseMapper
    {
        internal static CfActionRecordQuestionResponse[] FromActionRecordQuestionResponse(ActionRecordQuestionResponse[] source)
        {
            return source == null ? null : source.Select(FromActionRecordQuestionResponse).ToArray();
        }

        internal static ActionRecordQuestionResponse[] ToActionRecordQuestionResponse(CfActionRecordQuestionResponse[] source)
        {
            return source == null ? null : source.Select(ToActionRecordQuestionResponse).ToArray();
        }

        internal static CfActionRecordQuestionResponse FromActionRecordQuestionResponse(ActionRecordQuestionResponse source)
        {
            return source == null ? null : new CfActionRecordQuestionResponse(source.Question, source.Response);
        }

        internal static ActionRecordQuestionResponse ToActionRecordQuestionResponse(CfActionRecordQuestionResponse source)
        {
            return source == null ? null : new ActionRecordQuestionResponse();
        }
    }
}
