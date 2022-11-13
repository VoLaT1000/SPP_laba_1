

using System.Diagnostics;

namespace TracerLibrary
{
    public class MethodData
    {
        public string? MethodName { get; set; }
        public string? ClassName { get; set; }
        private long time;
        public long Time
        {
            get
            {
                if (time == 0)
                {
                    throw new ArgumentException("Cannot measure time. Call StartTrace method before StopTrace");
                }
                return time;
            }
            set => time = value;
        }
        public List<MethodData>? NestedMethods { get; set; }
        private readonly Stopwatch _stopwatch = new();
        public MethodData(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
            _stopwatch.Start();
        }
        public MethodData() { }
        public void SetNested(List<MethodData> nestedMethods)
        {
            NestedMethods = nestedMethods;
        }
        public void CalculateTime()
        {
            _stopwatch.Stop();
            Time = _stopwatch.ElapsedMilliseconds;
        }
    }
}
