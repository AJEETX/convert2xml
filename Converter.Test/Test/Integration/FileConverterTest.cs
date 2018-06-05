using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converter.Domain;
using Converter.Test.Data;

namespace Converter.Test.Integration
{
    [TestClass]
    public class FileConverterIntegrationTest
    {
        IPurchaseOrderLineGenerator _lineGenerator;
        IPurchaseOrderGenerator _orderGenerator;
        IFormatData _formatter;
        [TestInitialize]
        public void Init()
        {
            _lineGenerator = new PurchaseOrderLineGenerator();
            _orderGenerator = new PurchaseOrderGenerator(_lineGenerator);
            _formatter = new FormatData(_orderGenerator);
        }
        [TestCleanup]
        public void Clean()
        {
            _lineGenerator = null;
            _orderGenerator = null;
            _formatter = null;
        }
        [TestMethod]
        public void Integration_test_convert_specified_file_found_2_xml_successful_returns_saved_file_name()
        {
            //given
            string fileName = TestData.GetFileNameSample();
            string savedFileName =TestData.GetSavedFileName();
            var converter = new FileConverter( _formatter);

            //when
            var result = converter.Convert(fileName);

            //then
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(string));
            Assert.IsFalse(result == "Err");
            Assert.IsTrue(result == savedFileName);
        }
        [TestMethod]
        public void Integration_test_convert_specified_file_notfound_2_xml_return_err()
        {
            //given
            string fileName = "";
             var converter = new FileConverter( _formatter);

            //when
            var result = converter.Convert(fileName);

            //then
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.IsTrue(result == "Err");
        }
    }
}
