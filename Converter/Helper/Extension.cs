using Converter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Converter.Helper
{
    public static class Extension
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null) return string.Empty;
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        public static void Save2xml(this IEnumerable<PurchaseOrder> orders, string fileSavePath)
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                NewLineOnAttributes = true
            };
            using (XmlWriter writer = XmlWriter.Create(fileSavePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("PurchaseOrders");

                foreach (PurchaseOrder order in orders)
                {
                    writer.WriteStartElement("PurchaseOrder");
                    writer.WriteElementString("CustomerPo", order.CustomerPo);
                    writer.WriteElementString("Supplier", order.Supplier);
                    writer.WriteElementString("Origin", order.Origin);
                    writer.WriteElementString("Destination", order.Destination);
                    writer.WriteElementString("CargoReady", order.CargoReady);
                    writer.WriteStartElement("Lines");

                    foreach (var PurchaseOrderLine in order.PurchaseOrderLines)
                    {
                        writer.WriteStartElement("PurchaseOrderLine");
                        writer.WriteElementString("LineNumber", PurchaseOrderLine.LineNumber);
                        writer.WriteElementString("ProductDescription", PurchaseOrderLine.ProductDescription);
                        writer.WriteElementString("OrderQty", PurchaseOrderLine.OrderQty);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
