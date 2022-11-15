using PrintersLibrary;
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
            TraceResult traceResult = tracer.GetTraceResult();
            int test = traceResult.ThreadTraces[0].MethodDatas.Count;
            string result = serializotor.Serialize(tracer.GetTraceResult());
            IPrinter CONSOLEprinter = new ConsolePrinter();
            IPrinter JSONprinter = new FilePrinter("../../../JSONResult.xml");
            JSONprinter.Print(result);
            CONSOLEprinter.Print(result);
            serializotor = new XMLTracerSerializer();
            result = serializotor.Serialize(tracer.GetTraceResult());
            IPrinter XMLprinter = new FilePrinter("../../../XMLResult.xml");
            XMLprinter.Print(result);
            CONSOLEprinter.Print(result);
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
