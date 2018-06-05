using System.Collections.Generic;

namespace Converter.Model
{
    public class PurchaseOrder
    {
        public string CustomerPo { get; set; }
        public string Supplier { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string CargoReady { get; set; }
        public IEnumerable<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }

    public class PurchaseOrderLine
    {
        public string LineNumber { get; set; }
        public string ProductDescription { get; set; }
        public string OrderQty { get; set; }
    }
    public class OrderCodeDestination
    {
        public string SupplierCode { get; set; }
        public string Destination { get; set; }
    }
}
