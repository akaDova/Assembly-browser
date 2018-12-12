using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class DataMember
    {
        protected string GetTypeName(Type type)
        {
            string typeName = type.Name;
            if (type.IsGenericType)
            {
                List<string> args = (from arg in type.GetGenericArguments()
                                     select GetTypeName(arg)).ToList();
                typeName = $"{typeName}<{string.Join(",", args)}>";

            }
            return typeName;
        }
    }
}
