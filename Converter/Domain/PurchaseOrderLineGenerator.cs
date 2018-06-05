using Converter.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter.Domain
{
    public interface IPurchaseOrderLineGenerator
    {
        IEnumerable<PurchaseOrderLine> GetOrderLine(string fileData, string poNumner);
    }
    class PurchaseOrderLineGenerator : IPurchaseOrderLineGenerator
    {
        public IEnumerable<PurchaseOrderLine> GetOrderLine(string fileData, string poNumber)
        {
            IEnumerable<PurchaseOrderLine> purchaseOrderLines = null;
            try
            {
                purchaseOrderLines = CreateOrderLine(fileData, poNumber);
            }
            catch (System.Exception)
            {
                throw; //yell// issue in lineOrder
            }
            return purchaseOrderLines;
        }

        IEnumerable<PurchaseOrderLine> CreateOrderLine(string fileData, string poNumber)
        {
            string _linePattern = @"(?<el>D\," + poNumber + ".*)";
            MatchCollection orders = Regex.Matches(fileData, _linePattern);
            foreach (string order in orders.Cast<Match>().Select(m => m.Value))
            {
                var orderline = order.Split(',');
                yield return new PurchaseOrderLine { LineNumber = orderline[2], ProductDescription = orderline[3], OrderQty = orderline[4] };
            }
        }
    }
}
