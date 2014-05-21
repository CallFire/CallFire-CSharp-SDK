using System.Xml.Serialization;

[XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.callfire.com/resource")]
[XmlRoot("ResourceReference", Namespace = "http://api.callfire.com/resource", IsNullable = false)]
// ReSharper disable once CheckNamespace
public class ResourceReference
{
    [XmlAttribute("Id")]
    public long Id { get; set; }

    [XmlAttribute("Location")]
    public string Location { get; set; }
}

