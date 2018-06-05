using System;
using System.Collections.Generic;
using Converter.Domain;
using Converter.Model;
using Converter.Test.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converter.Test.Unit
{
    [TestClass]
    public class PurchaseOrderLineGeneratorTest
    {
        [TestMethod]
        public void Unit_test_PurchaseOrderLineGenerator_file_string_data_with_purchase_order_number_returns_purchase_order_Line_list_with_given_purchase_order_number()
        {
            //given
            string fileData = TestData.GetFileDataSample(),POnumber= "PO2008-01";
            var sut = new PurchaseOrderLineGenerator();

            //when
            var result = sut.GetOrderLine(fileData, POnumber);

            //then
            Assert.IsInstanceOfType(result, typeof(List<PurchaseOrderLine>));
        }
    }
}
