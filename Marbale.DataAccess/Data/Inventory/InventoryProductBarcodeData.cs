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
    public class InventoryProductBarcodeData
    {
        private DBConnection conn;
        private static readonly Dictionary<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string> DBSearchParameters = new Dictionary<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>
               {
                    {InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.IS_ACTIVE, "isActive"},
                     {InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.PRODUCT_ID, "ProductId"},

    };
        public InventoryProductBarcodeData()
        {
            conn = new DBConnection();
        }

        

        public int InsertOrUpdateInventoryProductBarcode(InventoryProductBarcode inventoryProductBarcode, string userid)
        {
            try
            {
                if (inventoryProductBarcode.Id <= 0)
                {
                    int id = InsertInventoryProductBarcode(inventoryProductBarcode, userid);
                    return id;
                }
                else
                {
                    int id = UpdateInventoryProductBarcode(inventoryProductBarcode, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertInventoryProductBarcode(InventoryProductBarcode inventoryProductBarcode, string userId)
        {
            string query = @"INSERT INTO  [dbo].[InventoryProductBarcode]
                               ([BarCode]
                               ,[ProductId]
                               ,[isActive]
                               ,[CreatedBy]
                               ,[CreatedDate]
                                )
                         VALUES
                               (@BarCode 
                               ,@ProductId 
                               ,@isActive 
                               ,@CreatedBy 
                               ,getdate()
                               )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(inventoryProductBarcode.BarCode))
            {
                sqParameters.Add(new SqlParameter("@BarCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@BarCode", inventoryProductBarcode.BarCode));
            }
            if (inventoryProductBarcode.ProductId <= 0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryProductBarcode.ProductId));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryProductBarcode.IsActive)));
        
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));
            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateInventoryProductBarcode(InventoryProductBarcode inventoryProductBarcode, string userId)
        {
            string query = @"UPDATE dbo.InventoryProductBarcode
                           SET BarCode = @BarCode 
                              ,ProductId = @ProductId 
                              ,isActive = @isActive 
                               
                              ,LastUpdatedBy = @LastUpdatedBy 
                              ,LastUpdatedDate = getdate()
                         WHERE  ID=@Id
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@Id", inventoryProductBarcode.Id));
            if (string.IsNullOrEmpty(inventoryProductBarcode.BarCode))
            {
                sqParameters.Add(new SqlParameter("@BarCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@BarCode", inventoryProductBarcode.BarCode));
            }
            if (inventoryProductBarcode.ProductId <= 0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryProductBarcode.ProductId));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryProductBarcode.IsActive)));

             
            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        private InventoryProductBarcode GetInventoryProductBarcode(DataRow row)
        {
            InventoryProductBarcode productBarcode = new InventoryProductBarcode()
            {
                BarCode = row["BarCode"] == DBNull.Value ? string.Empty : Convert.ToString(row["BarCode"]),
                Id = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]),
                ProductId = row["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(row["ProductId"]),
                CreatedBy = row["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["CreatedBy"]),
                CreatedDate= row["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]),
              LastUpdatedBy=  row["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["LastupdatedBy"]),
              LastUpdatedDate=  row["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["LastupdatedDate"]),
               IsActive= row["isActive"] == DBNull.Value ? false : Convert.ToBoolean(row["isActive"])
            };
            return productBarcode;
        }



        public List<InventoryProductBarcode> GetInventoryProductBarcodeList(List<KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryProductBarcode";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                       else  if (searchParameter.Key.Equals(InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.PRODUCT_ID))
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
                if (searchParameters.Count > 0)
                    selectLocationQuery = selectLocationQuery + query;
            }

            DataTable InventoryProductBarcodeData = conn.executeSelectScript(selectLocationQuery, null);
            if (InventoryProductBarcodeData.Rows.Count > 0)
            {
                List<InventoryProductBarcode> InventoryProductBarcodeList = new List<InventoryProductBarcode>();
                foreach (DataRow row in InventoryProductBarcodeData.Rows)
                {
                    InventoryProductBarcode locationDataObject = GetInventoryProductBarcode(row);
                    InventoryProductBarcodeList.Add(locationDataObject);
                }
                return InventoryProductBarcodeList;
            }
            else
            {
                return null;
            }
        }
    }
}
