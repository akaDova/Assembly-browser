using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataField : ITyped, IData
    {
        public string Name
        {
            get;
        }
        public string OwnType
        {
            get;
        }

        public string ItemName
        {
            get => $"{OwnType} {Name}";
        }

        public IEnumerable<IData> Nodes => null;

        public DataField()
        {

        }

        private string GetTypeName(Type type)
        {
            string typeName = type.Name;
            if (type.IsGenericType)
            {
                List<string> args = (from arg in type.GetGenericArguments()
                                     select arg.Name).ToList();
                typeName = $"{typeName}<{string.Join(",", args)}>";

            }
            return typeName;
        }

        public DataField(FieldInfo field)
        {
            Name = field.Name;
            OwnType = GetTypeName(field.FieldType);
            
        }
    }
}
