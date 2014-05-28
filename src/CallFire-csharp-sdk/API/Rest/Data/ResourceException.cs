using System.Xml.Serialization;

namespace CallFire_csharp_sdk.API.Rest.Data
{
    [XmlType(AnonymousType = true, Namespace = CallFireNamespace.Resource)]
    [XmlRoot("ResourceException", Namespace = CallFireNamespace.Resource, IsNullable = false)]
    public class ResourceException
    {
        [XmlElement("message")]
        public string Message { get; set; }
    }
}
