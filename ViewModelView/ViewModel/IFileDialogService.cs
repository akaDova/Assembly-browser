using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelView.ViewModel
{
    interface IFileDialogService
    {
        string FilePath
        {
            get;
            set;
        }

        bool OpenFile();
    }
}
