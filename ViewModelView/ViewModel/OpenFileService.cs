using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace ViewModelView.ViewModel
{
    class OpenFileService : IFileDialogService
    {
        public string FilePath {
            get;
            set;
        }

        public bool OpenFile()
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == true)
            {
                FilePath = openfileDialog.FileName;
                return true;
            }
            return false;
        }
    }
}
