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
            string xmlSavedFileName = string.Empty;
            try
            {
                string strFileData = GetStringData(filepath);
                xmlSavedFileName = Convert2xml(strFileData);
            }
            catch (System.Exception ex)
            {
                //throw // catch //log // yell ??// issue in converting
                throw ex; // yell //shout //log
            }
            return xmlSavedFileName;
        }
        string GetStringData(string filepath)
        {
            return File.ReadAllText(filepath);
        }
        string Convert2xml(string strFileData)
        {
            var purhaseOrders = _formatData.ConvertString2Object(strFileData); //convert 2 orders collection
            purhaseOrders.Save2xml(saveFilePath);   // save to file path
            return saveFilePath;
        }
    }
}
