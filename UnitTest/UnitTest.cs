using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Model;

namespace UnitTest
{
    
    public class UnitTest
    {
        [Fact]
        public void TestDataType()
        {
            var dataType = new DataType(typeof(UTestClass));
            
            Assert.Equal(dataType.ItemName, typeof(UTestClass).Name);
            
        }

        [Fact]
        public void TestDataMethod()
        {
            var testObj = new UTestClass();
            MethodInfo method = testObj.GetType().GetMethod("DoNothing");
            var dataMethod = new DataMethod(method);
            Assert.Equal(dataMethod.Name, method.Name); 

        }

        [Fact]
        public void TestDataField()
        {
            var testObj = new UTestClass();
            FieldInfo field = testObj.GetType().GetField("number");
            var dataField = new DataField(field);
            Assert.Equal(dataField.Name, field.Name);
            Assert.Equal(dataField.OwnType, field.FieldType.Name);
            Assert.Equal(dataField.ItemName, $"{field.FieldType.Name} {field.Name}");

        }

        [Fact]
        public void TestDataNamespace()
        {
            var testType = new UTestClass().GetType();

            var dataType = new DataNamespace(testType.Namespace, new List<Type> { testType });
            Assert.Equal(dataType.ItemName, testType.Namespace);

        }

        [Fact]
        public void TestDataProperty()
        {
            var testObj = new UTestClass();
            PropertyInfo prop = testObj.GetType().GetProperty("NumberPlusFive");
            var dataField = new DataProperty(prop);
            Assert.Equal(dataField.Name, prop.Name);
            Assert.Equal(dataField.OwnType, prop.PropertyType.Name);
            Assert.Equal(dataField.ItemName, $"property {prop.PropertyType.Name} {prop.Name}");

        }

    }
}
