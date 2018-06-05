namespace Converter.Domain
{
    public interface IFileConverter
    {
        string Convert(string filepath);
    }
    public class FileConverter : IFileConverter
    {
        private readonly IFileReader _reader;
        private readonly IFileWriter _writer;
        public FileConverter(IFileReader reader,IFileWriter writer)
        {
            _reader = reader;_writer = writer;
        }
        public string Convert(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return "Err";
            string xmlSave = string.Empty;
            try
            {
                string strFileData = Read(filepath);
                xmlSave= Write(strFileData);
            }
            catch (System.Exception ex)
            {
                throw ex; // yell //shout //log
            }
            return xmlSave;
        }
        string Read(string filepath)
        {
            return _reader.ReadFile(filepath);
        }
        string Write(string strFileData)
        {
            return _writer.Write(strFileData);
        }
    }
}
