using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingManager.MVVM;

namespace WeddingManager.ViewModels.MainTabs
{
    public class VisitorsViewModel : MainTabViewModel
    {
        public VisitorsViewModel()
        {
            
        }

        public override string Title
        {
            get { return "Visitors"; }
        }
    }
}
