using Converter.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter.Domain
{
    public interface IFormatData
    {
        IEnumerable<PurchaseOrder> ConvertString2Object(string fileData);
    }
    class FormatData : IFormatData
    {
        private const string _purchaseOrderPattern = @"(?<el>H\,.*)";
        private readonly IPurchaseOrderGenerator _orderGenerator;
        public FormatData(IPurchaseOrderGenerator orderGenerator)
        {
            _orderGenerator = orderGenerator;
        }
        public IEnumerable<PurchaseOrder> ConvertString2Object(string fileData)
        {
            IEnumerable<PurchaseOrder> pos = null;
            if (string.IsNullOrEmpty(fileData)) return null;
            try
            {
                pos = FormatFileData(fileData);
            }
            catch (System.Exception)
            {
                //catch and continue
            }
             return pos;
        }

        IEnumerable<PurchaseOrder> FormatFileData(string fileData)
        {
            MatchCollection purchaseOrders = Regex.Matches(fileData, _purchaseOrderPattern);

            foreach (string purchaseOrder in purchaseOrders.Cast<Match>().Select(match => match.Value))
            {
                yield return _orderGenerator.GenerateOrder(fileData, purchaseOrder);
            }
        }
    }
}
