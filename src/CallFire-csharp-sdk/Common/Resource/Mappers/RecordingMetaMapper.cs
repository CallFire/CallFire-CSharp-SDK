using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class RecordingMetaMapper
    {
        internal static CfRecordingMeta[] FromRecordingMeta(RecordingMeta[] source)
        {
            return source == null ? null : source.Select(FromRecordingMeta).ToArray();
        }

        internal static RecordingMeta[] ToRecordingMeta(CfRecordingMeta[] source)
        {
            return source == null ? null : source.Select(ToRecordingMeta).ToArray();
        }

        internal static CfRecordingMeta FromRecordingMeta(RecordingMeta source)
        {
            return source == null ? null : new CfRecordingMeta(source.Name, source.Created, source.LengthInSeconds, source.Link, source.id);
        }

        internal static RecordingMeta ToRecordingMeta(CfRecordingMeta source)
        {
            return source == null ? null : new RecordingMeta(source.Name, source.Created, source.LengthInSeconds, source.Link, source.Id);
        }
    }
}
