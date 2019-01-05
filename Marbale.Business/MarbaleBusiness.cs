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
        #region settings
        public List<Settings> GetSettings()
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AppSetting> GetAppSettings(string screen)
        {
            try
            {
                var dataTable = marbaleData.GetAppSettings(screen);
                List<AppSetting> listSettings = new List<AppSetting>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    AppSetting setting = new AppSetting();
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();
                    setting.Value = dr.IsNull("Value") ? "" : dr["Value"].ToString();
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
                    marbaleData.UpdateSettings(setting.Id, setting.Name, setting.Caption, setting.Description, setting.DefaultValue, setting.Type,
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
                    marbaleData.SaveAppSettings(setting.Name, setting.Value, setting.ScreenGroup);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region products
        public ProductObject GetProduct(int id)
        {
            return null;
        }
        public int AddProduct(ProductObject product)
        {
            try
            {
                return marbaleData.AddProduct(product.Name, product.Type, product.POSCounter, product.Active, product.DisplayInPOS,
                    product.Category, product.DisplayGroup, product.AutoGenerateCardNumber, product.OnlyVIP, product.Price,
                    product.FaceValue, product.EffectivePrice, product.FinalPrice, product.TaxInclusive, product.TaxPercentage);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public int UpdateProduct(ProductObject product)
        {
            return 0;
        }
        #endregion

    }
}
