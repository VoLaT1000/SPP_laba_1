

using System.Xml;
using System.Xml.Serialization;
using TracerLibrary;

namespace SerializeLibrary
{
    public class XMLTracerSerializer : ITracerSerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var data = traceResult.ThreadTraces.Values.ToArray();
            var xmlSerializer = new XmlSerializer(data.GetType());
            string result = "";
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xmlWriter, data);
                }
                result = stringWriter.ToString();
            }
            return result.Replace("ArrayOfThreads", "root");
        }
    }
}
