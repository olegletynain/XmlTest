using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System;
using System.Collections.Generic;

namespace XmlTestRead
{
    [XmlRoot("data")]
    public class Data
    {
        [XmlArray("audit_values")]
        [XmlArrayItem("audit_value", IsNullable = true)]
        public AuditValue[] AuditValues { get; set; }
    }

    [XmlRoot("audit_value")]
    public class AuditValue
    {
        [XmlElement("week", typeof(Week))]
        public Week Week;
    }

    [XmlRoot("week")]
    public class Week : IXmlSerializable
    {
        public Dictionary<string, double> Values = new Dictionary<string, double>();

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            var sub = reader.ReadSubtree();
            do
            {
                if (sub.NodeType == XmlNodeType.Element)
                {
                    string name = sub.Name;
                    string val = sub.ReadElementContentAsString();
                    Values.Add(name, Convert.ToDouble(val));
                }
            } while (sub.Read());
        }

        public void WriteXml(XmlWriter writer)
        {

        }
    }
}
