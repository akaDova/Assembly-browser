using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.Win32;
using System.Windows;

namespace ViewModelView.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AssemblyData assemblyData = new AssemblyData();

        OpenFileService openFileService = new OpenFileService();
        
        ObservableCollection<IHierarchicalData> data;

        public ObservableCollection<IHierarchicalData> Data
        {
            get => data;
            set
            {
                data = value;
                //OnPropertyChanged("Data");
            }
        }

        string assemblyPath;
        
        RelayCommand openCommand;

        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (openFileService.OpenFile() == true)
                          {

                              assemblyPath = openFileService.FilePath;
                              Data = new ObservableCollection<IHierarchicalData>();
                              Data.Add(assemblyData.GetData(assemblyPath));
                              OnPropertyChanged("Data");
                          }
                      }
                      catch (FileLoadException ex)
                      {
                          MessageBox.Show("Уважаемый, Loaded file is not an assembly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);                       
                      }
                      catch (Exception ex)
                      {
                          
                      }
                  }));
            }
        }



        public ApplicationViewModel()
        {

        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
