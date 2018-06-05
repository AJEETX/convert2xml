using System;
using System.Collections.Generic;
using Converter.Domain;
using Converter.Model;
using Converter.Test.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Converter.Test.Unit
{
    [TestClass]
    public class FormatDataTest
    {
        [TestMethod]
        public void Unit_test_FormatData_with_correct_specified_string_converts_2_purchaseOrder_list()
        {
            //given
            string fileData = TestData.GetFileDataSample();
            var moqOrderGenerator = new Mock<IPurchaseOrderGenerator>();
            moqOrderGenerator.Setup(m => m.GenerateOrder(It.IsAny<string>(), It.IsAny<string>())).Returns(TestData.GetPurchaseOrder());
            var sut = new FormatData(moqOrderGenerator.Object);

            //when
            var result = sut.ConvertString2Object(fileData);

            //then
            Assert.IsInstanceOfType(result, typeof(IEnumerable<PurchaseOrder>));
        }
    }
}
