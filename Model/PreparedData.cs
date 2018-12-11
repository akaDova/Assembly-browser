using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PreparedData : IHierarchicalData
    {
        public string ItemName
        {
            get;
            internal set;
        }

        public ObservableCollection<IHierarchicalData> Nodes
        {
            get;
            internal set;
        }

        public PreparedData()
        {

        }

        public PreparedData(IData data)
        {
            ItemName = data.ItemName;
            Nodes = new ObservableCollection<IHierarchicalData>();
        }

        
    }
}
