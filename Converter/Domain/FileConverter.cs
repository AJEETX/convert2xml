using Converter.Helper;
using System.IO;

namespace Converter.Domain
{
    public interface IFileConverter
    {
        string Convert(string filepath);
    }
    public class FileConverter : IFileConverter
    {
        private const string saveFilePath = @"PurchaseOrder.xml";
        private readonly IFormatData _formatData;
        public FileConverter(IFormatData formatData)
        {
            _formatData = formatData;
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
            return File.ReadAllText(filepath);
        }
        string Write(string fileData)
        {
            var purhaseOrders = _formatData.ConvertString2Object(fileData);
            purhaseOrders.Save2xml(saveFilePath);
            return saveFilePath;
        }
    }
}
