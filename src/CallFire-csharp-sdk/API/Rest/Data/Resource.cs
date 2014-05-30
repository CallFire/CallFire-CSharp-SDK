using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;

namespace CallFire_csharp_sdk.API.Rest.Data
{
    [XmlType(AnonymousType = true, Namespace = CallfireNamespace.Resource)]
    [XmlRoot("Resource", Namespace = CallfireNamespace.Resource, IsNullable = false)]
    public class Resource
    {
        [XmlElement("Broadcast", typeof(Broadcast), Namespace = CallfireNamespace.Data, Order = 0)]
        [XmlElement("BroadcastStats", typeof(BroadcastStats), Namespace = CallfireNamespace.Data, Order = 0)]
        [XmlElement("ContactBatch", typeof(ContactBatch), Namespace = CallfireNamespace.Data, Order = 0)]
        [XmlElement("BroadcastSchedule", typeof(BroadcastSchedule), Namespace = CallfireNamespace.Data, Order = 0)]
        [XmlElement("Subscription", typeof(Subscription), Namespace = CallfireNamespace.Data, Order = 0)]
        public object Resources { get; set; }
    }
}

