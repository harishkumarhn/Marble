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
    public class PurchaseOrderData
    {
        private DBConnection conn;
        private static readonly Dictionary<PurchaseOrder.SearchByPurchaseOrderParameters, string> DBSearchParameters = new Dictionary<PurchaseOrder.SearchByPurchaseOrderParameters, string>
               {
                    {PurchaseOrder.SearchByPurchaseOrderParameters.IS_ACTIVE, "IsActive"},


        };
        public PurchaseOrderData()
        {
            conn = new DBConnection();
        }


        public int InsertOrUpdatePurchaseOrder(PurchaseOrder purchaseOrder, string userid)
        {
            try
            {
                if (purchaseOrder.PurchaseOrderId <= 0)
                {
                    int id = InsertPurchaseOrder(purchaseOrder, userid);
                    return id;
                }
                else
                {
                    int id = UpdatePurchaseOrder(purchaseOrder, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertPurchaseOrder(PurchaseOrder purchaseOrder, string userId)
        {
            string query = @"INSERT INTO dbo.PurchaseOrder
                                   (
			                        OrderStatus
                                   ,OrderNumber
                                   ,OrderDate
                                   ,VendorId
                                   ,ContactName
                                   ,Phone
                                   ,VendorAddress1
                                   ,VendorAddress2
                                   ,VendorCity
                                   ,VendorState
                                   ,VendorCountry
                                   ,VendorPostalCode
                                   ,ShipToAddress1
                                   ,ShipToAddress2
                                   ,ShipToCity
                                   ,ShipToState
                                   ,ShipToCountry
                                   ,ShipToPostalCode
                                   ,ShipToAddressRemarks
                                   ,RequestShipDate
                                   ,OrderTotal
                                   ,LastModUserId
                                   ,OrderRemarks
                                   ,ReceiveRemarks
                                   ,CancelledDate
                                   ,CreatedBy
                                   ,CreatedDate
                                   ,LastupdatedBy
                                   ,LastupdatedDate)
                             VALUES
                                   (
		                           @OrderStatus
                                   ,@OrderNumber
                                   ,@OrderDate
                                   ,@VendorId
                                   ,@ContactName
                                   ,@Phone
                                   ,@VendorAddress1
                                   ,@VendorAddress2
                                   ,@VendorCity
                                   ,@VendorState
                                   ,@VendorCountry
                                   ,@VendorPostalCode
                                   ,@ShipToAddress1
                                   ,@ShipToAddress2
                                   ,@ShipToCity
                                   ,@ShipToState
                                   ,@ShipToCountry
                                   ,@ShipToPostalCode
                                   ,@ShipToAddressRemarks
                                   ,@RequestShipDate
                                   ,@OrderTotal
                                   
                                   ,@OrderRemarks
                                   ,@ReceiveRemarks
                                   ,@CancelledDate
                                   ,@CreatedBy
                                   ,getdate()
                                    )SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@OrderStatus", string.IsNullOrEmpty(purchaseOrder.OrderStatus) ? "" : purchaseOrder.OrderStatus));
            sqParameters.Add(new SqlParameter("@OrderNumber", string.IsNullOrEmpty(purchaseOrder.OrderNumber) ? "" : purchaseOrder.OrderNumber));
            if (purchaseOrder.OrderDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@OrderDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@OrderDate", purchaseOrder.OrderDate));
            }

            if (purchaseOrder.VendorId == -1)
            {
                sqParameters.Add(new SqlParameter("@VendorId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@VendorId", purchaseOrder.VendorId));
            }

            //if (purchaseOrder.ReceivedDate.Equals(DateTime.MinValue))
            //{
            //    sqParameters.Add(new SqlParameter("@ReceivedDate", DBNull.Value));
            //}
            //else
            //{
            //    sqParameters.Add(new SqlParameter("@ReceivedDate", purchaseOrder.ReceivedDate));
            //}
            sqParameters.Add(new SqlParameter("@ContactName", string.IsNullOrEmpty(purchaseOrder.ContactName) ? "" : purchaseOrder.ContactName));
            sqParameters.Add(new SqlParameter("@Phone", string.IsNullOrEmpty(purchaseOrder.Phone) ? "" : purchaseOrder.Phone));
            sqParameters.Add(new SqlParameter("@VendorAddress1", string.IsNullOrEmpty(purchaseOrder.VendorAddress1) ? "" : purchaseOrder.VendorAddress1));
            sqParameters.Add(new SqlParameter("@VendorAddress2", string.IsNullOrEmpty(purchaseOrder.VendorAddress2) ? "" : purchaseOrder.VendorAddress2));
            sqParameters.Add(new SqlParameter("@VendorCity", string.IsNullOrEmpty(purchaseOrder.VendorCity) ? "" : purchaseOrder.VendorCity));
            sqParameters.Add(new SqlParameter("@VendorState", string.IsNullOrEmpty(purchaseOrder.VendorState) ? "" : purchaseOrder.VendorState));
            sqParameters.Add(new SqlParameter("@VendorCountry", string.IsNullOrEmpty(purchaseOrder.VendorCountry) ? "" : purchaseOrder.VendorCountry));
            sqParameters.Add(new SqlParameter("@VendorPostalCode", string.IsNullOrEmpty(purchaseOrder.VendorPostalCode) ? "" : purchaseOrder.VendorPostalCode));
            sqParameters.Add(new SqlParameter("@ShipToAddress1", string.IsNullOrEmpty(purchaseOrder.ShipToAddress1) ? "" : purchaseOrder.ShipToAddress1));
            sqParameters.Add(new SqlParameter("@ShipToAddress2", string.IsNullOrEmpty(purchaseOrder.ShipToAddress2) ? "" : purchaseOrder.ShipToAddress2));
            sqParameters.Add(new SqlParameter("@ShipToCity", string.IsNullOrEmpty(purchaseOrder.ShipToCity) ? "" : purchaseOrder.ShipToCity));
            sqParameters.Add(new SqlParameter("@ShipToState", string.IsNullOrEmpty(purchaseOrder.ShipToState) ? "" : purchaseOrder.ShipToState));
            sqParameters.Add(new SqlParameter("@ShipToCountry", string.IsNullOrEmpty(purchaseOrder.ShipToCountry) ? "" : purchaseOrder.ShipToCountry));
            sqParameters.Add(new SqlParameter("@ShipToPostalCode", string.IsNullOrEmpty(purchaseOrder.ShipToPostalCode) ? "" : purchaseOrder.ShipToPostalCode));
            sqParameters.Add(new SqlParameter("@ShipToAddressRemarks", string.IsNullOrEmpty(purchaseOrder.ShipToAddressRemarks) ? "" : purchaseOrder.ShipToAddressRemarks));
            if (purchaseOrder.RequestShipDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@RequestShipDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@RequestShipDate", purchaseOrder.RequestShipDate));
            }

            //sqParameters.Add(new SqlParameter("@OrderRemarks", string.IsNullOrEmpty(purchaseOrder.OrderRemarks) ? "" : purchaseOrder.OrderRemarks));
            sqParameters.Add(new SqlParameter("@OrderTotal", purchaseOrder.OrderTotal));
            //sqParameters.Add(new SqlParameter("@LastModUserId", userId));

            if (purchaseOrder.CancelledDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", purchaseOrder.CancelledDate));
            }



            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdatePurchaseOrder(PurchaseOrder purchaseOrder, string userId)
        {
            string query = @"  UPDATE dbo.PurchaseOrder
                    SET OrderStatus = @OrderStatus
                    ,OrderNumber = @OrderNumber
                    ,OrderDate = @OrderDate
                    ,VendorId = @VendorId
                    ,ContactName = @ContactName@
                    ,Phone = @Phone
                    ,VendorAddress1 = @VendorAddress1 
                    ,VendorAddress2 = @VendorAddress2 
                    ,VendorCity = @VendorCity 
                    ,VendorState = @VendorState
                    ,VendorCountry = @VendorCountry
                    ,VendorPostalCode = @VendorPostalCode
                    ,ShipToAddress1 = @ShipToAddress1
                    ,ShipToAddress2 = @ShipToAddress2
                    ,ShipToCity = @ShipToCity 
                    ,ShipToState = @ShipToState
                    ,ShipToCountry = @ShipToCountry
                    ,ShipToPostalCode = @ShipToPostalCode
                    ,ShipToAddressRemarks = @ShipToAddressRemarks
                    ,RequestShipDate = @RequestShipDate
                    ,OrderTotal = @OrderTotal 
                    ,LastModUserId = @LastModUserId
                    ,OrderRemarks = @OrderRemarks
                    ,ReceiveRemarks = @ReceiveRemarks 
                    ,CancelledDate = @CancelledDate
                    ,CreatedBy = @CreatedBy
                    ,CreatedDate = @CreatedDate
                    ,LastupdatedBy = @LastupdatedBy
                    ,LastupdatedDate = @LastupdatedDate
                    WHERE PurchaseOrderId =@PurchaseOrderId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@PurchaseOrderId", purchaseOrder.PurchaseOrderId));
            sqParameters.Add(new SqlParameter("@OrderStatus", string.IsNullOrEmpty(purchaseOrder.OrderStatus) ? "" : purchaseOrder.OrderStatus));
            sqParameters.Add(new SqlParameter("@OrderNumber", string.IsNullOrEmpty(purchaseOrder.OrderNumber) ? "" : purchaseOrder.OrderNumber));
            if (purchaseOrder.OrderDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@OrderDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@OrderDate", purchaseOrder.OrderDate));
            }

            if (purchaseOrder.VendorId == -1)
            {
                sqParameters.Add(new SqlParameter("@VendorId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@VendorId", purchaseOrder.VendorId));
            }

            //if (purchaseOrder.ReceivedDate.Equals(DateTime.MinValue))
            //{
            //    sqParameters.Add(new SqlParameter("@ReceivedDate", DBNull.Value));
            //}
            //else
            //{
            //    sqParameters.Add(new SqlParameter("@ReceivedDate", purchaseOrder.ReceivedDate));
            //}
            sqParameters.Add(new SqlParameter("@ContactName", string.IsNullOrEmpty(purchaseOrder.ContactName) ? "" : purchaseOrder.ContactName));
            sqParameters.Add(new SqlParameter("@Phone", string.IsNullOrEmpty(purchaseOrder.Phone) ? "" : purchaseOrder.Phone));
            sqParameters.Add(new SqlParameter("@VendorAddress1", string.IsNullOrEmpty(purchaseOrder.VendorAddress1) ? "" : purchaseOrder.VendorAddress1));
            sqParameters.Add(new SqlParameter("@VendorAddress2", string.IsNullOrEmpty(purchaseOrder.VendorAddress2) ? "" : purchaseOrder.VendorAddress2));
            sqParameters.Add(new SqlParameter("@VendorCity", string.IsNullOrEmpty(purchaseOrder.VendorCity) ? "" : purchaseOrder.VendorCity));
            sqParameters.Add(new SqlParameter("@VendorState", string.IsNullOrEmpty(purchaseOrder.VendorState) ? "" : purchaseOrder.VendorState));
            sqParameters.Add(new SqlParameter("@VendorCountry", string.IsNullOrEmpty(purchaseOrder.VendorCountry) ? "" : purchaseOrder.VendorCountry));
            sqParameters.Add(new SqlParameter("@VendorPostalCode", string.IsNullOrEmpty(purchaseOrder.VendorPostalCode) ? "" : purchaseOrder.VendorPostalCode));
            sqParameters.Add(new SqlParameter("@ShipToAddress1", string.IsNullOrEmpty(purchaseOrder.ShipToAddress1) ? "" : purchaseOrder.ShipToAddress1));
            sqParameters.Add(new SqlParameter("@ShipToAddress2", string.IsNullOrEmpty(purchaseOrder.ShipToAddress2) ? "" : purchaseOrder.ShipToAddress2));
            sqParameters.Add(new SqlParameter("@ShipToCity", string.IsNullOrEmpty(purchaseOrder.ShipToCity) ? "" : purchaseOrder.ShipToCity));
            sqParameters.Add(new SqlParameter("@ShipToState", string.IsNullOrEmpty(purchaseOrder.ShipToState) ? "" : purchaseOrder.ShipToState));
            sqParameters.Add(new SqlParameter("@ShipToCountry", string.IsNullOrEmpty(purchaseOrder.ShipToCountry) ? "" : purchaseOrder.ShipToCountry));
            sqParameters.Add(new SqlParameter("@ShipToPostalCode", string.IsNullOrEmpty(purchaseOrder.ShipToPostalCode) ? "" : purchaseOrder.ShipToPostalCode));
            sqParameters.Add(new SqlParameter("@ShipToAddressRemarks", string.IsNullOrEmpty(purchaseOrder.ShipToAddressRemarks) ? "" : purchaseOrder.ShipToAddressRemarks));
            if (purchaseOrder.RequestShipDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@RequestShipDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@RequestShipDate", purchaseOrder.RequestShipDate));
            }

            //sqParameters.Add(new SqlParameter("@OrderRemarks", string.IsNullOrEmpty(purchaseOrder.OrderRemarks) ? "" : purchaseOrder.OrderRemarks));
            sqParameters.Add(new SqlParameter("@OrderTotal", purchaseOrder.OrderTotal));
            //sqParameters.Add(new SqlParameter("@LastModUserId", userId));

            if (purchaseOrder.CancelledDate.Equals(DateTime.MinValue))
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", purchaseOrder.CancelledDate));
            }

            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        public List<PurchaseOrder> GetPurchaseOrderList(List<KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from PurchaseOrder";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<PurchaseOrder.SearchByPurchaseOrderParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(Vendor.SearchByVendorParameters.IS_ACTIVE))
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
                List<PurchaseOrder> purchaseOrderList = new List<PurchaseOrder>();
                foreach (DataRow row in data.Rows)
                {
                    PurchaseOrder purchaseOrder = GetPurchaseOrder(row);
                    purchaseOrderList.Add(purchaseOrder);
                }
                return purchaseOrderList;
            }
            else
            {
                return null;
            }
        }


        private PurchaseOrder GetPurchaseOrder(DataRow dr)
        {

          

            PurchaseOrder vendor = new PurchaseOrder(
                                Convert.ToInt32(dr["PurchaseOrderId"]),
                                            dr["OrderStatus"].ToString(),
                                            dr["OrderNumber"].ToString(),
                                            dr["OrderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["OrderDate"]),
                                            dr["VendorId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["VendorId"]),
                                            dr["ContactName"].ToString(),
                                            dr["Phone"].ToString(),
                                            dr["VendorAddress1"].ToString(),
                                            dr["VendorAddress2"].ToString(),
                                            dr["VendorCity"].ToString(),
                                            dr["VendorState"].ToString(),
                                            dr["VendorCountry"].ToString(),
                                            dr["VendorPostalCode"].ToString(),
                                            dr["ShipToAddress1"].ToString(),
                                            dr["ShipToAddress2"].ToString(),
                                            dr["ShipToCity"].ToString(),
                                            dr["ShipToState"].ToString(),
                                            dr["ShipToCountry"].ToString(),
                                            dr["ShipToPostalCode"].ToString(),
                                            dr["ShipToAddressRemarks"].ToString(),
                                            dr["RequestShipDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["RequestShipDate"]),
                                            dr["OrderTotal"] == DBNull.Value ? 0 : Convert.ToDouble(dr["OrderTotal"]),
                                            //  dr["ReceivedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ReceivedDate"]),
                                            dr["ReceiveRemarks"].ToString(),
                                            dr["CancelledDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CancelledDate"]),
                                             dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["isActive"]),
                                            dr["CreatedBy"].ToString(),
                                            dr["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]),
                                            dr["LastupdatedBy"].ToString(),
                                            dr["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastupdatedDate"])
                                            );

            return vendor;
        }
    }
}
