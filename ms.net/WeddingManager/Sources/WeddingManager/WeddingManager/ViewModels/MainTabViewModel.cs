using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingManager.MVVM;

namespace WeddingManager.ViewModels
{
    public abstract class MainTabViewModel : ViewModelBase
    {
        public abstract string Title { get; }
    }
}
