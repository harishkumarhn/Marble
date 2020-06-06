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
    public class InventoryPhysicalCountData
    {

        private DBConnection conn;
        private static readonly Dictionary<InventoryPhysicalCount.SearchByPhysicalCountParameters, string> DBSearchInventoryStoreParameters = new Dictionary<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>
               {
                    {InventoryPhysicalCount.SearchByPhysicalCountParameters.IS_ACTIVE, "IsActive"},
                    {InventoryPhysicalCount.SearchByPhysicalCountParameters.ID, "Id"},
                     {InventoryPhysicalCount.SearchByPhysicalCountParameters.STATUS, "Status"},
                     
                     
                };
        public InventoryPhysicalCountData()
        {
            conn = new DBConnection();
        }

        public int InsertInventoryStore(InventoryPhysicalCount inventoryPhysicalCount, string userId)
        {
            string query = @"INSERT INTO dbo.InventoryPhysicalCount
                                (Description
                                ,Status
                                ,InitaitedDate
                                ,ClosedDate
                                ,InitiatedBy
                                ,ClosedBy
                                ,IsActive)
                                VALUES
                                (@Description
                                ,@Status
                                ,@InitaitedDate
                                ,@ClosedDate
                                ,@InitiatedBy
                                ,@ClosedBy
                                ,@IsActive
                                )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(inventoryPhysicalCount.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", inventoryPhysicalCount.Description));
            }
            if (string.IsNullOrEmpty(inventoryPhysicalCount.Status))
            {
                sqParameters.Add(new SqlParameter("@Status", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Status", inventoryPhysicalCount.Status));
            }
            if (inventoryPhysicalCount.InitaitedDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@InitaitedDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@InitaitedDate", inventoryPhysicalCount.InitaitedDate));
            }
            if (inventoryPhysicalCount.ClosedDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@ClosedDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ClosedDate", inventoryPhysicalCount.ClosedDate));
            }

            if (string.IsNullOrEmpty(inventoryPhysicalCount.InitiatedBy))
            {
                sqParameters.Add(new SqlParameter("@InitiatedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@InitiatedBy", inventoryPhysicalCount.InitiatedBy));
            }
            if (string.IsNullOrEmpty(inventoryPhysicalCount.ClosedBy))
            {
                sqParameters.Add(new SqlParameter("@ClosedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ClosedBy", inventoryPhysicalCount.ClosedBy));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryPhysicalCount.IsActive)));
          

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int InsertOrUpdateInventoryStore(InventoryPhysicalCount inventoryPhysicalCount, string userid)
        {
            try
            {
                if (inventoryPhysicalCount.Id <= 0)
                {
                    int id = InsertInventoryStore(inventoryPhysicalCount, userid);
                    return id;
                }
                else
                {
                    int id = UpdateInventoryStore(inventoryPhysicalCount, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int UpdateInventoryStore(InventoryPhysicalCount inventoryPhysicalCount, string userId)
        {
            string query = @"UPDATE dbo.InventoryPhysicalCount
                               SET Description = @Description 
                                  ,Status = @Status 
                                 --,InitaitedDate = @InitaitedDate 
                                  ,ClosedDate = @ClosedDate 
                                --  ,InitiatedBy = @InitiatedBy 
                                  ,ClosedBy = @ClosedBy 
                                  ,IsActive = @IsActive 
                             WHERE Id=@Id
                                ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@Id", inventoryPhysicalCount.Id));

            if (string.IsNullOrEmpty(inventoryPhysicalCount.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", inventoryPhysicalCount.Description));
            }
            if (string.IsNullOrEmpty(inventoryPhysicalCount.Status))
            {
                sqParameters.Add(new SqlParameter("@Status", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Status", inventoryPhysicalCount.Status));
            }
            if (inventoryPhysicalCount.InitaitedDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@InitaitedDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@InitaitedDate", inventoryPhysicalCount.InitaitedDate));
            }
            if (inventoryPhysicalCount.ClosedDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@ClosedDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ClosedDate", inventoryPhysicalCount.ClosedDate));
            }

            if (string.IsNullOrEmpty(inventoryPhysicalCount.InitiatedBy))
            {
                sqParameters.Add(new SqlParameter("@InitiatedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@InitiatedBy", inventoryPhysicalCount.InitiatedBy));
            }
            if (string.IsNullOrEmpty(inventoryPhysicalCount.ClosedBy))
            {
                sqParameters.Add(new SqlParameter("@ClosedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ClosedBy", inventoryPhysicalCount.ClosedBy));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(inventoryPhysicalCount.IsActive)));


             
            sqParameters.Add(new SqlParameter("@LastUpdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }
        

        private InventoryPhysicalCount GetInventoryStore(DataRow row)
        {
            InventoryPhysicalCount inventoryPhysicalCount = new InventoryPhysicalCount() {

                Id = row["Id"] == DBNull.Value ? 0 : Convert.ToInt32(row["Id"]),
                Description = row["Description"] == DBNull.Value ? "" : row["Description"].ToString(),
                Status = row["Status"] == DBNull.Value ? "" : row["Status"].ToString(),
                InitiatedBy = row["InitiatedBy"] == DBNull.Value ? "" : row["InitiatedBy"].ToString(),
                ClosedBy = row["ClosedBy"] == DBNull.Value ? "" : row["ClosedBy"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                InitaitedDate = row["InitaitedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["InitaitedDate"]),
                ClosedDate = row["ClosedDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ClosedDate"]),
                IsChanged = false
            };
            return inventoryPhysicalCount;
        }

        public List<InventoryPhysicalCount> GetInventoryStoreList(List<KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryPhysicalCount";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryPhysicalCount.SearchByPhysicalCountParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchInventoryStoreParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryPhysicalCount.SearchByPhysicalCountParameters.IS_ACTIVE) || searchParameter.Key.Equals(InventoryPhysicalCount.SearchByPhysicalCountParameters.ID))
                        {
                            query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryPhysicalCount.SearchByPhysicalCountParameters.STATUS)  )
                        {
                            query.Append(joiner + DBSearchInventoryStoreParameters[searchParameter.Key] + " = '" + searchParameter.Value+"'");
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
                List<InventoryPhysicalCount> inventories = new List<InventoryPhysicalCount>();
                foreach (DataRow row in dt.Rows)
                {
                    InventoryPhysicalCount inventoryPhysicalCount = GetInventoryStore(row);
                    inventories.Add(inventoryPhysicalCount);
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
