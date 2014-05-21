using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Soap;

[XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.callfire.com/resource")]
[XmlRoot("Resource", Namespace = "http://api.callfire.com/resource", IsNullable = false)]
// ReSharper disable once CheckNamespace
public class Resource
{
    [XmlElementAttribute("Broadcast", typeof(Broadcast), Namespace = "http://api.callfire.com/data", Order = 0)]
    [XmlElementAttribute("BroadcastStats", typeof(BroadcastStats), Namespace = "http://api.callfire.com/data", Order = 0)]
    [XmlElementAttribute("ContactBatch", typeof(ContactBatch), Namespace = "http://api.callfire.com/data", Order = 0)]
    [XmlElementAttribute("BroadcastSchedule", typeof(BroadcastSchedule), Namespace = "http://api.callfire.com/data", Order = 0)]
    [XmlElementAttribute("Subscription", typeof(Subscription), Namespace = "http://api.callfire.com/data", Order = 0)]
    public object Resources { get; set; }
}

