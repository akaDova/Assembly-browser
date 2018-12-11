using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var model = new AssemblyData();
            var dataType = new DataType(typeof(UTestClass));
            //Assert.AreEqual(dataType.fields.GetType(), typeof(List<DataField>));
        }
    }
}
