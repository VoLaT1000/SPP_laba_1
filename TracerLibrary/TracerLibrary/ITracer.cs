namespace TracerLibrary
{
    public interface ITracer
    {
        // Вызывается в начале замеряемого метода
        void StartTrace();
        // Вызывается в конце замеряемого метода
        void StopTrace();
        // Получить результаты измерений
        TraceResult GetTraceResult();
    }
}
