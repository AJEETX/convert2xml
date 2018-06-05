using Converter.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter.Domain
{
    public interface IPurchaseOrderLineGenerator
    {
        IEnumerable<PurchaseOrderLine> GetOrderLine(string strFileData, string strPOnumber);
    }
    class PurchaseOrderLineGenerator : IPurchaseOrderLineGenerator
    {
        public IEnumerable<PurchaseOrderLine> GetOrderLine(string strFileData, string strPOnumber)
        {
            if (string.IsNullOrEmpty(strFileData) || string.IsNullOrEmpty(strPOnumber)) return null;
            IEnumerable<PurchaseOrderLine> purchaseOrderLines = null;
            try
            {
                purchaseOrderLines = CreateOrderLine(strFileData, strPOnumber);
            }
            catch (System.Exception)
            {
                //catch // throw // log //yell ??// issue in lineOrder
            }
            return purchaseOrderLines;
        }

        IEnumerable<PurchaseOrderLine> CreateOrderLine(string strFileData, string strPOnumber)
        {
            string _linePattern = @"(?<el>D\," + strPOnumber + ".*)";
            MatchCollection orders = Regex.Matches(strFileData, _linePattern);
            foreach (string order in orders.Cast<Match>().Select(m => m.Value))
            {
                PurchaseOrderLine purchaseOrderLine = null;
                try
                {
                    var orderline = order.Split(',');
                    purchaseOrderLine = new PurchaseOrderLine { LineNumber = orderline[2], ProductDescription = orderline[3], OrderQty = orderline[4] };
                }
                catch (System.Exception)
                {
                    //catch // throw // log // issue in purchase order line;
                }
                yield return purchaseOrderLine;
            }
        }
    }
}
