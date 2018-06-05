using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Converter.Domain;
using Moq;
using Converter.Test.Data;

namespace Converter.Test.Integration
{
    [TestClass]
    public class BusinessManagerIntegrationTest
    {
        [TestMethod]
        public void Integration_test_convert_specified_file_found_2_xml_successful()
        {
            //given
            var lineGenerator = new PurchaseOrderLineGenerator();
            var orderGenerator = new PurchaseOrderGenerator(lineGenerator);
            var formatter = new FormatData(orderGenerator);
            var reader = new FileReader();
            var writer = new FileWriter(formatter);
            var convert = new FileConverter(reader, writer);
            var mgr = new FileManager(convert);

            //when
            var result = mgr.ConvertDocument(TestData.GetFileNameSample());

            //then
            //then
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.IsFalse(result == "File Not found");
            Assert.IsTrue(result == TestData.GetSavedFileName());
        }
    }
}
