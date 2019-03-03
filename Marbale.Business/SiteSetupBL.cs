using Marbale.BusinessObject;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marble.Business
{
    public class SiteSetupBL
    {
        private SiteSetupData siteSetupData;

         public SiteSetupBL()
        {
            siteSetupData = new SiteSetupData();
        }
        #region settings
        public List<Settings> GetSettings()
        {
            try
            {
                var typeListDataTable = siteSetupData.GetDatatypes();
                var typeList = new List<IdValue>();
                typeList.Add(new IdValue() { Id = 0, Value = "Select" });
                foreach (DataRow dr in typeListDataTable.Rows)
                {
                    IdValue idValues = new IdValue();
                    idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    idValues.Value = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    typeList.Add(idValues);
                }

                var dataTable = siteSetupData.GetSettings();
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
                    setting.BasicDataTypes = typeList;
                    listSettings.Add(setting);
                }

                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<AppSetting> GetAppSettings(string screen)
        {
            try
            {
                var dataTable = siteSetupData.GetAppSettings(screen);
                List<AppSetting> listSettings = new List<AppSetting>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    AppSetting setting = new AppSetting();
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();//
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();//label
                    setting.Value = dr.IsNull("DefaultValue") ? "" : dr["DefaultValue"].ToString();// current values
                    setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();

                    listSettings.Add(setting);
                }
                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SaveSettings(List<Settings> settings)
        {
            try
            {
                foreach (var setting in settings)
                {
                    siteSetupData.UpdateSettings(setting.Id, setting.Name, setting.Caption, setting.Description, setting.DefaultValue, setting.Type,
                        setting.ScreenGroup, setting.LastUpdatedBy, setting.Active, setting.UserLevel, setting.PosLevel);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SavePOSConfiguration(List<AppSetting> appSetting)
        {
            try
            {
                foreach (var setting in appSetting)
                {
                    siteSetupData.SaveAppSettings(setting.Name, setting.Value, setting.ScreenGroup);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


    }
}
