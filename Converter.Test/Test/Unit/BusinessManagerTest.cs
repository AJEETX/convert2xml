using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Converter.Domain;
using Moq;
using Converter.Test.Data;

namespace Converter.test
{
    [TestClass]
    public partial class BusinessManagerTest
    {
        string filepath = @"data.csv";
        [TestMethod()]
        public void Unit_test_business_manager_when_provided_with_specified_file_format_converts_2_xml_successfully()
        {
            //given
            var moqConverter = new Mock<IFileConverter>();
            moqConverter.Setup(m => m.Convert(It.IsAny<string>())).Returns(TestData.GetSavedFileName());
            var sut = new FileManager(moqConverter.Object);

            //when
            var result=sut.ConvertDocument(filepath);

            //then
            moqConverter.Verify(v => v.Convert(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(result, TestData.GetSavedFileName());
        }
    }
}
