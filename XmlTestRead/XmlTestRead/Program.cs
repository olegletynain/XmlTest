using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace XmlTestRead
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = null;
            string path = "test.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Data));

            StreamReader reader = new StreamReader(path);
            data = (Data)serializer.Deserialize(reader);
            reader.Close();
        }
    }
}
