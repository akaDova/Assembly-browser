using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DataProperty : INamed
    {
        public string Name
        {
            get;
        }
        public string ReturnType
        {
            get;
        }

        public DataProperty()
        {

        }

        public DataProperty(string name, string returnType)
        {
            Name = name;
            ReturnType = returnType;
        }

        public DataProperty(PropertyInfo property)
        {
            Name = property.Name;
            ReturnType = property.PropertyType.Name;

        }
    }
}
