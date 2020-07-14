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
   public class PurchaseOrderLineData
    {
        private DBConnection conn;
        private static readonly Dictionary<PurchaseOrderLine.SearchByPurchaseOrderLineParameters, string> DBSearchParameters = new Dictionary<PurchaseOrderLine.SearchByPurchaseOrderLineParameters, string>
               {
                    {PurchaseOrderLine.SearchByPurchaseOrderLineParameters.IS_ACTIVE, "IsActive"},


        };
        public PurchaseOrderLineData()
        {
            conn = new DBConnection();
        }


        public int InsertOrUpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine, string userid)
        {
            try
            {
                if (purchaseOrderLine.PurchaseOrderLineId <= 0)
                {
                    int id = InsertPurchaseOrderLine(purchaseOrderLine, userid);
                    return id;
                }
                else
                {
                    int id = UpdatePurchaseOrderLine(purchaseOrderLine, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertPurchaseOrderLine(PurchaseOrderLine purchaseOrderLine, string userId)
        {
            string query = @"INSERT INTO  dbo . PurchaseOrderLine 
                           (
		                    PurchaseOrderId 
                           , ItemCode 
                           , Description 
                           , Quantity 
                           , UnitPrice 
                           , SubTotal 
                           , TaxAmount 
                           , DiscountPercentage 
                           , RequiredByDate 
                           , ProductId 
                           , IsActive 
                           , CancelledDate 
                           , CreatedBy 
                           , CreatedDate 
                           )
                     VALUES
                           (
		   
		                    @PurchaseOrderId 
                           ,@ItemCode 
                           ,@Description 
                           ,@Quantity 
                           ,@UnitPrice 
                           ,@SubTotal 
                           ,@TaxAmount 
                           ,@DiscountPercentage 
                           ,@RequiredByDate 
                           ,@ProductId 
                           ,@IsActive 
                           ,@CancelledDate 
                           ,@CreatedBy 
                           ,  getdate()  
                          
		                   )SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (purchaseOrderLine.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", purchaseOrderLine.PurchaseOrderId));
            }
            
            if (string.IsNullOrEmpty(purchaseOrderLine.ItemCode))
            {
                sqParameters.Add(new SqlParameter("@ItemCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ItemCode", purchaseOrderLine.ItemCode));
            }
            if (string.IsNullOrEmpty(purchaseOrderLine.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", purchaseOrderLine.Description));
            }
            sqParameters.Add(new SqlParameter("@Quantity", purchaseOrderLine.Quantity));
            sqParameters.Add(new SqlParameter("@UnitPrice", purchaseOrderLine.UnitPrice));
            sqParameters.Add(new SqlParameter("@TaxAmount", purchaseOrderLine.TaxAmount));
            sqParameters.Add(new SqlParameter("@SubTotal", purchaseOrderLine.SubTotal));
            sqParameters.Add(new SqlParameter("@DiscountPercentage", purchaseOrderLine.DiscountPercentage));
            if (purchaseOrderLine.RequiredByDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@RequiredByDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@RequiredByDate", purchaseOrderLine.RequiredByDate));
            }
           

            if (purchaseOrderLine.ProductId == -1)
            {
                sqParameters.Add(new SqlParameter("@productId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@productId", purchaseOrderLine.ProductId));
            }
            sqParameters.Add(new SqlParameter("@isActive",  purchaseOrderLine.IsActive)  );

            if (purchaseOrderLine.CancelledDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", purchaseOrderLine.CancelledDate));
            }

            sqParameters.Add(new SqlParameter("@CreatedBy", userId));



           

           

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdatePurchaseOrderLine(PurchaseOrderLine purchaseOrderLine, string userId)
        {
            string query = @" UPDATE dbo.PurchaseOrderLine
                               SET PurchaseOrderId = @PurchaseOrderId 
                                  ,ItemCode = @ItemCode 
                                  ,Description = @Description 
                                  ,Quantity = @Quantity 
                                  ,UnitPrice = @UnitPrice 
                                  ,SubTotal = @SubTotal 
                                  ,TaxAmount = @TaxAmount 
                                  ,DiscountPercentage = @DiscountPercentage 
                                  ,RequiredByDate = @RequiredByDate 
                                  ,ProductId = @ProductId 
                                  ,IsActive = @IsActive 
                                  ,CancelledDate = @CancelledDate 
                                  ,LastupdatedBy = @LastupdatedBy 
                                  ,LastupdatedDate =getdate()
                             WHERE PurchaseOrderLineId =@PurchaseOrderLineId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@PurchaseOrderLineId", purchaseOrderLine.PurchaseOrderLineId));
            if (purchaseOrderLine.PurchaseOrderId == -1)
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@PurchaseOrderId", purchaseOrderLine.PurchaseOrderId));
            }

            if (string.IsNullOrEmpty(purchaseOrderLine.ItemCode))
            {
                sqParameters.Add(new SqlParameter("@ItemCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@ItemCode", purchaseOrderLine.ItemCode));
            }
            if (string.IsNullOrEmpty(purchaseOrderLine.Description))
            {
                sqParameters.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Description", purchaseOrderLine.Description));
            }
            sqParameters.Add(new SqlParameter("@Quantity", purchaseOrderLine.Quantity));
            sqParameters.Add(new SqlParameter("@UnitPrice", purchaseOrderLine.UnitPrice));
            sqParameters.Add(new SqlParameter("@TaxAmount", purchaseOrderLine.TaxAmount));
            sqParameters.Add(new SqlParameter("@SubTotal", purchaseOrderLine.SubTotal));
            sqParameters.Add(new SqlParameter("@DiscountPercentage", purchaseOrderLine.DiscountPercentage));
            if (purchaseOrderLine.RequiredByDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@RequiredByDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@RequiredByDate", purchaseOrderLine.RequiredByDate));
            }


            if (purchaseOrderLine.ProductId == -1)
            {
                sqParameters.Add(new SqlParameter("@productId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@productId", purchaseOrderLine.ProductId));
            }
            sqParameters.Add(new SqlParameter("@isActive", purchaseOrderLine.IsActive));

            if (purchaseOrderLine.CancelledDate == DateTime.MinValue)
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CancelledDate", purchaseOrderLine.CancelledDate));
            }

            


            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        public List<PurchaseOrderLine> GetPurchaseOrderLineList(List<KeyValuePair<PurchaseOrderLine.SearchByPurchaseOrderLineParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from PurchaseOrder_Line";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<PurchaseOrderLine.SearchByPurchaseOrderLineParameters, string> searchParameter in searchParameters)
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
                List<PurchaseOrderLine> purchaseOrderList = new List<PurchaseOrderLine>();
                foreach (DataRow row in data.Rows)
                {
                    PurchaseOrderLine purchaseOrderLine = GetPurchaseOrder(row);
                    purchaseOrderList.Add(purchaseOrderLine);
                }
                return purchaseOrderList;
            }
            else
            {
                return null;
            }
        }


        private PurchaseOrderLine GetPurchaseOrder(DataRow dr)
        {


            PurchaseOrderLine purchaseOrderLine = new PurchaseOrderLine(
                                            Convert.ToInt32(dr["PurchaseOrderLineId"]),
                                            Convert.ToInt32(dr["PurchaseOrderId"]),
                                            dr["ItemCode"].ToString(),
                                            dr["Description"].ToString(),
                                            dr["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Quantity"]),
                                            dr["UnitPrice"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UnitPrice"]),
                                            dr["SubTotal"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SubTotal"]),
                                            dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TaxAmount"]),
                                            dr["DiscountPercentage"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DiscountPercentage"]),
                                            dr["RequiredByDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["RequiredByDate"]),
                                          
                                            dr["ProductId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["ProductId"]),
                                        
                                            dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(  dr["isActive"]),
                                            dr["CancelledDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CancelledDate"]),
                                               dr["CreatedBy"].ToString(),
                                              dr["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["RequiredByDate"]),
                                               dr["LastupdatedBy"].ToString(),
                                              dr["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["LastupdatedDate"])
                                            );

            return purchaseOrderLine;
        }
    }
}

