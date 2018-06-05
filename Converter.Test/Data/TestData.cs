using Converter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Test.Data
{
    public class TestData
    {
        public static string GetFileNameSample()
        {
            return @"data.csv";
        }
        public static string GetSavedFileName()
        {
            return @"PurchaseOrder.xml";
        }
        public static string GetOrderString()
        {
            return GetFileDataSample().Split(new[] { Environment.NewLine },
    StringSplitOptions.None).FirstOrDefault();
        }
        public static string GetOrderStringWithoutDestination()
        {
            return GetFileDataSample().Split(new[] { Environment.NewLine },
    StringSplitOptions.None)[6];
        }
        public static string GetFileDataSample()
        {
            return @"H,PO2008-01,SHANGHAI FURNITURE COMPANY,CNSHA,AUMEL,1/05/2014
D,PO2008-01,1,RED LOUNGES,100,
D,PO2008-01,2,GREY LOUNGES,50,
H,PO2008-02,YANTIAN INDUSTRIAL PRODUCTS,CNYTN,AUSYD,16/05/2014
D,PO2008-02,1,BAR STOOLS,40,
D,PO2008-02,2,METAL TABLES,75,
H,PO2008-03,SHANGHAI FURNITURE COMPANY,CNSHA,,1/07/2014
D,PO2008-03,1,RED CHAIRS,33,
H,PO2008-04,SHANGHAI FURNITURE COMPANY,CNSHA,AUMEL,30/06/2014
D,PO2008-04,1,GREEN BEDS,33,
D,PO2008-04,2,GREEN TABLES,44,
D,PO2008-04,3,GREEN LAMPS,55,
             ";
        }
        public static List<PurchaseOrderLine> GetPurchaseLineOrder()
        {
            return new List<PurchaseOrderLine> {
                new PurchaseOrderLine {
                 LineNumber="1",
                    ProductDescription="RED LOUNGES",
                    OrderQty="100"
            },
                new PurchaseOrderLine {
                 LineNumber="2",
                    ProductDescription="GREY LOUNGES",
                    OrderQty="50"
            }
            };
        }
        public static PurchaseOrder GetPurchaseOrder()
        {
            return new PurchaseOrder { };
        }
        public static List<PurchaseOrder> GetPurchaseOrderList()
        {
            return new List<PurchaseOrder>
            {
                 GetPurchaseOrder()
            };
        }
    }
}
