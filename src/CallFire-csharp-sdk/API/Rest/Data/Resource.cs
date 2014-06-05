using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.API.Rest.Data
{
    [XmlType(AnonymousType = true, Namespace = CallFireNamespace.Resource)]
    [XmlRoot("Resource", Namespace = CallFireNamespace.Resource, IsNullable = false)]
    public class Resource
    {
        [XmlElement("Broadcast", typeof(Broadcast), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("BroadcastStats", typeof(BroadcastStats), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("ContactBatch", typeof(ContactBatch), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("BroadcastSchedule", typeof(BroadcastSchedule), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Subscription", typeof(Subscription), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("Number", typeof(Number), Namespace = CallFireNamespace.Data, Order = 0)]
        [XmlElement("NumberOrder", typeof(NumberOrder), Namespace = CallFireNamespace.Data, Order = 0)]
        public object Resources { get; set; }
    }
}

