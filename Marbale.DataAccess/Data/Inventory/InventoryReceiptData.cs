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
    public class InventoryReceiptData
    {
        private DBConnection conn;
        private static readonly Dictionary<InventoryReceipt.SearchByInventoryReceiptParameters, string> DBSearchParameters = new Dictionary<InventoryReceipt.SearchByInventoryReceiptParameters, string>
               {
                    {InventoryReceipt.SearchByInventoryReceiptParameters.IS_ACTIVE, "IsActive"},
                     {InventoryReceipt.SearchByInventoryReceiptParameters.INVENTORY_RECEIPT_ID, "InventoryReceiptID"},
                      {InventoryReceipt.SearchByInventoryReceiptParameters.VENDOR_NAME, "VendorName"},
                       {InventoryReceipt.SearchByInventoryReceiptParameters.GRN, "GRN"},

        };
        public InventoryReceiptData()
        {
            conn = new DBConnection();
        }


        public int InsertOrUpdateInventoryReceipt(InventoryReceipt inventoryReceipt, string userid)
        {
            try
            {
                if (inventoryReceipt.InventoryReceiptID <= 0)
                {
                    int id = InsertInventoryReceipt(inventoryReceipt, userid);
                    return id;
                }
                else
                {
                    int id = UpdateInventoryReceipt(inventoryReceipt, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertInventoryReceipt(InventoryReceipt inventoryReceipt, string userId)
        {
            string query = @"INSERT INTO  dbo.InventoryReceipt 
                                   ( VendorBillNumber 
                                   , GatePassNumber 
                                   , GRN 
                                   , PurchaseOrderId 
                                   , Remarks 
                                   , ReceiveDate 
                                   , ReceivedBy 
                                   ,IsActive
                                   , CreatedBy 
                                   , CreatedDate 
                                    )
                             VALUES
                                   (
		                           @VendorBillNumber 
                                   ,@GatePassNumber 
                                   ,@GRN 
                                   ,@PurchaseOrderId 
                                   ,@Remarks 
                                   ,@ReceiveDate 
                                   ,@ReceivedBy 
                                   ,@IsActive
                                   ,@CreatedBy 
                                   ,getdate() 
                                   )
                                    SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(inventoryReceipt.VendorBillNumber))
            {
                sqParameters.Add(new SqlParameter("@VendorBillNumber", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@VendorBillNumber", inventoryReceipt.VendorBillNumber));
            }
            if (string.IsNullOrEmpty(inventoryReceipt.GatePassNumber))
            {
                sqParameters.Add(new SqlParameter("@GatePassNumber", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@GatePassNumber", inventoryReceipt.GatePassNumber));
            }
            if (string.IsNullOrEmpty(inventoryReceipt.GRN))
            {
                sqParameters.Add(new SqlParameter("@GRN", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@GRN", inventoryReceipt.GRN));
            }
            if (inventoryReceipt.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", inventoryReceipt.PurchaseOrderId));
            }


            if (string.IsNullOrEmpty(inventoryReceipt.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", inventoryReceipt.Remarks));
            }

            if (inventoryReceipt.ReceiveDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@ReceiveDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ReceiveDate", inventoryReceipt.ReceiveDate));
            }

            if (string.IsNullOrEmpty(inventoryReceipt.ReceivedBy))
            {
                sqParameters.Add(new SqlParameter("@ReceivedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ReceivedBy", inventoryReceipt.GatePassNumber));
            }
            sqParameters.Add(new SqlParameter("@IsActive", inventoryReceipt.IsActive));
           
            if (string.IsNullOrEmpty(inventoryReceipt.CreatedBy))
            {
                sqParameters.Add(new SqlParameter("@CreatedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CreatedBy", inventoryReceipt.GatePassNumber));
            }

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateInventoryReceipt(InventoryReceipt inventoryReceipt, string userId)
        {
            string query = @" UPDATE dbo.InventoryReceipt
                                       SET VendorBillNumber = @VendorBillNumber 
                                          ,GatePassNumber = @GatePassNumber 
                                          ,GRN = @GRN 
                                          ,PurchaseOrderId = @PurchaseOrderId 
                                          ,Remarks = @Remarks 
                                          ,ReceiveDate = @ReceiveDate 
                                          ,ReceivedBy = @ReceivedBy 
                                          ,LastupdatedBy = @LastupdatedBy 
                                          ,LastupdatedDate = ,getdate()
                                     WHERE InventoryReceiptID=@InventoryReceiptID
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@InventoryReceiptID", inventoryReceipt.InventoryReceiptID));

            if (string.IsNullOrEmpty(inventoryReceipt.VendorBillNumber))
            {
                sqParameters.Add(new SqlParameter("@VendorBillNumber", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@VendorBillNumber", inventoryReceipt.VendorBillNumber));
            }
            if (string.IsNullOrEmpty(inventoryReceipt.GatePassNumber))
            {
                sqParameters.Add(new SqlParameter("@GatePassNumber", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@GatePassNumber", inventoryReceipt.GatePassNumber));
            }
            if (string.IsNullOrEmpty(inventoryReceipt.GRN))
            {
                sqParameters.Add(new SqlParameter("@GRN", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@GRN", inventoryReceipt.GRN));
            }
            if (inventoryReceipt.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", inventoryReceipt.PurchaseOrderId));
            }


            if (string.IsNullOrEmpty(inventoryReceipt.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", inventoryReceipt.Remarks));
            }

            if (inventoryReceipt.ReceiveDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@ReceiveDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ReceiveDate", inventoryReceipt.ReceiveDate));
            }

            if (string.IsNullOrEmpty(inventoryReceipt.ReceivedBy))
            {
                sqParameters.Add(new SqlParameter("@ReceivedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ReceivedBy", inventoryReceipt.GatePassNumber));
            }

            if (string.IsNullOrEmpty(inventoryReceipt.CreatedBy))
            {
                sqParameters.Add(new SqlParameter("@CreatedBy", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CreatedBy", inventoryReceipt.GatePassNumber));
            }


            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        public List<InventoryReceipt> GetInventoryReceiptList(List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @" select * from
                                         (
                                         select r.*,v.Name 'VendorName' from InventoryReceipt r
                                         inner join PurchaseOrder po on po.PurchaseOrderId=r.PurchaseOrderId
                                         inner join  vendor v on po.vendorId = v.vendorId
                                         )a";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryReceipt.SearchByInventoryReceiptParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryReceipt.SearchByInventoryReceiptParameters.VENDOR_NAME) || searchParameter.Key.Equals(InventoryReceipt.SearchByInventoryReceiptParameters.GRN))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " like '%" + searchParameter.Value + "%'");
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
                List<InventoryReceipt> purchaseOrderList = new List<InventoryReceipt>();
                foreach (DataRow row in data.Rows)
                {
                    InventoryReceipt inventoryReceipt = GetPurchaseOrder(row);
                    purchaseOrderList.Add(inventoryReceipt);
                }
                return purchaseOrderList;
            }
            else
            {
                return null;
            }
        }


        private InventoryReceipt GetPurchaseOrder(DataRow dr)
        {


            InventoryReceipt inventoryReceipt = new InventoryReceipt(
                                            Convert.ToInt32(dr["InventoryReceiptID"]),
                                            dr["VendorBillNumber"].ToString(),
                                            dr["GatePassNumber"].ToString(),
                                            dr["GRN"].ToString(),
                                            dr["PurchaseOrderId"] == DBNull.Value ?0:  Convert.ToInt32(dr["PurchaseOrderId"]),
                                            dr["Remarks"].ToString(),
                                            dr["ReceiveDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ReceiveDate"]),
                                            dr["ReceivedBy"].ToString(),
                                             dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["isActive"]),
                                            dr["CreatedBy"].ToString(),
                                            dr["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]),
                                            dr["LastupdatedBy"].ToString(),
                                            dr["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastupdatedDate"]),
                                            dr["VendorName"].ToString()
                                            
                                            );

            return inventoryReceipt;
        }
    }
}
