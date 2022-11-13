using TracerLibrary;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            var program = new Program();
            var thread = new Thread(program.DoWork);
            ITracer tracer = new Tracer(new TraceResult());
            thread.Start(tracer);
            thread.Join();
            var traceResult = new TraceResult();
            traceResult = tracer.GetTraceResult();
            foreach (var trace in traceResult.ThreadTraces)
            {
                Console.WriteLine($"id: {trace.Value.ThreadId}   time: {trace.Value.ThreadTime}");
            }
            Console.ReadKey();
        }
        public void DoWork(object o)
        {
            var tracer = (Tracer)o;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}
