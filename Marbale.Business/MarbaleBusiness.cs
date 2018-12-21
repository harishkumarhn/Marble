using Marbale.Business.ViewModels;
using Marbale.DataAccess;
using Marble.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business
{
    public class MarbaleBusiness
    {
        private MarbaleData marbaleData;

        public MarbaleBusiness()
        {
            marbaleData = new MarbaleData();
        }

        public List<Settings> GetSettings()
        {
            var dataTable = marbaleData.GetSettings();
            List<Settings> listSettings = new List<Settings>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Settings setting = new Settings();
                setting.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                setting.DefaultValue = dr.IsNull("DefaultValue") ? "" : dr["DefaultValue"].ToString();
                setting.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                setting.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();
                setting.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                setting.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                setting.PosLevel = dr.IsNull("PosLevel") ? false : bool.Parse(dr["PosLevel"].ToString());
                setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();
                setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                setting.UserLevel = dr.IsNull("UserLevel") ? false : bool.Parse(dr["UserLevel"].ToString());

                listSettings.Add(setting);
            }
            return listSettings;
        }

        public List<AppSetting> GetAppSettings(string screen)
        {
            var dataTable = marbaleData.GetAppSettings(screen);
            List<AppSetting> listSettings = new List<AppSetting>();
            foreach (DataRow dr in dataTable.Rows)
            {
                AppSetting setting = new AppSetting();
                setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                setting.Value = dr.IsNull("Value") ? "" : dr["Value"].ToString();
                setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();

                listSettings.Add(setting);
            }
            return listSettings;
        }

        public bool SaveSettings(List<Settings> settings)
        {
            foreach(var setting in settings)
            {
                marbaleData.UpdateSettings(setting.Id, setting.Name, setting.Description, setting.DefaultValue, setting.Type,
                    setting.ScreenGroup, setting.LastUpdatedBy, setting.Active, setting.UserLevel, setting.PosLevel);
            }
            return true;
        }
        
        public bool SavePOSConfiguration(List<AppSetting> appSetting)
        {
             foreach(var setting in appSetting)
            {
                marbaleData.SaveAppSettings(setting.Name,setting.Value,setting.ScreenGroup);
            }
            return true;
        }

    }
}
