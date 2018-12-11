using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataType : INamed
    {
        public string Name
        {
            get;
        }

        public readonly List<DataField> fields;
        public readonly List<DataProperty> properties;
        public readonly List<DataMethod> methods;
        
        public DataType()
        {

        }

        public DataType(Type type)
        {
            Name = type.Name;

            FieldInfo[] fieldsInfo = type.GetFields();

            fields = (
                from field in type.GetFields()
                select new DataField(field) into dataField
                select dataField
            ).ToList();

            properties = (
                from property in type.GetProperties()
                select new DataProperty(property) into dataProperty
                select dataProperty
            ).ToList();

            methods = (
                from method in type.GetMethods()
                select new DataMethod(method) into dataMethod
                select dataMethod
            ).ToList();
        }
    }
}
