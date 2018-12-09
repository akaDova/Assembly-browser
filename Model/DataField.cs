using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DataField : INamed
    {
        public string Name
        {
            get;
        }
        public string ReturnType
        {
            get;
        }

        public DataField()
        {

        }

        public DataField(string name, string returnType)
        {
            Name = name;
            ReturnType = returnType;
        }

        public DataField(FieldInfo field) : this(field.Name, field.FieldType.Name)
        {
            Name = field.Name;
            ReturnType = field.FieldType.Name;
        }
    }
}
