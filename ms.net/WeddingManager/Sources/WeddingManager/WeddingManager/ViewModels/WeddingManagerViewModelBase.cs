using DataSource.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingManager.MVVM;

namespace WeddingManager.ViewModels
{
    public abstract class WeddingManagerViewModelBase : ViewModelBase
    {
        private readonly WeddingManagerDataContext _dataContext = WeddingManagerDataContext.SafeInstance;

        protected WeddingManagerDataContext DataContext
        {
            get { return _dataContext; }
        }

    }
}
