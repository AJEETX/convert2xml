using Converter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Converter.Domain
{
    public interface IFormatData
    {
        IEnumerable<PurchaseOrder> ConvertString2Object(string strFileData);
    }
    class FormatData : IFormatData
    {
        private const string _purchaseOrderPattern = @"(?<el>H\,.*)";
        private readonly IPurchaseOrderGenerator _orderGenerator;
        public FormatData(IPurchaseOrderGenerator orderGenerator)
        {
            _orderGenerator = orderGenerator;
        }
        public IEnumerable<PurchaseOrder> ConvertString2Object(string strFileData)
        {
            if (string.IsNullOrEmpty(strFileData)) return null;
            
                return FormatFileData2PurchaseOrders(strFileData);
        }

        IEnumerable<PurchaseOrder> FormatFileData2PurchaseOrders(string strFileData)
        {
            MatchCollection purchaseOrders = Regex.Matches(strFileData, _purchaseOrderPattern);

            foreach (string strPurchaseOrder in purchaseOrders.Cast<Match>().Select(match => match.Value))
            {
                PurchaseOrder purchaseOrder = null;
                try
                {
                    purchaseOrder = _orderGenerator.GenerateOrder(strFileData, strPurchaseOrder);
                }
                catch(Exception)
                {
                    //catch // throw //log // yell ??// issue in this purchase order
                }
                yield return purchaseOrder;
            }
        }
    }
}
