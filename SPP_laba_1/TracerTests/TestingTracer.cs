using TracerLibrary;

namespace TracerTests
{
    public class TestingTracer
    {
        Tracer tracer = new Tracer(new TraceResult());
        public void Method_1()
        {
            int a = 0;
            tracer.StartTrace();
            for (int i = 0; i < 1000; i++)
            {
                a++;
            }
            Thread.Sleep(100);
            tracer.StopTrace();
        }
        public void Method_2()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            int a = 1;
            for (int i = 0; i < 1000; i++)
            {
                a = 2 * a;
            }
            tracer.StopTrace();
        }
        [Fact]
        public void OneThread_OneMethod()
        {
            Method_1();
            TraceResult result = tracer.GetTraceResult();
            Assert.True(result.ThreadTraces.Count == 1);
            int first = result.ThreadTraces.Keys.First(i => i > -1);
            Assert.True(result.ThreadTraces[first].MethodDatas.Count == 1);
        }
        [Fact]
        public void OneThread_TwoMethod()
        {
            Method_1();
            Method_2();
            TraceResult result = tracer.GetTraceResult();
            Assert.True(result.ThreadTraces.Count == 1);
            int first = result.ThreadTraces.Keys.First(i => i > -1);
            Assert.True(result.ThreadTraces[first].MethodDatas.Count == 2);
        }
        [Fact]
        public void TwoThread_TwoMethod()
        {
            Thread thread_1 = new Thread(Method_1);
            Thread thread_2 = new Thread(Method_2);
            thread_1.Start();
            thread_2.Start();
            thread_1.Join();
            thread_2.Join();
            TraceResult result = tracer.GetTraceResult();
            Assert.True(result.ThreadTraces.Count == 2);
            int first = result.ThreadTraces.Keys.First(i => i > -1);
            int second = result.ThreadTraces.Keys.First(i => i != first);
            Assert.True(result.ThreadTraces[first].MethodDatas.Count == 1);
            Assert.True(result.ThreadTraces[second].MethodDatas.Count == 1);
        }
    }
}