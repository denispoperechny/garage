using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingManager.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        protected void OnPropertyChanged(string propertyName)
        {
            //TODO: Make thread-safe
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
