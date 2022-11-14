using TracerLibrary;

namespace SerializeLibrary
{
    public interface ITracerSerializer
    {
        string Serialize(TraceResult traceResult);
    }
}
