using Marbale;
using Marble.Business.ViewModels;
using Marble.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public class SiteConfiguration
    {
        private MarbaleData marbaleData;
        public SiteConfiguration()
        {
            marbaleData = new MarbaleData();
        }

        public POSVM GetPOSConfiguration()
        {
            return null;
        }
        public bool SavePOSConfiguration(POSVM posModel)
        {
            return true;
        }

    }
}
