using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public class ConfigLoad
    {

        List<AppSetting> ListCardAppSettings = new List<AppSetting>();
        SiteSetupBL siteSetupBussiness = new SiteSetupBL();
       

        //siteSetupBussiness.GetAppSettings("POS");

        public ConfigLoad()
        {
            ListCardAppSettings = siteSetupBussiness.GetAppSettings("CARD");
        }

        public void LoadProductDefaultValues(Product product)
        {
            AppSetting card_face_Value = ListCardAppSettings.Find(x => x.Name == "CARD_FACE_VALUE");
            if (card_face_Value != null && !string.IsNullOrWhiteSpace( card_face_Value.Value) && product.Id<=0)
            {
                product.FaceValue = card_face_Value.Value.ToINT();
            }
        }

    }
}
