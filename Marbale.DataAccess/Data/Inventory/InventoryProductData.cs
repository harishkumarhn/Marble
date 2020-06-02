using Marbale.BusinessObject;
using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data.Inventory
{
    public class InventoryProductData
    {
        private DBConnection conn;
        private static readonly Dictionary<InventoryProduct.SearchByProductParameters, string> DBSearchParameters = new Dictionary<InventoryProduct.SearchByProductParameters, string>
               {
            {InventoryProduct.SearchByProductParameters.IS_ACTIVE, "IsActive"},
            {InventoryProduct.SearchByProductParameters.PRODUCT_NAME, "ProductName"},
            {InventoryProduct.SearchByProductParameters.PRODUCT_ID, "ProductId"},
            {InventoryProduct.SearchByProductParameters.PRODUCT_CODE, "code"},
            {InventoryProduct.SearchByProductParameters.DESCRIPTION, "Description"},
            {InventoryProduct.SearchByProductParameters.DEFAULT_LOCATION, "DefaultLocationId"},

    };
        public InventoryProductData()
        {
            conn = new DBConnection();
        }

        public DataTable GetLocationType()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetLocationType");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateInventoryProduct(InventoryProduct inventoryProduct, string userid)
        {
            try
            {
                if (inventoryProduct.ProductId <= 0)
                {
                    int id = InsertInventoryProduct(inventoryProduct, userid);
                    return id;
                }
                else
                {
                    int id = UpdateInventoryProduct(inventoryProduct, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertInventoryProduct(InventoryProduct inventoryProduct, string userId)
        {
            string query = @"INSERT INTO dbo.InventoryProduct
                               (Code
                               ,ProductName
                               ,Description
                               ,Remarks
                               ,CategoryId
                               ,UomId
                               ,DefaultVendorId
                               ,DefaultLocationId
                               ,TaxId
                               ,OutboundLocationId
                               ,ReorderPoint
                               ,ReorderQuantity
                               ,PriceInTickets
                               ,MasterPackQty
                               ,TaxInclusiveCost
                               ,IsPurchaseable
                               ,IsSellable
                                
                               ,IsActive
                               ,IsRedeemable
                                
                               ,InnerPackQty
                               ,LowerLimitCost
                               ,CostVariancePercentage
                               ,SalePrice
                               ,Cost
                               ,UpperLimitCost
                               ,LastPurchasePrice
                               ,TurnInPriceInTickets
                                
                               ,IssuingApproach
                                
                                
                               ,CreatedBy
                               ,CreatedDate
                               )
                         VALUES
                               (
		                       @Code
                               ,@ProductName
                               ,@Description
                               ,@Remarks
                               ,@CategoryId
                               ,@UomId
                               ,@DefaultVendorId
                               ,@DefaultLocationId
                               ,@TaxId
                               ,@OutboundLocationId
                               ,@ReorderPoint
                               ,@ReorderQuantity
                               ,@PriceInTickets
                               ,@MasterPackQty
                               ,@TaxInclusiveCost
                               ,@IsPurchaseable
                               ,@IsSellable
                                
                               ,@IsActive
                               ,@IsRedeemable
                                
                               ,@InnerPackQty
                               ,@LowerLimitCost
                               ,@CostVariancePercentage
                               ,@SalePrice
                               ,@Cost
                               ,@UpperLimitCost
                               ,@LastPurchasePrice
                               ,@TurnInPriceInTickets
                           
                               ,@IssuingApproach
                                
                                
                               ,@CreatedBy
                               ,getdate()
                                )SELECT CAST(scope_identity() AS int)";


            List<SqlParameter> param = new List<SqlParameter>();
            if (string.IsNullOrEmpty(inventoryProduct.Code))
            {
                param.Add(new SqlParameter("@Code", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Code", inventoryProduct.Code));
            }
            if (string.IsNullOrEmpty(inventoryProduct.ProductName))
            {
                param.Add(new SqlParameter("@ProductName", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@ProductName", inventoryProduct.ProductName));
            }

            if (string.IsNullOrEmpty(inventoryProduct.Description))
            {
                param.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Description", inventoryProduct.Description));
            }
            if (string.IsNullOrEmpty(inventoryProduct.Remarks))
            {
                param.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Remarks", inventoryProduct.Remarks));
            }

            if (string.IsNullOrEmpty(inventoryProduct.BarCode))
            {
                param.Add(new SqlParameter("@BarCode", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@BarCode", inventoryProduct.BarCode));
            }
            if (inventoryProduct.CategoryId == -1)
            {
                param.Add(new SqlParameter("@CategoryId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@CategoryId", inventoryProduct.CategoryId));
            }
            if (inventoryProduct.UomId == -1)
            {
                param.Add(new SqlParameter("@UomId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@UomId", inventoryProduct.UomId));
            }
            if (inventoryProduct.DefaultVendorId == -1)
            {
                param.Add(new SqlParameter("@DefaultVendorId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@DefaultVendorId", inventoryProduct.DefaultVendorId));
            }
            if (inventoryProduct.DefaultLocationId == -1)
            {
                param.Add(new SqlParameter("@DefaultLocationId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@DefaultLocationId", inventoryProduct.DefaultLocationId));
            }

            if (inventoryProduct.TaxId == -1)
            {
                param.Add(new SqlParameter("@taxId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@taxId", inventoryProduct.TaxId));
            }

            if (inventoryProduct.OutboundLocationId == -1)
            {
                param.Add(new SqlParameter("@outboundLocationId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@outboundLocationId", inventoryProduct.OutboundLocationId));
            }
            param.Add(new SqlParameter("@ReorderPoint", inventoryProduct.ReorderPoint));
            param.Add(new SqlParameter("@ReorderQuantity", inventoryProduct.ReorderQuantity));
            param.Add(new SqlParameter("@PriceInTickets", inventoryProduct.PriceInTickets));

            param.Add(new SqlParameter("@MasterPackQty", inventoryProduct.MasterPackQty));

            param.Add(new SqlParameter("@TaxInclusiveCost", Convert.ToBoolean(inventoryProduct.TaxInclusiveCost)));
            param.Add(new SqlParameter("@IsPurchaseable", Convert.ToBoolean(inventoryProduct.IsPurchaseable)));
            param.Add(new SqlParameter("@IsSellable", Convert.ToBoolean(inventoryProduct.IsSellable)));

            //if (inventoryProduct.ExpiryType == "E" || inventoryProduct.ExpiryType == "D")
            //    param.Add(new SqlParameter("@LotControlled", true));
            //else if (inventoryProduct.LotControlled == false)
            //    param.Add(new SqlParameter("@LotControlled", false));
            //else
            //{
            //    param.Add(new SqlParameter("@LotControlled", inventoryProduct.LotControlled));
            //}
            param.Add(new SqlParameter("@isActive", Convert.ToBoolean(inventoryProduct.IsActive)));
            param.Add(new SqlParameter("@IsRedeemable", Convert.ToBoolean(inventoryProduct.IsRedeemable)));

            //if (inventoryProduct.MarketListItem)
            //{
            //    param.Add(new SqlParameter("@MarketListItem", inventoryProduct.MarketListItem));
            //}
            //else
            //{
            //    param.Add(new SqlParameter("@MarketListItem", false));
            //}
            param.Add(new SqlParameter("@InnerPackQty", inventoryProduct.InnerPackQty));

            param.Add(new SqlParameter("@LowerLimitCost", inventoryProduct.LowerLimitCost));
            param.Add(new SqlParameter("@CostVariancePercentage", inventoryProduct.CostVariancePercentage));
            param.Add(new SqlParameter("@SalePrice", inventoryProduct.SalePrice));
            param.Add(new SqlParameter("@Cost", inventoryProduct.Cost));
            param.Add(new SqlParameter("@UpperLimitCost", inventoryProduct.UpperLimitCost));

            if (inventoryProduct.LastPurchasePrice == 0)
            {
                param.Add(new SqlParameter("@LastPurchasePrice", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@LastPurchasePrice", inventoryProduct.LastPurchasePrice));
            }

            param.Add(new SqlParameter("@TurnInPriceInTickets", inventoryProduct.TurnInPriceInTickets));

            //param.Add(new SqlParameter("@ExpiryType", string.IsNullOrEmpty(inventoryProduct.ExpiryType) ? "N" : inventoryProduct.ExpiryType));
            param.Add(new SqlParameter("@IssuingApproach", string.IsNullOrEmpty(inventoryProduct.IssuingApproach) ? "None" : inventoryProduct.IssuingApproach));
            //param.Add(new SqlParameter("@ExpiryDays", inventoryProduct.ExpiryDays));
            //double verifyDouble = 0;
            //if ((Double.TryParse(inventoryProduct.ItemMarkupPercent.ToString(), out verifyDouble) == false) || inventoryProduct.ItemMarkupPercent.ToString() == "NaN" || inventoryProduct.ItemMarkupPercent.ToString() == "")
            //{
            //    param.Add(new SqlParameter("@ItemMarkupPercent", DBNull.Value));
            //}
            //else
            //{
            //    param.Add(new SqlParameter("@ItemMarkupPercent", inventoryProduct.ItemMarkupPercent));
            //}
            param.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, param.ToArray());
            return idOfRowInserted;
        }

        public int UpdateInventoryProduct(InventoryProduct inventoryProduct, string userId)
        {
            string query = @"UPDATE dbo.InventoryProduct
                            SET Code = @Code
                            ,ProductName = @ProductName 
                            ,Description = @Description
                            ,Remarks = @Remarks
                            ,BarCode = @BarCode
                            ,CategoryId = @CategoryId
                            ,UomId = @UomId
                            ,DefaultVendorId = @DefaultVendorId
                            ,DefaultLocationId = @DefaultLocationId 
                            ,TaxId = @TaxId 
                            ,OutboundLocationId = @OutboundLocationId
                            ,ReorderPoint = @ReorderPoint 
                            ,ReorderQuantity = @ReorderQuantity 
                            ,PriceInTickets = @PriceInTickets
                            ,MasterPackQty = @MasterPackQty
                            ,TaxInclusiveCost = @TaxInclusiveCost
                            ,IsPurchaseable = @IsPurchaseable
                            ,IsSellable = @IsSellable
                            --,LotControlled = @LotControlled 
                            ,IsActive = @IsActive
                            ,IsRedeemable = @IsRedeemable 
                            ,MarketListItem = @MarketListItem
                            ,InnerPackQty = @InnerPackQty
                            ,LowerLimitCost = @LowerLimitCost
                            ,CostVariancePercentage = @CostVariancePercentage
                            ,SalePrice = @SalePrice
                            ,Cost = @Cost
                            ,UpperLimitCost = @UpperLimitCost
                            ,LastPurchasePrice = @LastPurchasePrice 
                            ,TurnInPriceInTickets = @TurnInPriceInTickets 
                            --,ExpiryType = @ExpiryType 
                            ,IssuingApproach = @IssuingApproach
                            ,ExpiryDays = @ExpiryDays
                            ,ItemMarkupPercent = @ItemMarkupPercent 
                            ,LastUpdatedBy = @LastUpdatedBy  
                            ,LastUpdatedDate = getdate()
                            WHERE ProductId =@ProductId
                 ";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductId", inventoryProduct.ProductId));
            if (string.IsNullOrEmpty(inventoryProduct.Code))
            {
                param.Add(new SqlParameter("@Code", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Code", inventoryProduct.Code));
            }
            if (string.IsNullOrEmpty(inventoryProduct.ProductName))
            {
                param.Add(new SqlParameter("@ProductName", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@ProductName", inventoryProduct.ProductName));
            }

            if (string.IsNullOrEmpty(inventoryProduct.Description))
            {
                param.Add(new SqlParameter("@Description", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Description", inventoryProduct.Description));
            }
            if (string.IsNullOrEmpty(inventoryProduct.Remarks))
            {
                param.Add(new SqlParameter("@Remarks", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@Remarks", inventoryProduct.Remarks));
            }
            if (string.IsNullOrEmpty(inventoryProduct.BarCode))
            {
                param.Add(new SqlParameter("@BarCode", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@BarCode", inventoryProduct.BarCode));
            }
            if (inventoryProduct.CategoryId == -1)
            {
                param.Add(new SqlParameter("@CategoryId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@CategoryId", inventoryProduct.CategoryId));
            }
            if (inventoryProduct.UomId == -1)
            {
                param.Add(new SqlParameter("@UomId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@UomId", inventoryProduct.UomId));
            }
            if (inventoryProduct.DefaultVendorId == -1)
            {
                param.Add(new SqlParameter("@DefaultVendorId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@DefaultVendorId", inventoryProduct.DefaultVendorId));
            }
            if (inventoryProduct.DefaultLocationId == -1)
            {
                param.Add(new SqlParameter("@DefaultLocationId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@DefaultLocationId", inventoryProduct.DefaultLocationId));
            }

            if (inventoryProduct.TaxId == -1)
            {
                param.Add(new SqlParameter("@taxId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@taxId", inventoryProduct.TaxId));
            }

            if (inventoryProduct.OutboundLocationId == -1)
            {
                param.Add(new SqlParameter("@outboundLocationId", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@outboundLocationId", inventoryProduct.OutboundLocationId));
            }
            param.Add(new SqlParameter("@ReorderPoint", inventoryProduct.ReorderPoint));
            param.Add(new SqlParameter("@ReorderQuantity", inventoryProduct.ReorderQuantity));
            param.Add(new SqlParameter("@PriceInTickets", inventoryProduct.PriceInTickets));

            param.Add(new SqlParameter("@MasterPackQty", inventoryProduct.MasterPackQty));

            param.Add(new SqlParameter("@TaxInclusiveCost", Convert.ToBoolean(inventoryProduct.TaxInclusiveCost)));
            param.Add(new SqlParameter("@IsPurchaseable", Convert.ToBoolean(inventoryProduct.IsPurchaseable)));
            param.Add(new SqlParameter("@IsSellable", Convert.ToBoolean(inventoryProduct.IsSellable)));

            //if (inventoryProduct.ExpiryType == "E" || inventoryProduct.ExpiryType == "D")
            //    param.Add(new SqlParameter("@LotControlled", true));
            //else if (inventoryProduct.LotControlled == false)
            //    param.Add(new SqlParameter("@LotControlled", false));
            //else
            //{
            //    param.Add(new SqlParameter("@LotControlled", inventoryProduct.LotControlled));
            //}
            param.Add(new SqlParameter("@isActive", Convert.ToBoolean(inventoryProduct.IsActive)));
            param.Add(new SqlParameter("@IsRedeemable", Convert.ToBoolean(inventoryProduct.IsRedeemable)));

            if (inventoryProduct.MarketListItem)
            {
                param.Add(new SqlParameter("@MarketListItem", inventoryProduct.MarketListItem));
            }
            else
            {
                param.Add(new SqlParameter("@MarketListItem", false));
            }
            param.Add(new SqlParameter("@InnerPackQty", inventoryProduct.InnerPackQty));

            param.Add(new SqlParameter("@LowerLimitCost", inventoryProduct.LowerLimitCost));
            param.Add(new SqlParameter("@CostVariancePercentage", inventoryProduct.CostVariancePercentage));
            param.Add(new SqlParameter("@SalePrice", inventoryProduct.SalePrice));
            param.Add(new SqlParameter("@Cost", inventoryProduct.Cost));
            param.Add(new SqlParameter("@UpperLimitCost", inventoryProduct.UpperLimitCost));

            if (inventoryProduct.LastPurchasePrice == 0)
            {
                param.Add(new SqlParameter("@LastPurchasePrice", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@LastPurchasePrice", inventoryProduct.LastPurchasePrice));
            }

            param.Add(new SqlParameter("@TurnInPriceInTickets", inventoryProduct.TurnInPriceInTickets));

            //param.Add(new SqlParameter("@ExpiryType", string.IsNullOrEmpty(inventoryProduct.ExpiryType) ? "N" : inventoryProduct.ExpiryType));
            param.Add(new SqlParameter("@IssuingApproach", string.IsNullOrEmpty(inventoryProduct.IssuingApproach) ? "None" : inventoryProduct.IssuingApproach));
            param.Add(new SqlParameter("@ExpiryDays", inventoryProduct.ExpiryDays));
            double verifyDouble = 0;
            if ((Double.TryParse(inventoryProduct.ItemMarkupPercent.ToString(), out verifyDouble) == false) || inventoryProduct.ItemMarkupPercent.ToString() == "NaN" || inventoryProduct.ItemMarkupPercent.ToString() == "")
            {
                param.Add(new SqlParameter("@ItemMarkupPercent", DBNull.Value));
            }
            else
            {
                param.Add(new SqlParameter("@ItemMarkupPercent", inventoryProduct.ItemMarkupPercent));
            }
            param.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, param.ToArray());
            return rowsUpdated;
        }

        
        private InventoryProduct GetInventoryProduct(DataRow row)
        {
            InventoryProduct product = new InventoryProduct(
                            Convert.ToInt32(row["ProductId"]),
                            row["Code"].ToString(),
                            row["ProductName"].ToString(),
                            row["Description"].ToString(),
                            row["Remarks"].ToString(),
                            row["BarCode"].ToString(),
                            row["CategoryId"] == DBNull.Value ? -1 : Convert.ToInt32(row["CategoryId"]),
                            row["UomId"] == DBNull.Value ? -1 : Convert.ToInt32(row["UomId"]),
                            row["DefaultVendorId"] == DBNull.Value ? -1 : Convert.ToInt32(row["DefaultVendorId"]),
                            row["DefaultLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(row["DefaultLocationId"]),
                            row["TaxId"] == DBNull.Value ? -1 : Convert.ToInt32(row["TaxId"]),
                            row["OutboundLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(row["OutboundLocationId"]),
                            row["ReorderPoint"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ReorderPoint"]),
                            row["ReorderQuantity"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ReorderQuantity"]),
                            row["PriceInTickets"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["PriceInTickets"]),
                            row["MasterPackQty"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["MasterPackQty"]),
                            row["TaxInclusiveCost"] == DBNull.Value ? false : Convert.ToBoolean(row["TaxInclusiveCost"].ToString()),
                            row["IsPurchaseable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsPurchaseable"].ToString()),
                            row["IsSellable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsSellable"]),
                            row["LotControlled"] == DBNull.Value ? false : Convert.ToBoolean(row["LotControlled"]),
                            row["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(row["IsActive"]),
                            row["IsRedeemable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsRedeemable"].ToString()),
                            row["MarketListItem"] == DBNull.Value ? false : Convert.ToBoolean(row["MarketListItem"]),
                            row["InnerPackQty"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["InnerPackQty"]),
                            row["LowerLimitCost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["LowerLimitCost"]),
                            row["CostVariancePercentage"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["CostVariancePercentage"]),
                            row["SalePrice"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["SalePrice"]),
                            row["Cost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["Cost"]),
                            row["UpperLimitCost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["UpperLimitCost"]),
                            row["LastPurchasePrice"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["LastPurchasePrice"]),
                            row["TurnInPriceInTickets"] == DBNull.Value ? 0 : Convert.ToInt32(row["TurnInPriceInTickets"]),
                            row["ExpiryType"].ToString(),
                            row["IssuingApproach"] == DBNull.Value ? "None" : row["IssuingApproach"].ToString(),
                            row["ExpiryDays"] == DBNull.Value ? 0 : Convert.ToInt32(row["ExpiryDays"]),
                            row["ItemMarkupPercent"] == DBNull.Value ? double.NaN : Convert.ToDouble(row["ItemMarkupPercent"]),
                            row["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["CreatedBy"]),
                            row["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["LastupdatedBy"]),
                            row["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]),
                            row["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["LastupdatedDate"])
                            );
            return product;
        }

        private InventoryProduct GetInventoryProductWithStore(DataRow row)
        {
            InventoryProduct product = new InventoryProduct(
                            Convert.ToInt32(row["ProductId"]),
                            row["Code"].ToString(),
                            row["ProductName"].ToString(),
                            row["Description"].ToString(),
                            row["Remarks"].ToString(),
                            row["BarCode"].ToString(),
                            row["CategoryId"] == DBNull.Value ? -1 : Convert.ToInt32(row["CategoryId"]),
                            row["UomId"] == DBNull.Value ? -1 : Convert.ToInt32(row["UomId"]),
                            row["DefaultVendorId"] == DBNull.Value ? -1 : Convert.ToInt32(row["DefaultVendorId"]),
                            row["DefaultLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(row["DefaultLocationId"]),
                            row["TaxId"] == DBNull.Value ? -1 : Convert.ToInt32(row["TaxId"]),
                            row["OutboundLocationId"] == DBNull.Value ? -1 : Convert.ToInt32(row["OutboundLocationId"]),
                            row["ReorderPoint"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ReorderPoint"]),
                            row["ReorderQuantity"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["ReorderQuantity"]),
                            row["PriceInTickets"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["PriceInTickets"]),
                            row["MasterPackQty"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["MasterPackQty"]),
                            row["TaxInclusiveCost"] == DBNull.Value ? false : Convert.ToBoolean(row["TaxInclusiveCost"].ToString()),
                            row["IsPurchaseable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsPurchaseable"].ToString()),
                            row["IsSellable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsSellable"]),
                            row["LotControlled"] == DBNull.Value ? false : Convert.ToBoolean(row["LotControlled"]),
                            row["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(row["IsActive"]),
                            row["IsRedeemable"] == DBNull.Value ? false : Convert.ToBoolean(row["IsRedeemable"].ToString()),
                            row["MarketListItem"] == DBNull.Value ? false : Convert.ToBoolean(row["MarketListItem"]),
                            row["InnerPackQty"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["InnerPackQty"]),
                            row["LowerLimitCost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["LowerLimitCost"]),
                            row["CostVariancePercentage"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["CostVariancePercentage"]),
                            row["SalePrice"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["SalePrice"]),
                            row["Cost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["Cost"]),
                            row["UpperLimitCost"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["UpperLimitCost"]),
                            row["LastPurchasePrice"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["LastPurchasePrice"]),
                            row["TurnInPriceInTickets"] == DBNull.Value ? 0 : Convert.ToInt32(row["TurnInPriceInTickets"]),
                            row["ExpiryType"].ToString(),
                            row["IssuingApproach"] == DBNull.Value ? "None" : row["IssuingApproach"].ToString(),
                            row["ExpiryDays"] == DBNull.Value ? 0 : Convert.ToInt32(row["ExpiryDays"]),
                            row["ItemMarkupPercent"] == DBNull.Value ? double.NaN : Convert.ToDouble(row["ItemMarkupPercent"]),
                            row["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["CreatedBy"]),
                            row["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(row["LastupdatedBy"]),
                            row["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]),
                            row["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["LastupdatedDate"]),
                            row["BarCode1"].ToString()
                            );
            product.Avail_Quantity = row["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(row["Quantity"]);
            product.AllocatedQuantity = row["AllocatedQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(row["AllocatedQuantity"]);
            product.StoreLocationId = row["StoreLocationId"] == DBNull.Value ? 0 : Convert.ToInt32(row["StoreLocationId"]);
            product.StoreRemarks = row["StoreRemarks"] == DBNull.Value ? string.Empty : Convert.ToString(row["StoreRemarks"]);
            return product;
        }



        public List<InventoryProduct> GetInventoryProductList(List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from InventoryProduct";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryProduct.SearchByProductParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.IS_ACTIVE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_NAME) || searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_CODE))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " like '%" + searchParameter.Value+"%'");
                        }
                        else if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_ID))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " =" + searchParameter.Value );
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

            DataTable locationTypeData = conn.executeSelectScript(selectLocationQuery, null);
            if (locationTypeData.Rows.Count > 0)
            {
                List<InventoryProduct> pList = new List<InventoryProduct>();
                foreach (DataRow locationDataRow in locationTypeData.Rows)
                {
                    InventoryProduct locationDataObject = GetInventoryProduct(locationDataRow);
                    pList.Add(locationDataObject);
                }
                return pList;
            }
            else
            {
                return null;
            }
        }


        public List<InventoryProduct> GetInventoryProductListWithStoreData(List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select p.*,s.Quantity,s.AllocatedQuantity,s.LocationId StoreLocationId ,s.Remarks 'StoreRemarks',
                                        (select top 1 BarCode from InventoryProductBarcode  b where b.IsActive=1) BarCode1
                                        from InventoryProduct p
                                        inner join  InventoryStore s on s.ProductId=p.ProductId
                                        ";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<InventoryProduct.SearchByProductParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.IS_ACTIVE))
                        {
                            query.Append(joiner +"p."+ DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_NAME) || searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_CODE)  ||
                            searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.DESCRIPTION))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " like '%" + searchParameter.Value + "%'");
                        }
                        else if (searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.PRODUCT_ID) ||
                            searchParameter.Key.Equals(InventoryProduct.SearchByProductParameters.DEFAULT_LOCATION))
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " =" + searchParameter.Value);
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

            DataTable dt = conn.executeSelectScript(selectLocationQuery, null);
            if (dt.Rows.Count > 0)
            {
                List<InventoryProduct> pList = new List<InventoryProduct>();
                foreach (DataRow row in dt.Rows)
                {
                    InventoryProduct locationDataObject = GetInventoryProductWithStore(row);
                    pList.Add(locationDataObject);
                }
                return pList;
            }
            else
            {
                return null;
            }
        }
    }
}

