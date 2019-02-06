using Marbale.BusinessObject;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business
{
   public class POSBusiness
    {
        private ProductData marbaleData;

        public POSBusiness()
        {
            marbaleData = new ProductData();
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
        public List<Product> GetProductsByScreenGroup(string screenGroup)
        {
            try
            {
                var dataTable = marbaleData.GetProductsByScreenGroup(screenGroup);
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
                    product.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
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
                    products.Add(product);
                }
                return products;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
