namespace Converter.Domain
{
    public interface IFileManager
    {
        string ConvertDocument(string fromfilepath);
    }
    class FileManager : IFileManager
    {
        private readonly IFileConverter _fileConverter;
        public FileManager(IFileConverter fileConverter)
        {
            _fileConverter = fileConverter;
        }
        public string ConvertDocument(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return "Err";
            return _fileConverter.Convert(filepath);
        }
    }
}
