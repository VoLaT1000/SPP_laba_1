using System.Text;

namespace PrintersLibrary
{
    public class FilePrinter : IPrinter
    {
        private readonly string _filename;
        public FilePrinter(string pathFile)
        {
            _filename = pathFile;
        }
        public void Print(string data)
        {
            using FileStream fileStream = new FileStream(_filename, FileMode.Create);
            var bytes = Encoding.Default.GetBytes(data);
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
