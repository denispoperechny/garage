﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingManager.MVVM;
using WeddingManager.ViewModels.MainTabs;

namespace WeddingManager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        MainTabViewModel[] _tabs;
        
        public MainWindowViewModel()
        {
            _tabs = new MainTabViewModel[] { new VisitorsViewModel(), new ToastsViewModel(), new CounterpartiesViewModel() };
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
