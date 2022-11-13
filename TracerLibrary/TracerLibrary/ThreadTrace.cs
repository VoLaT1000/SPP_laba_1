namespace TracerLibrary
{
    public class ThreadTrace
    {
        public int ThreadId { get; set; }
        public long ThreadTime { get; set; }
        public List<MethodData> MethodDatas { get; set; } = new();
        public ThreadTrace(int threadId)
        {
            ThreadId = threadId;
        }
        public ThreadTrace() { }
        public void Push(string methodName, string className)
        {
            MethodDatas.Add(new MethodData(methodName, className));
        }
        public void Pop(string methodName, string className)
        {
            int methodPos = MethodDatas.FindLastIndex(m => m.MethodName == methodName && m.ClassName == className);

            if (methodPos == -1)
            {
                throw new ArgumentException($"No such class or method: {methodName} in {className}");
            }
            if (methodPos != MethodDatas.Count - 1)
            {
                int sizeOfNested = MethodDatas.Count - methodPos - 1;
                MethodDatas[methodPos].SetNested(MethodDatas.GetRange(methodPos + 1, sizeOfNested));
                MethodDatas.RemoveRange(methodPos + 1, sizeOfNested);
            }
            MethodDatas[methodPos].CalculateTime();
            ThreadTime += MethodDatas[methodPos].Time;
        }
    }
}
