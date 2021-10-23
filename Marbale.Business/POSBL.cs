using Marbale.BusinessObject;
using Marbale.BusinessObject.DisplayGroup;
using Marbale.BusinessObject.SiteSetup;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business
{
   public class POSBL
    {
        private ProductData marbaleData;
        private CommonData commonData;

        private SiteSetupData siteSetupdata;

        public POSBL()
        {
            marbaleData = new ProductData();
            siteSetupdata = new SiteSetupData();
        }

        public DataTable GetDefaultPaymentDropdown()
        {
            DataTable dataTable = marbaleData.GetDefalutCashMode();
            return dataTable;
        }

        public int UpdatePOSUserCredential(string Password)
        {
            int updatestatus = marbaleData.UpdatePOSUserCredential(Password);
            return updatestatus;
        }
        public List<Product> GetProductsByScreenGroup(int screenGroupId)
        {
            try
            {
                DataTable dataTable = marbaleData.GetProductsByScreenGroup(screenGroupId);
                List<Product> products = new List<Product>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    var product = new Product();
                    product.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    product.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    product.Category = dr.IsNull("Category") ? "" : dr["Category"].ToString();
                    product.DisplayGroup = dr.IsNull("DisplayGroup") ? "" : dr["DisplayGroup"].ToString();
                    product.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    product.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime().ToString("MMMM dd yyyy HH:mm:ss") : Convert.ToDateTime(dr["LastUpdatedDate"]).ToString("MMMM dd yyyy HH:mm:ss");
                    product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    product.AutoGenerateCardNumber = dr.IsNull("AutoGenerateCardNumber") ? false : bool.Parse(dr["AutoGenerateCardNumber"].ToString());
                    product.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                    product.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    product.EffectivePrice = dr.IsNull("EffectivePrice") ? 0 : Convert.ToInt32(dr["EffectivePrice"]);
                    product.Price = dr.IsNull("Price") ? 0 : Convert.ToInt32(dr["Price"]);
                    product.FaceValue = dr.IsNull("FaceValue") ? 0 : Convert.ToInt32(dr["FaceValue"]);
                    product.FinalPrice = dr.IsNull("FinalPrice") ? 0 : Convert.ToInt32(dr["FinalPrice"]);
                    product.TaxPercentage = dr.IsNull("TaxPercentage") ? 0 : Convert.ToInt32(dr["TaxPercentage"]);
                    product.OnlyVIP = dr.IsNull("OnlyVIP") ? false : bool.Parse(dr["OnlyVIP"].ToString());
                    product.DisplayInPOS = dr.IsNull("DisplayInPOS") ? false : bool.Parse(dr["DisplayInPOS"].ToString());
                    product.TaxInclusive = dr.IsNull("TaxInclusive") ? false : bool.Parse(dr["TaxInclusive"].ToString());
                    products.Add(product);
                }
                return products;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ChangeUserPassword(string userId, string currentPassword, string newPassword)
        {
            commonData.ChangePassword(userId, currentPassword, newPassword);
        }


        public List<DisplayGroup> GetDisplayGroup(int displayGroupId)
        {
            List<DisplayGroup> displayGroupList = new List<DisplayGroup>();

            try
            {
                DataTable dataTable = marbaleData.GetDisplayGroup(displayGroupId);
                DisplayGroup displayGrp;
                foreach (DataRow dr in dataTable.Rows)
                {
                    displayGrp = new DisplayGroup();
                    displayGrp.displayGroupId = dr.IsNull("DisplayGroupId") ? 0 : int.Parse(dr["DisplayGroupId"].ToString());
                    displayGrp.displayGroupname = dr.IsNull("DisplayGroup") ? string.Empty : dr["DisplayGroup"].ToString();
                    displayGrp.sortOrder = dr.IsNull("SortOrder") ? 0 : int.Parse(dr["SortOrder"].ToString());
                    displayGrp.createdBy = dr.IsNull("CreatedBy") ? string.Empty : dr["CreatedBy"].ToString();
                    displayGrp.lastUpdatedBy = dr.IsNull("LastUpdatedBy") ? string.Empty : dr["LastUpdatedBy"].ToString();
                    displayGrp.createdDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                    displayGrp.lastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    displayGroupList.Add(displayGrp);
                }
            }
            catch(Exception e)
            {

            }

            return displayGroupList;
        }

        public  Product GetProductsById(int pid)
        {
            try
            {
                DataTable dataTable = marbaleData.GetProductById(pid);
                 Product product = new  Product();
                foreach (DataRow dr in dataTable.Rows)
                {
                    product = new Product();
                    product.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    product.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    product.Category = dr.IsNull("Category") ? "" : dr["Category"].ToString();
                    //product.DisplayGroup = dr.IsNull("DisplayGroup") ? "" : dr["DisplayGroup"].ToString();
                    product.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    product.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime().ToString("MMMM dd yyyy HH:mm:ss") : Convert.ToDateTime(dr["LastUpdatedDate"]).ToString("MMMM dd yyyy HH:mm:ss");
                    product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    product.AutoGenerateCardNumber = dr.IsNull("AutoGenerateCardNumber") ? false : bool.Parse(dr["AutoGenerateCardNumber"].ToString());
                    product.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                    product.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    product.EffectivePrice = dr.IsNull("EffectivePrice") ? 0 : Convert.ToInt32(dr["EffectivePrice"]);
                    product.Price = dr.IsNull("Price") ? 0 : Convert.ToInt32(dr["Price"]);
                    product.FaceValue = dr.IsNull("FaceValue") ? 0 : Convert.ToInt32(dr["FaceValue"]);
                    product.FinalPrice = dr.IsNull("FinalPrice") ? 0 : Convert.ToInt32(dr["FinalPrice"]);
                    product.TaxPercentage = dr.IsNull("TaxPercentage") ? 0 : Convert.ToInt32(dr["TaxPercentage"]);
                    product.OnlyVIP = dr.IsNull("OnlyVIP") ? false : bool.Parse(dr["OnlyVIP"].ToString());
                    product.TaxInclusive = dr.IsNull("TaxInclusive") ? false : bool.Parse(dr["TaxInclusive"].ToString());
                  
                }
                return product;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
