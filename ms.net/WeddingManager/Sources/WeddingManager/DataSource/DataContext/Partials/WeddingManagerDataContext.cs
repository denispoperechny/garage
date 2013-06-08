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
        private static readonly object _lockObject = new object();

        public static WeddingManagerDataContext SafeInstance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new WeddingManagerDataContext();
                        AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                    }
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
