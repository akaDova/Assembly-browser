using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataType : INamed, IData
    {
        public string Name
        {
            get;
        }

        public  List<DataField> fields;
        public  List<DataProperty> properties;
        public  List<DataMethod> methods;

        public string ItemName
        {
            get => Name;
        }

        public IEnumerable<IData> Nodes
        {
            get;
        }

        public DataType()
        {

        }

        public DataType(Type type)
        {
            Name = type.Name;
            TypeInfo typeInfo = type.GetTypeInfo();
            //FieldInfo[] fieldsInfo = typeInfo.DeclaredFields;

            fields = (
                from field in typeInfo.DeclaredFields
                select new DataField(field) into dataField
                select dataField
            ).ToList();


            properties = (
                from property in typeInfo.DeclaredProperties
                select new DataProperty(property) into dataProperty
                select dataProperty
            ).ToList();

            methods = (
                 from method in typeInfo.DeclaredMethods
                 select new DataMethod(method) into dataMethod
                 select dataMethod
             ).ToList();

            Nodes = ((IEnumerable<IData>)fields).Concat(properties)
                          .Concat(methods);
                
                
        }
    }
}
