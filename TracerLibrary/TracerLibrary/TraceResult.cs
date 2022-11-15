using System.Collections.Concurrent;

namespace TracerLibrary
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadTrace> ThreadTraces { get; private set; } = new();
        public ThreadTrace GetThreadTrace(int threadId)
        {
            return ThreadTraces.GetOrAdd(threadId, new ThreadTrace(threadId));
        }
    }
}