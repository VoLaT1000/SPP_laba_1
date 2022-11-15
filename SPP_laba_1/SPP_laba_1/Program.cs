using PrintersLibrary;
using SerializeLibrary;
using TracerLibrary;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            ITracer tracer = new Tracer(new TraceResult());
            IPrinter CONSOLEprinter = new ConsolePrinter();
            IPrinter JSONprinter = new FilePrinter("../../../JSONResult.xml");
            IPrinter XMLprinter = new FilePrinter("../../../XMLResult.xml");
            ITracerSerializer JsonSerializotor = new JsonTracerSerializer();
            ITracerSerializer XMLSerializotor = new XMLTracerSerializer();

            var program = new Program();
            var thread_1 = new Thread(program.Method_1);
            var thread_2 = new Thread(program.Method_2);

            thread_1.Start(tracer);
            thread_2.Start(tracer);
            thread_1.Join();
            thread_2.Join();

            TraceResult traceResult = tracer.GetTraceResult();


            string JsonResult = JsonSerializotor.Serialize(tracer.GetTraceResult());
            string XMLResult = XMLSerializotor.Serialize(tracer.GetTraceResult());

            JSONprinter.Print(JsonResult);
            XMLprinter.Print(XMLResult);
            CONSOLEprinter.Print(JsonResult);
            CONSOLEprinter.Print(XMLResult);
            Console.ReadKey();
        }
        public void Method_1(object o)
        {
            var tracer = (Tracer)o;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
        public void Method_2(object o)
        {
            var tracer = (Tracer)o;
            tracer.StartTrace();
            Thread.Sleep(200);
            tracer.StopTrace();
        }
    }
}
