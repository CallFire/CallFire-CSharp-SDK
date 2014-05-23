using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;

[XmlTypeAttribute(AnonymousType = true, Namespace = Namespaces.NamespaceResource)]
[XmlRootAttribute("ResourceList", Namespace = Namespaces.NamespaceResource, IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceList
{
    [XmlAttribute("totalResults")]
    public long TotalResults { get; set; }

    [XmlElement("Broadcast", typeof(Broadcast), Namespace = Namespaces.NamespaceData, Order = 0)]
    [XmlElement("ContactBatch", typeof(ContactBatch), Namespace = Namespaces.NamespaceData, Order = 0)]
    [XmlElement("BroadcastSchedule", typeof(BroadcastSchedule), Namespace = Namespaces.NamespaceData, Order = 0)]
    [XmlElement("Subscription", typeof(Subscription), Namespace = Namespaces.NamespaceData, Order = 0)]
    public object[] Resource { get; set; }
}
