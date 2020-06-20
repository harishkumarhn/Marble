using Marbale.BusinessObject.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data.Inventory
{
    public class InventoryAdjustmentsActivityData
    {

        private DBConnection conn;
        private static readonly Dictionary<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string> DBSearchParameters = new Dictionary<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>
               {
                    {InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.IS_ACTIVE, "IsActive"},
                     {InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.PRODUCT_ID, "ProductId"},
                      {InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.LOCATION_ID, "LocationId"},


        };
        public InventoryAdjustmentsActivityData()
        {
            conn = new DBConnection();
        }
        public List<InventoryAdjustmentsActivity> GetInventoryAdjustmentsActivityList(List<KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select	a.TrxType, a.ProductId,  a.LocationId,  a.TransferLocationId,  a.Quantity,  
		                                a.LastUpdatedDate,  a.LastUpdatedBy,l.Name 'FromLocation' ,l2.Name 'TransferLocation'   
		                                from  InventoryActivity a

		                                left join  Location l on l.LocationId=a.LocationId
		                                left join  Location l2 on l2.LocationId=a.TransferLocationId
		                                 ";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.IS_ACTIVE))
                        {
                            //query.Append(joiner + "a." + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.PRODUCT_ID) || searchParameter.Key.Equals(InventoryAdjustmentsActivity.SearchByInventoryAdjustmentActivityParameters.LOCATION_ID))
                        {
                            query.Append(joiner + "a."+DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value );
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
                List<InventoryAdjustmentsActivity> inventoryAdjustmentsAList = new List<InventoryAdjustmentsActivity>();
                foreach (DataRow row in data.Rows)
                {
                    InventoryAdjustmentsActivity inventoryAdjustmentsActivity = GetInventoryAdjustmentsActivity(row);
                    inventoryAdjustmentsAList.Add(inventoryAdjustmentsActivity);
                }
                return inventoryAdjustmentsAList;
            }
            else
            {
                return null;
            }
        }





        private InventoryAdjustmentsActivity GetInventoryAdjustmentsActivity(DataRow dr)
        {
            InventoryAdjustmentsActivity inventoryAdjustmentsActivity = new InventoryAdjustmentsActivity()
            {
                TrxType = dr["TrxType"] == DBNull.Value ? "" : dr["TrxType"].ToString(),
                ProductId = dr["ProductId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["ProductId"]),
                ProductName = dr["TransferLocation"] == DBNull.Value ? "" : dr["TransferLocation"].ToString(),
                LocationId = dr["LocationId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["LocationId"]),
                TransferLocationId = dr["TransferLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["TransferLocationId"]),
                Quantity = dr["Quantity"] == DBNull.Value ? -1 : Convert.ToInt32(dr["Quantity"]),
                LastUpdatedDate = dr["LastUpdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastUpdatedDate"]),
                LastUpdatedBy = dr["LastUpdatedBy"] == DBNull.Value ? "" : dr["LastUpdatedBy"].ToString(),
                FromLocation = dr["FromLocation"] == DBNull.Value ? "" : dr["FromLocation"].ToString(),
                TransferLocation = dr["TransferLocation"] == DBNull.Value ? "" : dr["TransferLocation"].ToString(),
                IsChanged=false

            };

                           
            return inventoryAdjustmentsActivity;
        }
    }
}
