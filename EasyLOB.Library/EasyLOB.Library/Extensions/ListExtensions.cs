using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EasyLOB.Library
{
    /// <summary>
    /// List Extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Read List from XML.
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="xml">XML</param>
        public static object FromXml<T>(this List<T> list, string xml)
        {
            var serializer = new XmlSerializer(list.GetType());
            MemoryStream stream = new MemoryStream(xml.ToBinary());

            return serializer.Deserialize(stream);
        }

        /// <summary>
        /// Write List to XML.
        /// </summary>
        /// <param name="list">List</param>
        /// <returns>XML</returns>
        public static string ToXml<T>(this List<T> list)
        {
            var serializer = new XmlSerializer(list.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, list);

            return stream.ToString();
        }
    }
}