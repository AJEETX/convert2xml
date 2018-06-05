using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
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
            var moqFileReader = new Mock<IFileReader>();
            var moqFileWriter = new Mock<IFileWriter>();

            moqFileReader.Setup(m => m.ReadFile(It.Is<string>(n=> n==TestData.GetFileNameSample()))).Returns(TestData.GetFileDataSample());
            moqFileWriter.Setup(m => m.Write(It.Is<string>(d => d == TestData.GetFileDataSample()))).Returns(TestData.GetSavedFileName());
            var sut = new FileConverter(moqFileReader.Object, moqFileWriter.Object);

            //when
            var result = sut.Convert(TestData.GetFileNameSample());
            //then
            Assert.IsTrue(result == TestData.GetSavedFileName());
        }
    }
}
