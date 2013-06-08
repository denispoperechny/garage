using DataSource.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using VisualControls.ModalContentHandler;
using WeddingManager.MVVM;
using WeddingManager.ViewModels.MainTabs;

namespace WeddingManager.ViewModels
{
    public class MainLayoutViewModel : WeddingManagerViewModelBase
    {
        private readonly MainTabViewModel[] _tabs;

        public MainLayoutViewModel()
        {
            _tabs = new MainTabViewModel[] { new VisitorsViewModel(), new ToastsViewModel(), new CounterpartiesViewModel() };

            //TODO: Here is test data. To be removed
            var dd = DataContext.CounterpartyRoles.ToList();
            try
            {
                var modal = new ModalDialog(null, ModalButton.Ok|ModalButton.Cancel);

                modal.ShowDialog();
                
            }
            catch
            {
                throw;
            }
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
