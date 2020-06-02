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
    public class InventoryStoreData
   
    {

        private DBConnection conn;
        private static readonly Dictionary<InventoryStore.SearchByInventoryStoreParameters, string> DBSearchInventoryStoreParameters = new Dictionary<InventoryStore.SearchByInventoryStoreParameters, string>
               {
                    {InventoryStore.SearchByInventoryStoreParameters.IS_ACTIVE, "IsActive"},
                    {InventoryStore.SearchByInventoryStoreParameters.PRODUCT_ID, "ProductId"},
                     {InventoryStore.SearchByInventoryStoreParameters.LOCATION_ID, "LocationId"},
                };
        public InventoryStoreData()
        {
            conn = new DBConnection();
        }

        public int InsertInventoryStore(InventoryStore inventoryStore, string userId)
        {
            string query = @"INSERT INTO dbo.InventoryStore
                            ( ProductId 
                            , LocationId 
                            , Quantity 
                            , AllocatedQuantity 
                            , Remarks 
                            , IsActive 
                            , CreatedBy 
                            , CreatedDate 
                            )
                            VALUES
                            (                           
                            @ProductId 
                            , @LocationId 
                            , @Quantity 
                            , @AllocatedQuantity 
                            , @Remarks 
                            , @IsActive 
                            , @CreatedBy 
                            ,getdate() 
                            )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            if ( inventoryStore.ProductId<=0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryStore.ProductId));
            }
            if (inventoryStore.LocationId <= 0)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", inventoryStore.LocationId));
            }
            if (inventoryStore.Quantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Quantity", inventoryStore.Quantity));
            }
            if (inventoryStore.AllocatedQuantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", inventoryStore.AllocatedQuantity));
            }

            if (string.IsNullOrEmpty(inventoryStore.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", inventoryStore.Remarks));
            }
            
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryStore.IsActive)));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int InsertOrUpdateInventoryStore(InventoryStore inventoryStore, string userid)
        {
            try
            {
                if (inventoryStore.Id <= 0)
                {
                    int id = InsertInventoryStore(inventoryStore, userid);
                    return id;
                }
                else
                {
                    int id = UpdateInventoryStore(inventoryStore, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int UpdateInventoryStore(InventoryStore inventoryStore, string userId)
        {
            string query = @"UPDATE   dbo . InventoryStore 
                    SET  ProductId  =@ProductId
                    , LocationId  = @LocationId
                    , Quantity  = @Quantity
                    , AllocatedQuantity  = @AllocatedQuantity
                    , Remarks  = @Remarks 
                    , IsActive  = @IsActive
                    , LastUpdatedBy  =@LastUpdatedBy
                    , LastUpdatedDate  = getdate() 
                                ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@Id", inventoryStore.Id));
            
            if (inventoryStore.ProductId <= 0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryStore.ProductId));
            }
            if (inventoryStore.LocationId <= 0)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", inventoryStore.LocationId));
            }
            if (inventoryStore.Quantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Quantity", inventoryStore.Quantity));
            }
            if (inventoryStore.AllocatedQuantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", inventoryStore.AllocatedQuantity));
            }

            if (string.IsNullOrEmpty(inventoryStore.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", inventoryStore.Remarks));
            }

            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryStore.IsActive)));
            sqParameters.Add(new SqlParameter("@LastUpdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }
        public int UpdateInventoryStoreOnAdjustment(InventoryStore inventoryStore, string userId)
        {
            string query = @"UPDATE   dbo . InventoryStore 
                    SET  
                   Quantity  =  isnull(Quantity,0) + (@Quantity)
                    , LastUpdatedBy  =@LastUpdatedBy
                    , LastUpdatedDate  = getdate() 
                    where ProductId  =@ProductId 
                    and LocationId  = @LocationId";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (inventoryStore.ProductId <= 0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryStore.ProductId));
            }
            if (inventoryStore.LocationId <= 0)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", inventoryStore.LocationId));
            }
           
           
                sqParameters.Add(new SqlParameter("@Quantity", inventoryStore.Quantity));
            
             sqParameters.Add(new SqlParameter("@LastUpdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        private InventoryStore GetInventoryStore(DataRow row)
        {
            InventoryStore location = new InventoryStore(
            Convert.ToInt32(row["Id"]),
            row["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(row["ProductId"]),
                 row["LocationId"] == DBNull.Value ? 0 : Convert.ToInt32(row["LocationId"]),
                      row["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(row["Quantity"]),
                           row["AllocatedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(row["AllocatedQuantity"]),

           row["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(row["Remarks"]),
              row["isActive"] == DBNull.Value ? false : Convert.ToBoolean(row["isActive"]),
            row["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["CreatedBy"]),
                row["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["LastupdatedBy"]),
            row["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]),
            row["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["LastupdatedDate"])

            );

            return location;
        }



        public List<InventoryStore> GetInventoryStoreList(List<KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryStore";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryStore.SearchByInventoryStoreParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchInventoryStoreParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryStore.SearchByInventoryStoreParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryStore.SearchByInventoryStoreParameters.PRODUCT_ID) ||
                                searchParameter.Key.Equals(InventoryStore.SearchByInventoryStoreParameters.LOCATION_ID))
                        {
                            query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else
                        {
                            query.Append(joiner + "Isnull(" + DBSearchInventoryStoreParameters[searchParameter.Key] + ",'') = '" + searchParameter.Value + "'");
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

            DataTable dt = conn.executeSelectScript(selectLocationQuery, null);
            if (dt.Rows.Count > 0)
            {
                List<InventoryStore> inventories = new List<InventoryStore>();
                foreach (DataRow row in dt.Rows)
                {
                    InventoryStore inventoryStore = GetInventoryStore(row);
                    inventories.Add(inventoryStore);
                }
                return inventories;
            }
            else
            {
                return null;
            }
        }
    }
}
