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
        Mock<IPurchaseOrderLineGenerator> moqLineGenerator;
        string fileData = string.Empty;
        [TestInitialize]
        public void Init()
        {
            fileData = TestData.GetFileDataSample();
            moqLineGenerator = new Mock<IPurchaseOrderLineGenerator>();
            moqLineGenerator.Setup(m => m.GetOrderLine(It.IsAny<string>(), It.IsAny<string>())).Returns(TestData.GetPurchaseLineOrder);
        }
        [TestCleanup]
        public void Clean()
        {
            moqLineGenerator = null;
        }
        [TestMethod]
        public void Unit_test_PurchaseOrderGenerator_with_specified_stringData_generates_purchase_order_without_orderline_successful()
        {
            //given
            string strPurchaseOrder = TestData.GetOrderString();
            var sut = new PurchaseOrderGenerator(moqLineGenerator.Object);

            //when
            var result = sut.GenerateOrder(fileData, strPurchaseOrder);

            //then
            Assert.IsInstanceOfType(result, typeof(PurchaseOrder));
            Assert.IsTrue(result.PurchaseOrderLines != null);
            Assert.IsTrue(result.CustomerPo == strPurchaseOrder.Split(',')[1]);
            Assert.IsTrue(result.Supplier != strPurchaseOrder.Split(',')[2]);
            Assert.IsTrue(result.Origin == strPurchaseOrder.Split(',')[3]);
            Assert.IsTrue(result.Destination == strPurchaseOrder.Split(',')[4]);
            Assert.IsTrue(result.CargoReady != strPurchaseOrder.Split(',')[5]);
        }
        [TestMethod]
        public void Unit_test_PurchaseOrderGenerator_without_destination_stringData_generates_purchase_order_with_default_destination_successful()
        {
            //given
            string strPurchaseOrder = TestData.GetOrderStringWithoutDestination();
            var sut = new PurchaseOrderGenerator(moqLineGenerator.Object);

            //when
            var result = sut.GenerateOrder(fileData,strPurchaseOrder);

            //then
            Assert.IsInstanceOfType(result, typeof(PurchaseOrder));
            Assert.IsTrue(result.PurchaseOrderLines != null);
            Assert.IsTrue(result.CustomerPo == strPurchaseOrder.Split(',')[1]);
            Assert.IsTrue(result.Supplier != strPurchaseOrder.Split(',')[2]);
            Assert.IsTrue(result.Origin == strPurchaseOrder.Split(',')[3]);
            Assert.IsFalse(result.Destination == strPurchaseOrder.Split(',')[4]);
        }
    }
}
