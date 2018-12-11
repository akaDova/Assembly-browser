using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataNamespace : INamed, IData
    {
       

        public string Name
        {
            get;
        }

        public string ItemName
        {
            get => Name;
        }

        public IEnumerable<IData> Nodes => types;
       
        public readonly List<DataType> types;

        public DataNamespace(string name, List<Type> types)
        {
            Name = name;

            this.types = (
                from type in types
                select new DataType(type) into dataType
                select dataType
            ).ToList();

        }

        

        
    }
}
