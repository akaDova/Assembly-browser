using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataType : DataMember, INamed, IData
    {
        public string Name
        {
            get;
        }

        private IEnumerable<IData> fields;
        private IEnumerable<IData> properties;
        private IEnumerable<IData> methods;

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
            Name = GetTypeName(type);
            TypeInfo typeInfo = type.GetTypeInfo();
            //FieldInfo[] fieldsInfo = typeInfo.DeclaredFields;
           

            fields = (
                from field in typeInfo.DeclaredFields
                select new DataField(field) into dataField
                select dataField
            );


            properties = (
                from property in typeInfo.DeclaredProperties
                select new DataProperty(property) into dataProperty
                select dataProperty
            );

            methods = (
                 from method in typeInfo.DeclaredMethods
                 select new DataMethod(method) into dataMethod
                 select dataMethod
             );

            Nodes = fields.Concat(properties)
                          .Concat(methods);
        }
    }
}
