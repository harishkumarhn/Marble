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
    public class InventoryPhysicalCountLogData

    {

        private DBConnection conn;
        private static readonly Dictionary<InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters, string> DBSearchInventoryStoreParameters = new Dictionary<InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters, string>
               {
                    {InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters.PRODUCT_ID, "ProductId"},
                     {InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters.LOCATION_ID, "LocationId"},
                };
        public InventoryPhysicalCountLogData()
        {
            conn = new DBConnection();
        }

        public int InsertInventoryPhysicalCountLog(InventoryPhysicalCountLog inventoryPhysicalCountLog, string userId)
        {
            string query = @"INSERT INTO dbo.InventoryPhysicalCountLog
                           (ProductId
                           ,LocationId
                           ,PhysicalCountId
                           ,Quantity
                           ,AllocatedQuantity
                           ,CreatedBy
                           ,CreatedDate
                           ,LastUpdatedBy
                           ,LastUpdatedDate)
                     VALUES
                           (@ProductId
                           ,@LocationId
                           ,@PhysicalCountId
                           ,@Quantity
                           ,@AllocatedQuantity
                           ,@CreatedBy
                           ,GETDATE()
		                    )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            if (inventoryPhysicalCountLog.ProductId <= 0)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryPhysicalCountLog.ProductId));
            }
            if (inventoryPhysicalCountLog.LocationId <= 0)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", inventoryPhysicalCountLog.LocationId));
            }

            if (inventoryPhysicalCountLog.PhysicalCountId <= 0)
            {
                sqParameters.Add(new SqlParameter("@PhysicalCountId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PhysicalCountId", inventoryPhysicalCountLog.PhysicalCountId));
            }
            if (inventoryPhysicalCountLog.Quantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Quantity", inventoryPhysicalCountLog.Quantity));
            }
            if (inventoryPhysicalCountLog.AllocatedQuantity <= 0)
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AllocatedQuantity", inventoryPhysicalCountLog.AllocatedQuantity));
            }

            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }
        public int InsertInventoryPhysicalCountLogByID(int physicalCountId, string userId)
        {
            string query = @"insert into InventoryPhysicalCountLog 
							(
							ProductId
                           ,LocationId
                           ,PhysicalCountId
                           ,Quantity
                           ,AllocatedQuantity
                           ,CreatedBy
                           ,CreatedDate
                           )
						   select 
						   ProductId,
						   LocationId,
						   @physicalCountId,
						    Quantity,
							AllocatedQuantity
                           ,@CreatedBy
                           ,GETDATE() from InventoryStore
		                     SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@physicalCountId", physicalCountId));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));
            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }
        public int InsertOrUpdateInventoryPhysicalCountLog(InventoryPhysicalCountLog inventoryPhysicalCountLog, string userid)
        {
            try
            {
                if (inventoryPhysicalCountLog.Id <= 0)
                {
                    int id = InsertInventoryPhysicalCountLog(inventoryPhysicalCountLog, userid);
                    return id;
                }
                else
                {
                    //int id = UpdateInventoryStore(inventoryPhysicalCountLog, userid);
                    //return id;
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //public int UpdateInventoryStore(InventoryPhysicalCountLog inventoryPhysicalCountLog, string userId)
        //{
        //    string query = @"UPDATE   dbo . InventoryPhysicalCountLog 
        //            SET  ProductId  =@ProductId
        //            , LocationId  = @LocationId
        //            , Quantity  = @Quantity
        //            , AllocatedQuantity  = @AllocatedQuantity
        //            , Remarks  = @Remarks 
        //            , IsActive  = @IsActive
        //            , LastUpdatedBy  =@LastUpdatedBy
        //            , LastUpdatedDate  = getdate() 
        //                        ";
        //    List<SqlParameter> sqParameters = new List<SqlParameter>();
        //    sqParameters.Add(new SqlParameter("@Id", inventoryPhysicalCountLog.Id));

        //    if (inventoryPhysicalCountLog.ProductId <= 0)
        //    {
        //        sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@ProductId", inventoryPhysicalCountLog.ProductId));
        //    }
        //    if (inventoryPhysicalCountLog.LocationId <= 0)
        //    {
        //        sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@LocationId", inventoryPhysicalCountLog.LocationId));
        //    }
        //    if (inventoryPhysicalCountLog.Quantity <= 0)
        //    {
        //        sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@Quantity", inventoryPhysicalCountLog.Quantity));
        //    }
        //    if (inventoryPhysicalCountLog.AllocatedQuantity <= 0)
        //    {
        //        sqParameters.Add(new SqlParameter("@AllocatedQuantity", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@AllocatedQuantity", inventoryPhysicalCountLog.AllocatedQuantity));
        //    }

        //    if (string.IsNullOrEmpty(inventoryPhysicalCountLog.Remarks))
        //    {
        //        sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@Remarks", inventoryPhysicalCountLog.Remarks));
        //    }

        //    sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryPhysicalCountLog.IsActive)));
        //    sqParameters.Add(new SqlParameter("@LastUpdatedBy", userId));
        //    int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
        //    return rowsUpdated;
        //}


        private InventoryPhysicalCountLog GetInventoryPhysicalCountLog(DataRow row)
        {
            InventoryPhysicalCountLog inventoryPhysicalCountLog = new InventoryPhysicalCountLog()
            {

            };
            // Convert.ToInt32(row["Id"]),
            // row["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(row["ProductId"]),
            //      row["LocationId"] == DBNull.Value ? 0 : Convert.ToInt32(row["LocationId"]),
            //           row["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(row["Quantity"]),
            //                row["AllocatedQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(row["AllocatedQuantity"]),

            //row["Remarks"] == DBNull.Value ? string.Empty : Convert.ToString(row["Remarks"]),
            //   row["isActive"] == DBNull.Value ? false : Convert.ToBoolean(row["isActive"]),
            // row["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["CreatedBy"]),
            //     row["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["LastupdatedBy"]),
            // row["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]),
            // row["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["LastupdatedDate"])

            // );

            return inventoryPhysicalCountLog;
        }



        public List<InventoryPhysicalCountLog> GetInventoryPhysicalCountLogList(List<KeyValuePair<InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryPhysicalCountLog";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchInventoryStoreParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        //if (searchParameter.Key.Equals(InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters.IS_ACTIVE))
                        //{
                        //    query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        //}
                        //else if (searchParameter.Key.Equals(InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters.PRODUCT_ID) ||
                        //        searchParameter.Key.Equals(InventoryPhysicalCountLog.SearchByPhysicalCountLogParameters.LOCATION_ID))
                        //{
                        //    query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        //}
                        //else
                        //{
                        //    query.Append(joiner + "Isnull(" + DBSearchInventoryStoreParameters[searchParameter.Key] + ",'') = '" + searchParameter.Value + "'");
                        //}

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
                List<InventoryPhysicalCountLog> inventories = new List<InventoryPhysicalCountLog>();
                foreach (DataRow row in dt.Rows)
                {
                    InventoryPhysicalCountLog inventoryPhysicalCountLog = GetInventoryPhysicalCountLog(row);
                    inventories.Add(inventoryPhysicalCountLog);
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
