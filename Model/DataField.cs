using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataField : DataMember, ITyped, IData
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

        public DataField(FieldInfo field)
        {
            Name = field.Name;
            OwnType = GetTypeName(field.FieldType);
            
        }
    }
}
