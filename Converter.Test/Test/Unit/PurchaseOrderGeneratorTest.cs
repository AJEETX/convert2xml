using System;
using Converter.Domain;
using Converter.Model;
using Converter.Test.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Converter.Test.Unit
{
    [TestClass]
    public class PurchaseOrderGeneratorTest
    {
        [TestMethod]
        public void Unit_test_PurchaseOrderGenerator_with_specified_stringData_generates_purchase_order_without_orderline_successful()
        {
            //given
            string strOrder = TestData.GetOrderString();
            var moqLineGenerator = new Mock<IPurchaseOrderLineGenerator>();
            moqLineGenerator.Setup(m => m.GetOrderLine(It.IsAny<string>(), It.IsAny<string>())).Returns(TestData.GetPurchaseLineOrder);
            var sut = new PurchaseOrderGenerator(moqLineGenerator.Object);

            //when
            var result = sut.GenerateOrder(TestData.GetOrderString(),TestData.GetFileDataSample());

            //then
            Assert.IsInstanceOfType(result, typeof(PurchaseOrder));
            Assert.IsTrue(result.PurchaseOrderLines != null);
            Assert.IsTrue(result.CustomerPo == strOrder.Split(',')[1]);
            Assert.IsTrue(result.Supplier != strOrder.Split(',')[2]);
            Assert.IsTrue(result.Origin == strOrder.Split(',')[3]);
            Assert.IsTrue(result.Destination == strOrder.Split(',')[4]);
            Assert.IsTrue(result.CargoReady != strOrder.Split(',')[5]);
        }
        [TestMethod]
        public void Unit_test_PurchaseOrderGenerator_without_destination_stringData_generates_purchase_order_with_default_destination_successful()
        {
            //given
            string strOrder = TestData.GetOrderStringWithoutDestination();
            var moqLineGenerator = new Mock<IPurchaseOrderLineGenerator>();
            moqLineGenerator.Setup(m => m.GetOrderLine(It.IsAny<string>(), It.IsAny<string>())).Returns(TestData.GetPurchaseLineOrder);
            var sut = new PurchaseOrderGenerator(moqLineGenerator.Object);

            //when
            var result = sut.GenerateOrder(strOrder, TestData.GetFileDataSample());

            //then
            Assert.IsInstanceOfType(result, typeof(PurchaseOrder));
            Assert.IsTrue(result.PurchaseOrderLines != null);
            Assert.IsTrue(result.CustomerPo == strOrder.Split(',')[1]);
            Assert.IsTrue(result.Supplier != strOrder.Split(',')[2]);
            Assert.IsTrue(result.Origin == strOrder.Split(',')[3]);
            Assert.IsFalse(result.Destination == strOrder.Split(',')[4]);
        }
    }
}
