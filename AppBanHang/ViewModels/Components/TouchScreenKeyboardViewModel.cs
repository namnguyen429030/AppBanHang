using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Components
{
    public abstract class TouchScreenKeyboardViewModel : ReactiveObject
    {
        public INotifyPropertyChanged Chars { get; }
        protected TouchScreenKeyboardViewModel()
        {
            Chars = new ObservableCollection<char>();   
        }
    }
}
