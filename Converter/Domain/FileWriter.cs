using Converter.Model;
using Converter.Helper;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Converter.Domain
{
    public interface IFileWriter
    {
        string Write(string fileData);
    }
    class FileWriter : IFileWriter
    {
        private readonly IFormatData _formatData;
        private const string saveFilePath = @"PurchaseOrder.xml";
        public FileWriter(IFormatData formatData)
        {
            _formatData = formatData;
        }
        public string Write(string fileData)
        {
            if (string.IsNullOrEmpty(fileData)) return "Err";
            
            return ConvertString2xml(fileData);
        }
        string ConvertString2xml(string fileData)
        {
            var purhaseOrders = _formatData.ConvertString2Object(fileData);
            purhaseOrders.Save2xml(saveFilePath);
            return saveFilePath;
        }       
    }
}
