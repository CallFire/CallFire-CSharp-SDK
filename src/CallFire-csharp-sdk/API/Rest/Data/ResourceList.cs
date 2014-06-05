using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.API.Rest.Data
{
    [XmlType(AnonymousType = true, Namespace = CallFireNamespace.Resource)]
    [XmlRoot("ResourceList", Namespace = CallFireNamespace.Resource, IsNullable = false)]
    public class ResourceList
    {
        [XmlAttribute("totalResults")]
        public long TotalResults { get; set; }

        [XmlElement("Broadcast", typeof(Broadcast), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("ContactBatch", typeof(ContactBatch), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("BroadcastSchedule", typeof(BroadcastSchedule), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Subscription", typeof(Subscription), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Region", typeof(Region), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Number", typeof(Number), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Keyword", typeof(Keyword), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Label", typeof(Label), Namespace = CallFireNamespace.Data, Order = 0)]
        public object[] Resource { get; set; }
    }
}
