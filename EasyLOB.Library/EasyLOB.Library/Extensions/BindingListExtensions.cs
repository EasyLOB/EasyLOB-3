using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace EasyLOB.Library
{
    /// <summary>
    /// BindingList Extensions.
    /// </summary>
    public static class BindingListExtensions
    {
        /// <summary>
        /// Read BindingList from XML.
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="xml">XML</param>
        public static object FromXml<T>(this BindingList<T> list, string xml)
        {
            var serializer = new XmlSerializer(list.GetType());
            MemoryStream stream = new MemoryStream(xml.ToBinary());

            return serializer.Deserialize(stream);
        }

        /// <summary>
        /// Write BindingList to XML.
        /// </summary>
        /// <param name="list">Binding List</param>
        /// <returns>XML</returns>
        public static string ToXml<T>(this BindingList<T> list)
        {
            var serializer = new XmlSerializer(list.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, list);

            return stream.ToString();
        }
    }
}