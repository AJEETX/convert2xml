using Converter.Model;
using System;
using System.Collections.Generic;

namespace Converter.Domain
{
    public interface IPurchaseOrderGenerator
    {
        PurchaseOrder GenerateOrder(string strFileData, string strPurchaseOrder);
    }
    class PurchaseOrderGenerator : IPurchaseOrderGenerator
    {
        const string SFC01 = "SHANGHAI FURNITURE COMPANY";
        const string YIP01 = "YANTIAN INDUSTRIAL PRODUCTS";
        Dictionary<string, Func<OrderCodeDestination>> supplierData = new Dictionary<string, Func<OrderCodeDestination>>();
        private readonly IPurchaseOrderLineGenerator _purchaseOrderLineGenerator;

        public PurchaseOrderGenerator(IPurchaseOrderLineGenerator purchaseOrderLineGenerator)
        {
            _purchaseOrderLineGenerator = purchaseOrderLineGenerator;
            supplierData.Add(SFC01, () => { return new OrderCodeDestination { SupplierCode = "SFC01", Destination = "AUMEL" }; });
            supplierData.Add(YIP01, ()=> { return new OrderCodeDestination { SupplierCode = "YIP-01", Destination = "AUSYD" }; });
        }
        public PurchaseOrder GenerateOrder(string strFileData, string strPurchaseOrder)
        {
            if (string.IsNullOrEmpty(strFileData) || string.IsNullOrEmpty(strPurchaseOrder)) return null;
            PurchaseOrder _purchaseOrder = null;
            try
            {
                _purchaseOrder = CreateOrder(strFileData, strPurchaseOrder);
            }
            catch (Exception)
            {
                //catch // throw //log // yell ??// issue within purchase order
            }
            return _purchaseOrder;
        }
        PurchaseOrder CreateOrder(string strFileData, string strPurchaseOrder)
        {
                var orderData = strPurchaseOrder.Split(',');
                return new PurchaseOrder
                {
                    CustomerPo = orderData[1],
                    Supplier = supplierData[orderData[2]].Invoke().SupplierCode,
                    Origin = orderData[3],
                    Destination = string.IsNullOrEmpty(orderData[4]) ? supplierData[orderData[2]].Invoke().Destination : orderData[4],
                    CargoReady = DateTime.Parse(orderData[5]).ToString("yyyy-MM-dd"),
                    PurchaseOrderLines = _purchaseOrderLineGenerator.GetOrderLine(strFileData, orderData[1])
                };
        }
    }
}
