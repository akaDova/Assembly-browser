using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDataType()
        {
            var dataType = new DataType(typeof(UTestClass));
            Assert.AreEqual(dataType.ItemName, typeof(UTestClass).Name);
            
        }

        [TestMethod]
        public void TestDataMethod()
        {
            var testObj = new UTestClass();
            MethodInfo method = testObj.GetType().GetMethod("DoNothing");
            var dataMethod = new DataMethod(method);
            Assert.AreEqual(dataMethod.Name, method.Name); 

        }

        [TestMethod]
        public void TestDataField()
        {
            var testObj = new UTestClass();
            FieldInfo field = testObj.GetType().GetField("number");
            var dataField = new DataField(field);
            Assert.AreEqual(dataField.Name, field.Name);
            Assert.AreEqual(dataField.OwnType, field.FieldType.Name);
            Assert.AreEqual(dataField.ItemName, $"{field.FieldType.Name} {field.Name}");

        }

        [TestMethod]
        public void TestDataNamespace()
        {
            var testType = new UTestClass().GetType();

            var dataType = new DataNamespace(testType.Namespace, new List<Type> { testType });
            Assert.AreEqual(dataType.ItemName, testType.Namespace);

        }

        [TestMethod]
        public void TestDataProperty()
        {
            var testObj = new UTestClass();
            PropertyInfo prop = testObj.GetType().GetProperty("NumberPlusFive");
            var dataField = new DataProperty(prop);
            Assert.AreEqual(dataField.Name, prop.Name);
            Assert.AreEqual(dataField.OwnType, prop.PropertyType.Name);
            Assert.AreEqual(dataField.ItemName, $"{prop.PropertyType.Name} {prop.Name}");

        }

    }
}
