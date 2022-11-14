namespace PrintersLibrary
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }
    }
}