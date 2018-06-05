using System.IO;

namespace Converter.Domain
{
    public interface IFileReader
    {
        string ReadFile(string filepath);
    }
    class FileReader : IFileReader
    {
        public string ReadFile(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return "Err";
            return File.ReadAllText(filepath);
        }
    }
}
