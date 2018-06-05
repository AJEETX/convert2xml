using Converter.Helper;
using System.IO;

namespace Converter.Domain
{
    public interface IFileConverter
    {
        string Convert(string strFilepath);
    }
    public class FileConverter : IFileConverter
    {
        private const string strSaveFilePath = @"PurchaseOrder.xml";
        private readonly IFormatData _formatData;
        public FileConverter(IFormatData formatData)
        {
            _formatData = formatData;
        }
        public string Convert(string strFilepath)
        {
            if (string.IsNullOrEmpty(strFilepath)) return "Err";
            string strXmlSavedFileName = string.Empty;
            try
            {
                string strFileData = GetStringData(strFilepath);
                strXmlSavedFileName = Convert2xml(strFileData);
            }
            catch (System.Exception ex)
            {
                //throw // catch //log // yell ??// issue in converting
                throw ex; // yell //shout //log
            }
            return strXmlSavedFileName;
        }
        string GetStringData(string strFilepath)
        {
            return File.ReadAllText(strFilepath);
        }
        string Convert2xml(string strFileData)
        {
            var purhaseOrders = _formatData.ConvertString2Object(strFileData); //convert 2 orders collection
            purhaseOrders.Save2xml(strSaveFilePath);   // save to file path
            return strSaveFilePath;
        }
    }
}
