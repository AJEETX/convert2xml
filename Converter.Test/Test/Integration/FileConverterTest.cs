﻿using System;
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
    public class FileConverterIntegrationTest
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
            var converter = new FileConverter(reader, writer);

            //when
            var result = converter.Convert(TestData.GetFileNameSample());

            //then
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(string));
            Assert.IsFalse(result == "File Not found");
            Assert.IsTrue(result == TestData.GetSavedFileName());
        }
    }
}