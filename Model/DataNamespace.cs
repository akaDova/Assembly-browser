using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DataNamespace : INamed
    {
       

        public string Name
        {
            get;
        }

        public List<DataType> types;

        public DataNamespace(string name)
        {
            Name = name;
        }

        
    }
}
