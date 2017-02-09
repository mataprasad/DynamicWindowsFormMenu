using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicWinMenu
{
    public class Helper
    {
        public static T DeserializeFromXML<T>(string xml)
        {
            using (StringReader stream = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T obj = (T)serializer.Deserialize(stream);
                stream.Close();
                return obj;
            }
        }

        public static string SerializeToXML<T>(T obj)
        {
            using (StringWriter stream = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, obj);
                stream.Close();
                return stream.ToString();
            }
        }
    }
}
