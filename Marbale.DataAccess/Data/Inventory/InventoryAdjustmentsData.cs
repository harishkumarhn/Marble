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
    public class InventoryAdjustmentsData
    {
        private DBConnection conn;
        private static readonly Dictionary<InventoryAdjustments.SearchByInventoryAdjustmentParameters, string> DBSearchParameters = new Dictionary<InventoryAdjustments.SearchByInventoryAdjustmentParameters, string>
               {
                    {InventoryAdjustments.SearchByInventoryAdjustmentParameters.IS_ACTIVE, "IsActive"},


        };
        public InventoryAdjustmentsData()
        {
            conn = new DBConnection();
        }


        public int InsertOrUpdateInventoryAdjustment(InventoryAdjustments inventoryAdjustments, string userid)
        {
            try
            {
                if (inventoryAdjustments.Id <= 0)
                {
                    int id = InsertInventoryAdjustment(inventoryAdjustments, userid);
                    return id;
                }
                //else
                //{
                //    int id = UpdatePurchaseOrder(inventoryAdjustments, userid);
                //    return id;
                //}
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        private int InsertInventoryAdjustment(InventoryAdjustments inventoryAdjustments, string userId)
        {
            string query = @"INSERT INTO   InventoryAdjustments 
                                           ( AdjustmentType 
                                           , ProductId 
                                           , AdjustmentQuantity 
                                           , FromLocationId 
                                           , ToLocationId 
                                           , Remarks 
                                           , IsActive 
                                           , CreatedBy 
                                           , CreatedDate 
                                           )
                                     VALUES
                                           (@AdjustmentType
                                           ,@ProductId
                                           ,@AdjustmentQuantity
                                           ,@FromLocationId
                                           ,@ToLocationId
                                           ,@Remarks
                                           ,@IsActive
                                           ,@CreatedBy
                                           ,getdate()
                                    )SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> sqParameters = new List<SqlParameter>();
            if (string.IsNullOrEmpty( inventoryAdjustments.AdjustmentType))
            {
                sqParameters.Add(new SqlParameter("@AdjustmentType", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AdjustmentType", inventoryAdjustments.AdjustmentType));
            }
            if (inventoryAdjustments.ProductId == -1)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", inventoryAdjustments.ProductId));
            }
            if (inventoryAdjustments.AdjustmentQuantity == -1)
            {
                sqParameters.Add(new SqlParameter("@AdjustmentQuantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@AdjustmentQuantity", inventoryAdjustments.AdjustmentQuantity));
            }
            if (inventoryAdjustments.FromLocationId == -1)
            {
                sqParameters.Add(new SqlParameter("@FromLocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@FromLocationId", inventoryAdjustments.FromLocationId));
            }
            if (inventoryAdjustments.ToLocationId == -1)
            {
                sqParameters.Add(new SqlParameter("@ToLocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ToLocationId", inventoryAdjustments.ToLocationId));
            }
            if (string.IsNullOrEmpty(inventoryAdjustments.Remarks))
            {
                sqParameters.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Remarks", inventoryAdjustments.Remarks));
            }
            
            sqParameters.Add(new SqlParameter("@IsActive", inventoryAdjustments.IsActive));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        //public int UpdatePurchaseOrder(InventoryAdjustments inventoryAdjustments, string userId)
        //{
        //    string query = @"  UPDATE dbo.InventoryAdjustments
        //            SET OrderStatus = @OrderStatus
        //            ,OrderNumber = @OrderNumber
        //            ,OrderDate = @OrderDate
        //            ,VendorId = @VendorId
        //            ,ContactName = @ContactName@
        //            ,Phone = @Phone
        //            ,VendorAddress1 = @VendorAddress1 
        //            ,VendorAddress2 = @VendorAddress2 
        //            ,VendorCity = @VendorCity 
        //            ,VendorState = @VendorState
        //            ,VendorCountry = @VendorCountry
        //            ,VendorPostalCode = @VendorPostalCode
        //            ,ShipToAddress1 = @ShipToAddress1
        //            ,ShipToAddress2 = @ShipToAddress2
        //            ,ShipToCity = @ShipToCity 
        //            ,ShipToState = @ShipToState
        //            ,ShipToCountry = @ShipToCountry
        //            ,ShipToPostalCode = @ShipToPostalCode
        //            ,ShipToAddressRemarks = @ShipToAddressRemarks
        //            ,RequestShipDate = @RequestShipDate
        //            ,OrderTotal = @OrderTotal 
        //            ,LastModUserId = @LastModUserId
        //            ,OrderRemarks = @OrderRemarks
        //            ,ReceiveRemarks = @ReceiveRemarks 
        //            ,CancelledDate = @CancelledDate
        //            ,CreatedBy = @CreatedBy
        //            ,CreatedDate = @CreatedDate
        //            ,LastupdatedBy = @LastupdatedBy
        //            ,LastupdatedDate = @LastupdatedDate
        //            WHERE PurchaseOrderId =@PurchaseOrderId
        //         ";
        //    List<SqlParameter> sqParameters = new List<SqlParameter>();
        //    sqParameters.Add(new SqlParameter("@PurchaseOrderId", inventoryAdjustments.PurchaseOrderId));
        //    sqParameters.Add(new SqlParameter("@OrderStatus", string.IsNullOrEmpty(inventoryAdjustments.OrderStatus) ? "" : inventoryAdjustments.OrderStatus));
        //    sqParameters.Add(new SqlParameter("@OrderNumber", string.IsNullOrEmpty(inventoryAdjustments.OrderNumber) ? "" : inventoryAdjustments.OrderNumber));
        //    if (inventoryAdjustments.OrderDate.Equals(DateTime.MinValue))
        //    {
        //        sqParameters.Add(new SqlParameter("@OrderDate", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@OrderDate", inventoryAdjustments.OrderDate));
        //    }

        //    if (inventoryAdjustments.VendorId == -1)
        //    {
        //        sqParameters.Add(new SqlParameter("@VendorId", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@VendorId", inventoryAdjustments.VendorId));
        //    }

        //    //if (inventoryAdjustments.ReceivedDate.Equals(DateTime.MinValue))
        //    //{
        //    //    sqParameters.Add(new SqlParameter("@ReceivedDate", DBNull.Value));
        //    //}
        //    //else
        //    //{
        //    //    sqParameters.Add(new SqlParameter("@ReceivedDate", inventoryAdjustments.ReceivedDate));
        //    //}
        //    sqParameters.Add(new SqlParameter("@ContactName", string.IsNullOrEmpty(inventoryAdjustments.ContactName) ? "" : inventoryAdjustments.ContactName));
        //    sqParameters.Add(new SqlParameter("@Phone", string.IsNullOrEmpty(inventoryAdjustments.Phone) ? "" : inventoryAdjustments.Phone));
        //    sqParameters.Add(new SqlParameter("@VendorAddress1", string.IsNullOrEmpty(inventoryAdjustments.VendorAddress1) ? "" : inventoryAdjustments.VendorAddress1));
        //    sqParameters.Add(new SqlParameter("@VendorAddress2", string.IsNullOrEmpty(inventoryAdjustments.VendorAddress2) ? "" : inventoryAdjustments.VendorAddress2));
        //    sqParameters.Add(new SqlParameter("@VendorCity", string.IsNullOrEmpty(inventoryAdjustments.VendorCity) ? "" : inventoryAdjustments.VendorCity));
        //    sqParameters.Add(new SqlParameter("@VendorState", string.IsNullOrEmpty(inventoryAdjustments.VendorState) ? "" : inventoryAdjustments.VendorState));
        //    sqParameters.Add(new SqlParameter("@VendorCountry", string.IsNullOrEmpty(inventoryAdjustments.VendorCountry) ? "" : inventoryAdjustments.VendorCountry));
        //    sqParameters.Add(new SqlParameter("@VendorPostalCode", string.IsNullOrEmpty(inventoryAdjustments.VendorPostalCode) ? "" : inventoryAdjustments.VendorPostalCode));
        //    sqParameters.Add(new SqlParameter("@ShipToAddress1", string.IsNullOrEmpty(inventoryAdjustments.ShipToAddress1) ? "" : inventoryAdjustments.ShipToAddress1));
        //    sqParameters.Add(new SqlParameter("@ShipToAddress2", string.IsNullOrEmpty(inventoryAdjustments.ShipToAddress2) ? "" : inventoryAdjustments.ShipToAddress2));
        //    sqParameters.Add(new SqlParameter("@ShipToCity", string.IsNullOrEmpty(inventoryAdjustments.ShipToCity) ? "" : inventoryAdjustments.ShipToCity));
        //    sqParameters.Add(new SqlParameter("@ShipToState", string.IsNullOrEmpty(inventoryAdjustments.ShipToState) ? "" : inventoryAdjustments.ShipToState));
        //    sqParameters.Add(new SqlParameter("@ShipToCountry", string.IsNullOrEmpty(inventoryAdjustments.ShipToCountry) ? "" : inventoryAdjustments.ShipToCountry));
        //    sqParameters.Add(new SqlParameter("@ShipToPostalCode", string.IsNullOrEmpty(inventoryAdjustments.ShipToPostalCode) ? "" : inventoryAdjustments.ShipToPostalCode));
        //    sqParameters.Add(new SqlParameter("@ShipToAddressRemarks", string.IsNullOrEmpty(inventoryAdjustments.ShipToAddressRemarks) ? "" : inventoryAdjustments.ShipToAddressRemarks));
        //    if (inventoryAdjustments.RequestShipDate.Equals(DateTime.MinValue))
        //    {
        //        sqParameters.Add(new SqlParameter("@RequestShipDate", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@RequestShipDate", inventoryAdjustments.RequestShipDate));
        //    }

        //    //sqParameters.Add(new SqlParameter("@OrderRemarks", string.IsNullOrEmpty(inventoryAdjustments.OrderRemarks) ? "" : inventoryAdjustments.OrderRemarks));
        //    sqParameters.Add(new SqlParameter("@OrderTotal", inventoryAdjustments.OrderTotal));
        //    //sqParameters.Add(new SqlParameter("@LastModUserId", userId));

        //    if (inventoryAdjustments.CancelledDate.Equals(DateTime.MinValue))
        //    {
        //        sqParameters.Add(new SqlParameter("@CancelledDate", DBNull.Value));
        //    }
        //    else
        //    {
        //        sqParameters.Add(new SqlParameter("@CancelledDate", inventoryAdjustments.CancelledDate));
        //    }

        //    sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
        //    int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
        //    return rowsUpdated;
        //}


        public List<InventoryAdjustments> GetInventoryAdjustmentsList(List<KeyValuePair<InventoryAdjustments.SearchByInventoryAdjustmentParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryAdjustments";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryAdjustments.SearchByInventoryAdjustmentParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryAdjustments.SearchByInventoryAdjustmentParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        //else if (searchParameter.Key.Equals(Vendor.SearchByVendorParameters.VENDOR_CODE) || searchParameter.Key.Equals(Vendor.SearchByVendorParameters.VENDOR_NAME))
                        //{
                        //    query.Append(joiner + DBSearchParameters[searchParameter.Key] + " like '%" + searchParameter.Value + "%'");
                        //}
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
                List<InventoryAdjustments> inventoryAdjustmentsList = new List<InventoryAdjustments>();
                foreach (DataRow row in data.Rows)
                {
                    InventoryAdjustments inventoryAdjustments = GetInventoryAdjustments(row);
                    inventoryAdjustmentsList.Add(inventoryAdjustments);
                }
                return inventoryAdjustmentsList;
            }
            else
            {
                return null;
            }
        }



        

        private InventoryAdjustments GetInventoryAdjustments(DataRow dr)
        {



            InventoryAdjustments inventoryAdjustments = new InventoryAdjustments(
                            Convert.ToInt32(dr["Id"]),
                            dr["AdjustmentType"] == DBNull.Value ? "" :  dr["AdjustmentType"].ToString(),
                            dr["ProductId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["ProductId"]),
                            dr["AdjustmentQuantity"] == DBNull.Value ? -1 : Convert.ToDouble(dr["AdjustmentQuantity"]),
                            dr["FromLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["FromLocationId"]),
                            dr["ToLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["ToLocationId"]),
                            dr["Remarks"] == DBNull.Value ? "" : dr["Remarks"].ToString(),
                            dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["isActive"]),
                            dr["CreatedBy"].ToString(),
                            dr["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]),
                            dr["LastupdatedBy"].ToString(),
                            dr["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastupdatedDate"])
                            );
            return inventoryAdjustments;
        }
    }
}
