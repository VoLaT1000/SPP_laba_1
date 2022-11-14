using SerializeLibrary;
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
            ITracerSerializer serializotor = new JsonTracerSerializer();
            string result = serializotor.Serialize(tracer.GetTraceResult());
            Console.WriteLine(result);
            serializotor = new XMLTracerSerializer();
            result = serializotor.Serialize(tracer.GetTraceResult());
            Console.WriteLine(result);
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
