using System.Xml.Serialization;

[XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.callfire.com/resource")]
[XmlRootAttribute("ResourceException", Namespace = "http://api.callfire.com/resource", IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceException
{
    [XmlElement("message")]
    public string Message { get; set; }
}
