using DataSource.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingManager.MVVM;
using WeddingManager.ViewModels.MainTabs;

namespace WeddingManager.ViewModels
{
    public class MainLayoutViewModel : WeddingManagerViewModelBase
    {
        MainTabViewModel[] _tabs;

        public MainLayoutViewModel()
        {
            //TODO: Here is test data. To be removed
            
            _tabs = new MainTabViewModel[] { new VisitorsViewModel(), new ToastsViewModel(), new CounterpartiesViewModel() };

            var dd = DataContext.CounterpartyRoles.ToList();
        }


        public string Test
        {
            get { return "Tested"; }
        }

        public MainTabViewModel[] Tabs
        {
            get
            {
                return _tabs;
            }
        }

    }
}
