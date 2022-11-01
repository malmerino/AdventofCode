using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SpaceStation.Utilities.XML
{
    public static class ObjectXmlSerializer
    {
        public static T Deserialize<T>(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = XmlReader.Create(filepath))
            {
                if (serializer.CanDeserialize(reader))
                {
                    return (T)serializer.Deserialize(reader);
                }
                throw new Exception("Unsupported / Non-serializable file given");
            }
        }

        public static void Serialize<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (XmlWriter writer = XmlWriter.Create(filePath, new XmlWriterSettings()
            {
                       Indent = true,
            }))
            {
                serializer.Serialize(writer, obj);
            }
        }

    }
}
