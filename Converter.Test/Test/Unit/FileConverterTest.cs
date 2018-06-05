using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converter.Domain;
using Moq;
using Converter.Test.Data;

namespace Converter.Test.Unit
{
    [TestClass]
    public class FileConverterTest
    {
        [TestMethod]
        public void Unit_test_file_converter_when_provided_with_specified_file_format_converts_2_xml_successfully()
        {
            //given
            var moqFormatter = new Mock<IFormatData>();
            string SavedFileName = TestData.GetSavedFileName();
            string FilePath = "./data.csv"; //place the input file into bin/debug folder
            string fileDataSample = TestData.GetFileDataSample();
            var lineOrder = TestData.GetPurchaseOrderList();

            moqFormatter.Setup(m => m.ConvertString2Object(It.Is<string>(d => d == fileDataSample))).Returns(lineOrder);
            var sut = new FileConverter( moqFormatter.Object);

            //when
            var result = sut.Convert(FilePath);
            //then
            Assert.IsTrue(result ==SavedFileName);
        }
    }
}
