using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DataContext
{
    public partial class WeddingManagerDataContext : DbContext
    {
        private static WeddingManagerDataContext _instance;

        public static WeddingManagerDataContext SafeInstance
        {
            get
            {
                //TODO: Make thread safe !!
                
                if (_instance == null)
                {
                    _instance = new WeddingManagerDataContext();
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                }

                return _instance;
            }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            _instance.Dispose();
        }
    }
}
