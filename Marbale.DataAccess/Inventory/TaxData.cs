using Marbale.BusinessObject.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data.Inventory
{
    public class TaxData
    {

        private DBConnection conn;
        private static readonly Dictionary<Tax.SearchByTaxParameters, string> DBSearchParameters = new Dictionary<Tax.SearchByTaxParameters, string>
               {
                    {Tax.SearchByTaxParameters.IS_ACTIVE, "1"},

                };
        public TaxData()
        {
            conn = new DBConnection();
        }

        public int InsertTax(Tax tax, string userId)
        {
            string query = @"INSERT INTO dbo.PurchaseTax
                            (TaxName
                            ,TaxPercentage
                            ,IsActive
                            ,CreatedBy
                            ,CreatedDate
                            )
                            VALUES
                            (@TaxName 
                            ,@TaxPercentage 
                            ,@IsActive 
                            ,@CreatedBy 
                            ,getdate() 
           
                                           )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(tax.TaxName))
            {
                sqParameters.Add(new SqlParameter("@TaxName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxName", tax.TaxName));
            }
            sqParameters.Add(new SqlParameter("@TaxPercentage", Convert.ToDouble(tax.TaxPercentage)));
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(tax.IsActive)));

            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int InsertOrUpdateTax(Tax tax, string userid)
        {
            try
            {
                if (tax.TaxId <= 0 )
                {
                    int id = InsertTax(tax, userid);
                    return id;
                }
                else
                {
                    int id = UpdateTax(tax, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int UpdateTax(Tax tax, string userId)
        {
            string query = @"UPDATE dbo.PurchaseTax
                                SET TaxName = @TaxName 
                                ,TaxPercentage = @TaxPercentage 
                                ,IsActive = @IsActive 
                                ,LastUpdatedBy = @LastUpdatedBy 
                                ,LastUpdatedDate = getdate() 
                                WHERE TaxId=@TaxId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@TaxId", tax.TaxId));
            if (string.IsNullOrEmpty(tax.TaxName))
            {
                sqParameters.Add(new SqlParameter("@TaxName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxName", tax.TaxName));
            }
            sqParameters.Add(new SqlParameter("@TaxPercentage", Convert.ToDouble(tax.TaxPercentage)));
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(tax.IsActive)));

            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        private Tax GetTax(DataRow locationDataRow)
        {
            Tax location = new Tax(
            Convert.ToInt32(locationDataRow["TaxId"]),
            locationDataRow["TaxName"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["TaxName"]),
            locationDataRow["TaxPercentage"] == DBNull.Value ? 0 : Convert.ToDouble(locationDataRow["TaxPercentage"]),
              locationDataRow["isActive"] == DBNull.Value ? false : Convert.ToBoolean(locationDataRow["isActive"]),
            locationDataRow["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["CreatedBy"]),
                locationDataRow["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["LastupdatedBy"]),
            locationDataRow["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(locationDataRow["CreatedDate"]),
            locationDataRow["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(locationDataRow["LastupdatedDate"])

            );

            return location;
        }



        public List<Tax> GetTaxList(List<KeyValuePair<Tax.SearchByTaxParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from PurchaseTax";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<Tax.SearchByTaxParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(Tax.SearchByTaxParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
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

            DataTable taxData = conn.executeSelectScript(selectLocationQuery, null);
            if (taxData.Rows.Count > 0)
            {
                List<Tax> taxList = new List<Tax>();
                foreach (DataRow row in taxData.Rows)
                {
                    Tax locationDataObject = GetTax(row);
                    taxList.Add(locationDataObject);
                }
                return taxList;
            }
            else
            {
                return null;
            }
        }
    }
}
