using Marbale.BusinessObject.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data
{
    public class VendorData
    {
        private DBConnection conn;
        private static readonly Dictionary<Vendor.SearchByVendorParameters, string> DBSearchParameters = new Dictionary<Vendor.SearchByVendorParameters, string>
               {
                    {Vendor.SearchByVendorParameters.IS_ACTIVE, "IsActive"},
                    {Vendor.SearchByVendorParameters.VENDOR_CODE, "Code"},
                    {Vendor.SearchByVendorParameters.VENDOR_NAME, "Name"},

    };
        public VendorData()
        {
            conn = new DBConnection();
        }

        public DataTable GetVendorData()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetVendor");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateVendor(Vendor vendor, string userid)
        {
            try
            {
                if (vendor.VendorId <= 0)
                {
                    int id = InsertVendor(vendor, userid);
                    return id;
                }
                else
                {
                    int id = UpdateVendor(vendor, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertVendor(Vendor vendor, string userId)
        {
            string query = @"INSERT INTO dbo.Vendor
                                           (Name
                                           ,Code
                                           ,AddressLine1
                                           ,AddressLine2
                                           ,Remarks
                                           ,City
                                           ,State
                                           ,Country
                                           ,PostalCode
                                           ,AddressRemarks
                                           ,ContactName
                                           ,Phone
                                           ,Email
                                           ,IsActive
                                           ,Website
                                           ,CreatedBy
                                           ,CreatedDate
                                           )
                                     VALUES
                                           (@Name 
                                           ,@Code 
                                           ,@AddressLine1 
                                           ,@AddressLine2 
                                           ,@Remarks 
                                           ,@City 
                                           ,@State 
                                           ,@Country 
                                           ,@PostalCode 
                                           ,@AddressRemarks 
                                           ,@ContactName 
                                           ,@Phone 
                                           ,@Email 
                                           ,@IsActive 
                                           ,@Website 
                                           ,@CreatedBy 
                                           ,getdate() 
                                           
                                           )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(vendor.VendorName))
            {
                sqParameters.Add(new SqlParameter("@Name", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Name", vendor.VendorName));
            }

            if (string.IsNullOrEmpty(vendor.Code))
            {
                sqParameters.Add(new SqlParameter("@Code", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Code", vendor.Code));
            }
            if (string.IsNullOrEmpty(vendor.AddressLine1))
            {
                sqParameters.Add(new SqlParameter("@AddressLine1", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressLine1", vendor.AddressLine1));
            }
            if (string.IsNullOrEmpty(vendor.AddressLine2))
            {
                sqParameters.Add(new SqlParameter("@AddressLine2", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressLine2", vendor.AddressLine2));
            }
            if (string.IsNullOrEmpty(vendor.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", vendor.Remarks));
            }
            if (string.IsNullOrEmpty(vendor.City))
            {
                sqParameters.Add(new SqlParameter("@City", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@City", vendor.City));
            }
            if (string.IsNullOrEmpty(vendor.State))
            {
                sqParameters.Add(new SqlParameter("@State", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@State", vendor.State));
            }
            if (string.IsNullOrEmpty(vendor.Country))
            {
                sqParameters.Add(new SqlParameter("@Country", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Country", vendor.Country));
            }
            if (string.IsNullOrEmpty(vendor.PostalCode))
            {
                sqParameters.Add(new SqlParameter("@PostalCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PostalCode", vendor.PostalCode));
            }
            if (string.IsNullOrEmpty(vendor.AddressRemarks))
            {
                sqParameters.Add(new SqlParameter("@AddressRemarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressRemarks", vendor.AddressRemarks));
            }
            if (string.IsNullOrEmpty(vendor.ContactName))
            {
                sqParameters.Add(new SqlParameter("@ContactName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ContactName", vendor.ContactName));
            }
            if (string.IsNullOrEmpty(vendor.Phone))
            {
                sqParameters.Add(new SqlParameter("@Phone", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Phone", vendor.Phone));
            }
            if (string.IsNullOrEmpty(vendor.Email))
            {
                sqParameters.Add(new SqlParameter("@Email", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Email", vendor.Email));
            }
            if (string.IsNullOrEmpty(vendor.Website))
            {
                sqParameters.Add(new SqlParameter("@Website", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Website", vendor.Website));
            }

            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(vendor.IsActive)));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateVendor(Vendor vendor, string userId)
        {
            string query = @"UPDATE dbo.Vendor
                       SET Name = @Name 
                          ,Code = @Code 
                          ,AddressLine1 = @AddressLine1 
                          ,AddressLine2 = @AddressLine2 
                          ,Remarks = @Remarks 
                          ,City = @City  
                          ,State = @State  
                          ,Country = @Country  
                          ,PostalCode = @PostalCode  
                          ,AddressRemarks = @AddressRemarks  
                          ,ContactName = @ContactName  
                          ,Phone = @Phone 
                          ,Email = @Email  
                          ,IsActive = @IsActive  
                          ,Website = @Website  
                            
                          ,LastupdatedBy = @LastupdatedBy  
                          ,LastupdatedDate = getdate()  
                     WHERE VendorId=@VendorId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@VendorId", vendor.VendorId));
            if (string.IsNullOrEmpty(vendor.VendorName))
            {
                sqParameters.Add(new SqlParameter("@Name", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Name", vendor.VendorName));
            }

            if (string.IsNullOrEmpty(vendor.Code))
            {
                sqParameters.Add(new SqlParameter("@Code", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Code", vendor.Code));
            }
            if (string.IsNullOrEmpty(vendor.AddressLine1))
            {
                sqParameters.Add(new SqlParameter("@AddressLine1", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressLine1", vendor.AddressLine1));
            }
            if (string.IsNullOrEmpty(vendor.AddressLine2))
            {
                sqParameters.Add(new SqlParameter("@AddressLine2", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressLine2", vendor.AddressLine2));
            }
            if (string.IsNullOrEmpty(vendor.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", vendor.Remarks));
            }
            if (string.IsNullOrEmpty(vendor.City))
            {
                sqParameters.Add(new SqlParameter("@City", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@City", vendor.City));
            }
            if (string.IsNullOrEmpty(vendor.State))
            {
                sqParameters.Add(new SqlParameter("@State", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@State", vendor.State));
            }
            if (string.IsNullOrEmpty(vendor.Country))
            {
                sqParameters.Add(new SqlParameter("@Country", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Country", vendor.Country));
            }
            if (string.IsNullOrEmpty(vendor.PostalCode))
            {
                sqParameters.Add(new SqlParameter("@PostalCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PostalCode", vendor.PostalCode));
            }
            if (string.IsNullOrEmpty(vendor.AddressRemarks))
            {
                sqParameters.Add(new SqlParameter("@AddressRemarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AddressRemarks", vendor.AddressRemarks));
            }
            if (string.IsNullOrEmpty(vendor.ContactName))
            {
                sqParameters.Add(new SqlParameter("@ContactName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ContactName", vendor.ContactName));
            }
            if (string.IsNullOrEmpty(vendor.Phone))
            {
                sqParameters.Add(new SqlParameter("@Phone", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Phone", vendor.Phone));
            }
            if (string.IsNullOrEmpty(vendor.Email))
            {
                sqParameters.Add(new SqlParameter("@Email", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Email", vendor.Email));
            }

            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        public List<Vendor> GetVendorList(List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from Vendor";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<Vendor.SearchByVendorParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(Vendor.SearchByVendorParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                       else if (searchParameter.Key.Equals(Vendor.SearchByVendorParameters.VENDOR_CODE) || searchParameter.Key.Equals(Vendor.SearchByVendorParameters.VENDOR_NAME))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " like '%" + searchParameter.Value+"%'");
                        }
                        else
                        {
                            query.Append(joiner + "Isnull(" + DBSearchParameters[searchParameter.Key] + ",'') = '" + searchParameter.Value + "'");
                        }

                        count++;
                    }
                    else
                    {
                        throw new Exception("The query parameter does not exist " + searchParameter.Key);
                    }
                }
                //query.Append(" Order by LastModDttm, LocationId ASC");
                if (searchParameters.Count > 0)
                    selectLocationQuery = selectLocationQuery + query;
            }

            DataTable data = conn.executeSelectScript(selectLocationQuery, null);
            if (data.Rows.Count > 0)
            {
                List<Vendor> vendorList = new List<Vendor>();
                foreach (DataRow row in data.Rows)
                {
                    Vendor vendor = GetVendor(row);
                    vendorList.Add(vendor);
                }
                return vendorList;
            }
            else
            {
                return null;
            }
        }

       
        private Vendor GetVendor(DataRow dr)
        {
            Vendor vendor = new Vendor(
                                dr.IsNull("VendorId") ? 0 : int.Parse(dr["VendorId"].ToString()),
                                dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString()),
                                dr.IsNull("Name") ? "" : dr["Name"].ToString(),
                                dr.IsNull("Remarks") ? "" : dr["Remarks"].ToString(),
                                dr.IsNull("Code") ? "" : dr["Code"].ToString(),
                                dr.IsNull("AddressLine1") ? "" : dr["AddressLine1"].ToString(),
                                dr.IsNull("AddressLine2") ? "" : dr["AddressLine2"].ToString(),
                                dr.IsNull("City") ? "" : dr["City"].ToString(),
                                dr.IsNull("State") ? "" : dr["State"].ToString(),
                                dr.IsNull("Country") ? "" : dr["Country"].ToString(),
                                dr.IsNull("PostalCode") ? "" : dr["PostalCode"].ToString(),
                                dr.IsNull("AddressRemarks") ? "" : dr["AddressRemarks"].ToString(),
                                dr.IsNull("ContactName") ? "" : dr["ContactName"].ToString(),
                                dr.IsNull("Phone") ? "" : dr["Phone"].ToString(),
                                dr.IsNull("Email") ? "" : dr["Email"].ToString(),
                                dr.IsNull("Website") ? "" : dr["Website"].ToString(),
                                dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString(),
                                dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString(),
                                dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]),
                                dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"])
            );

            return vendor;
        }

    }
}
