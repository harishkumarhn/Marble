using Marbale.BusinessObject;
using Marbale.BusinessObject.Tax;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.DataAccess.Data;
using Marble.Business;
using Marbale.BusinessObject.Inventory;

namespace Marble.Business.InventoryBL
{
    public class VendorBL
    {
        private VendorData VendorData;

        public VendorBL()
        {
            VendorData = new VendorData();
        }


        public List<Vendor> GetVendor()
        {
            DataTable dt = VendorData.GetVendorData();
            List<Vendor> lstVendor = new List<Vendor>();
            Vendor Vendor;

            foreach (DataRow dr in dt.Rows)
            {
                Vendor = new Vendor();
                Vendor.VendorId = dr.IsNull("VendorId") ? 0 : int.Parse(dr["VendorId"].ToString());
                Vendor.VendorName = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                Vendor.AddressLine1 = dr.IsNull("AddressLine1") ? "" : dr["AddressLine1"].ToString();
                Vendor.AddressLine2 = dr.IsNull("AddressLine2") ? "" : dr["AddressLine2"].ToString();
                Vendor.Remarks = dr.IsNull("Remarks") ? "" : dr["Remarks"].ToString();
                Vendor.Code = dr.IsNull("Code") ? "" : dr["Code"].ToString();
                Vendor.City = dr.IsNull("City") ? "" : dr["City"].ToString();
                Vendor.State = dr.IsNull("State") ? "" : dr["State"].ToString();
                Vendor.Country = dr.IsNull("Country") ? "" : dr["Country"].ToString();
                Vendor.AddressRemarks = dr.IsNull("AddressRemarks") ? "" : dr["AddressRemarks"].ToString();
                Vendor.ContactName = dr.IsNull("ContactName") ? "" : dr["ContactName"].ToString();
                Vendor.Phone = dr.IsNull("Phone") ? "" : dr["Phone"].ToString();
                Vendor.Email = dr.IsNull("Email") ? "" : dr["Email"].ToString();
                Vendor.Website = dr.IsNull("Website") ? "" : dr["Website"].ToString();
                Vendor.IsActive = dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString());
                Vendor.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                Vendor.CreatedDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                Vendor.LastUpdatedBy = dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString();
                Vendor.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                lstVendor.Add(Vendor);
            }

            return lstVendor;
        }
    }
}
