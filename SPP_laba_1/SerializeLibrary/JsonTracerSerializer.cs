using System.Text.Json;
using TracerLibrary;

namespace SerializeLibrary
{
    public class JsonTracerSerializer : ITracerSerializer
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public string Serialize(TraceResult traceResult)
        {
            var arrays = new Dictionary<string, ICollection<ThreadTrace>>
            {
                { "threads", traceResult.ThreadTraces.Values}
            };
            return JsonSerializer.Serialize(arrays, options);
        }
    }
}