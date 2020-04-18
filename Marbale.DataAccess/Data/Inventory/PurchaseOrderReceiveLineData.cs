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
    public class PurchaseOrderReceiveLineData
    {
        private DBConnection conn;
        private static readonly Dictionary<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string> DBSearchParameters = new Dictionary<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>
               {
                    {PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters.IS_ACTIVE, "IsActive"},


        };
        public PurchaseOrderReceiveLineData()
        {
            conn = new DBConnection();
        }


        public int InsertOrUpdatePurchaseOrderReceiveLine(PurchaseOrderReceiveLine purchaseOrderReceiveLine, string userid)
        {
            try
            {
                if (purchaseOrderReceiveLine.PurchaseOrderLineId <= 0)
                {
                    int id = InsertPurchaseOrderReceiveLine(purchaseOrderReceiveLine, userid);
                    return id;
                }
                else
                {
                    int id = UpdatePurchaseOrderReceiveLine(purchaseOrderReceiveLine, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertPurchaseOrderReceiveLine(PurchaseOrderReceiveLine purchaseOrderReceiveLine, string userId)
        {
            string query = @"INSERT INTO  dbo . PurchaseOrderReceive_Line 
                                   ( PurchaseOrderId 
                                   , ProductId 
                                   , Description 
                                   , VendorItemCode 
                                   , Quantity 
                                   , LocationId 
                                   , IsReceived 
                                   , PurchaseOrderLineId 
                                   , Price 
                                   , TaxPercentage 
                                   , Amount 
                                   , TaxInclusive 
                                   , TaxId 
                                   , ReceiptId 
                                   , VendorBillNumber 
                                   , ReceivedBy 
                                   , CreatedBy 
                                   , CreatedDate 
                                   )
                             VALUES
                                   (
		                           @PurchaseOrderId 
                                   @ProductId 
                                   @Description 
                                   @VendorItemCode 
                                   @Quantity 
                                   @LocationId 
                                   @IsReceived 
                                   @PurchaseOrderLineId 
                                   @Price 
                                   @TaxPercentage 
                                   @Amount 
                                   @TaxInclusive 
                                   @TaxId 
                                   @ReceiptId 
                                   @VendorBillNumber 
                                   @ReceivedBy 
                                   @CreatedBy 
                                   GETDATE()
		   
		                            )SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (purchaseOrderReceiveLine.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", purchaseOrderReceiveLine.PurchaseOrderId));
            }
            if (purchaseOrderReceiveLine.ProductId == -1)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", purchaseOrderReceiveLine.ProductId));
            }
            if (string.IsNullOrEmpty(purchaseOrderReceiveLine.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", purchaseOrderReceiveLine.Description));
            }
            //if (string.IsNullOrEmpty(purchaseOrderReceiveLine.VendorItemCode))
            //{
            //    sqParameters.Add(new SqlParameter("@VendorItemCode", DBNull.Value));

            //else
            //{
            //        sqParameters.Add(new SqlParameter("@VendorItemCode", purchaseOrderReceiveLine.VendorItemCode));
            //    }

            if (purchaseOrderReceiveLine.Quantity == -1)
            {
                sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Quantity", purchaseOrderReceiveLine.Quantity));
            }
            if (purchaseOrderReceiveLine.LocationId == -1)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", purchaseOrderReceiveLine.LocationId));
            }
            sqParameters.Add(new SqlParameter("@IsReceived", purchaseOrderReceiveLine.IsReceived));
            if (purchaseOrderReceiveLine.PurchaseOrderLineId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderLineId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderLineId", purchaseOrderReceiveLine.PurchaseOrderLineId));
            }

            sqParameters.Add(new SqlParameter("@Price", purchaseOrderReceiveLine.Price));
            if (purchaseOrderReceiveLine.TaxPercentage == -1)
            {
                sqParameters.Add(new SqlParameter("@TaxPercentage", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxPercentage", purchaseOrderReceiveLine.TaxPercentage));
            }
            sqParameters.Add(new SqlParameter("@Amount", purchaseOrderReceiveLine.Amount));
            sqParameters.Add(new SqlParameter("@TaxInclusive", purchaseOrderReceiveLine.TaxInclusive));
            if (purchaseOrderReceiveLine.TaxId == -1)
            {
                sqParameters.Add(new SqlParameter("@TaxId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxId", purchaseOrderReceiveLine.TaxId));
            }

            sqParameters.Add(new SqlParameter("@TaxId", purchaseOrderReceiveLine.ReceiptId));
            sqParameters.Add(new SqlParameter("@VendorBillNumber", purchaseOrderReceiveLine.VendorBillNumber));
            sqParameters.Add(new SqlParameter("@ReceivedBy", purchaseOrderReceiveLine.ReceivedBy));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }


        public int UpdatePurchaseOrderReceiveLine(PurchaseOrderReceiveLine purchaseOrderReceiveLine, string userId)
        {
            string query = @" UPDATE dbo.PurchaseOrderReceive_Line
                                   SET PurchaseOrderId = @PurchaseOrderId 
                                      ,ProductId = @ProductId 
                                      ,Description = @Description 
                                      ,VendorItemCode = @VendorItemCode 
                                      ,Quantity = @Quantity 
                                      ,LocationId = @LocationId 
                                      ,IsReceived = @IsReceived 
                                      ,PurchaseOrderLineId = @PurchaseOrderLineId 
                                      ,Price = @Price 
                                      ,TaxPercentage = @TaxPercentage 
                                      ,Amount = @Amount 
                                      ,TaxInclusive = @TaxInclusive 
                                      ,TaxId = @TaxId 
                                      ,ReceiptId = @ReceiptId 
                                      ,VendorBillNumber = @VendorBillNumber 
                                      ,ReceivedBy = @ReceivedBy 
                                      ,CreatedBy = @CreatedBy 
                                      ,CreatedDate = @CreatedDate 
                                      ,LastupdatedBy = @LastupdatedBy 
                                      ,LastupdatedDate = @LastupdatedDate 
                                 WHERE PurchaseOrderReceiveLineId=@PurchaseOrderReceiveLineId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@PurchaseOrderReceiveLineId", purchaseOrderReceiveLine.PurchaseOrderReceiveLineId));
            if (purchaseOrderReceiveLine.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", purchaseOrderReceiveLine.PurchaseOrderId));
            }
            if (purchaseOrderReceiveLine.ProductId == -1)
            {
                sqParameters.Add(new SqlParameter("@ProductId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ProductId", purchaseOrderReceiveLine.ProductId));
            }
            if (string.IsNullOrEmpty(purchaseOrderReceiveLine.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", purchaseOrderReceiveLine.Description));
            }
            if (string.IsNullOrEmpty(purchaseOrderReceiveLine.VendorItemCode))
                //{
                //    sqParameters.Add(new SqlParameter("@VendorItemCode", DBNull.Value));

                //else
                //{
                //        sqParameters.Add(new SqlParameter("@VendorItemCode", purchaseOrderReceiveLine.VendorItemCode));
                //    }

                if (purchaseOrderReceiveLine.Quantity == -1)
                {
                    sqParameters.Add(new SqlParameter("@Quantity", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@Quantity", purchaseOrderReceiveLine.Quantity));
                }
            if (purchaseOrderReceiveLine.LocationId == -1)
            {
                sqParameters.Add(new SqlParameter("@LocationId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationId", purchaseOrderReceiveLine.LocationId));
            }
            sqParameters.Add(new SqlParameter("@IsReceived", purchaseOrderReceiveLine.IsReceived));
            if (purchaseOrderReceiveLine.PurchaseOrderLineId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderLineId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderLineId", purchaseOrderReceiveLine.PurchaseOrderLineId));
            }

            sqParameters.Add(new SqlParameter("@Price", purchaseOrderReceiveLine.Price));
            if (purchaseOrderReceiveLine.TaxPercentage == -1)
            {
                sqParameters.Add(new SqlParameter("@TaxPercentage", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxPercentage", purchaseOrderReceiveLine.TaxPercentage));
            }
            sqParameters.Add(new SqlParameter("@Amount", purchaseOrderReceiveLine.Amount));
            sqParameters.Add(new SqlParameter("@TaxInclusive", purchaseOrderReceiveLine.TaxInclusive));
            if (purchaseOrderReceiveLine.TaxId == -1)
            {
                sqParameters.Add(new SqlParameter("@TaxId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@TaxId", purchaseOrderReceiveLine.TaxId));
            }

            sqParameters.Add(new SqlParameter("@TaxId", purchaseOrderReceiveLine.ReceiptId));
            sqParameters.Add(new SqlParameter("@VendorBillNumber", purchaseOrderReceiveLine.VendorBillNumber));
            sqParameters.Add(new SqlParameter("@ReceivedBy", purchaseOrderReceiveLine.ReceivedBy));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        public List<PurchaseOrderReceiveLine> GetPurchaseOrderReceiveLineList(List<KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from PurchaseOrdPurchaseOrderReceive_Lineer_Line";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string> searchParameter in searchParameters)
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
                List<PurchaseOrderReceiveLine> purchaseOrderList = new List<PurchaseOrderReceiveLine>();
                foreach (DataRow row in data.Rows)
                {
                    PurchaseOrderReceiveLine purchaseOrderReceiveLine = GetPurchaseOrderReceiveLine(row);
                    purchaseOrderList.Add(purchaseOrderReceiveLine);
                }
                return purchaseOrderList;
            }
            else
            {
                return null;
            }
        }


        private PurchaseOrderReceiveLine GetPurchaseOrderReceiveLine(DataRow dr)
        {
            //int purchaseOrderReceiveLineId,int purchaseOrderId,int productId,string description,string vendorItemCode,double quantity,int locationId,bool isReceived,int purchaseOrderLineId,double price,double taxPercentage,double amount,bool taxInclusive,int taxId,int receiptId,string vendorBillNumber,string receivedBy,string createdBy,DateTime createdDate,string lastupdatedBy,DateTime lastupdatedDate

            PurchaseOrderReceiveLine purchaseOrderReceiveLine = new PurchaseOrderReceiveLine(
                                                Convert.ToInt32(dr["PurchaseOrderReceiveLineId"]),
                                                Convert.ToInt32(dr["PurchaseOrderId"]),
                                                  Convert.ToInt32(dr["ProductId"]),
                                                dr["Description"].ToString(),
                                                dr["VendorItemCode"].ToString(),
                                                dr["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Quantity"]),
                                                dr["LocationId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LocationId"]),
                                                dr["IsReceived"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsReceived"]),
                                                dr["PurchaseOrderLineId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PurchaseOrderLineId"]),
                                                dr["Price"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Price"]),
                                                dr["TaxPercentage"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TaxPercentage"]),
                                                dr["Amount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Amount"]),
                                                dr["TaxInclusive"] == DBNull.Value ? false : Convert.ToBoolean(dr["TaxInclusive"]),
                                                dr["TaxId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["TaxId"]),
                                                dr["ReceiptId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["ReceiptId"]),
                                                dr["VendorBillNumber"].ToString(),
                                                dr["ReceivedBy"].ToString(),
                                                 dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["isActive"]),
                                                dr["CreatedBy"].ToString(),
                                                  dr["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreatedDate"]),
                                                   dr["LastUpdatedBy"].ToString(),
                                                  dr["LastUpdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastUpdatedDate"])
                                                );

            return purchaseOrderReceiveLine;
        }

    }
}
