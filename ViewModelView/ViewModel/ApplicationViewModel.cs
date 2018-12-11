using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModelView.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AssemblyData assemblyData = new AssemblyData();

        IHierarchicalData data;

        string assemblyPath;

        public ApplicationViewModel()
        {

        }

    }
}
