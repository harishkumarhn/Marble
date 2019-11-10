using Marbale.BusinessObject;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess
{
    public class ProductData
    {
        private DBConnection conn;

        public ProductData()
        {
            conn = new DBConnection();
        }

        public DataTable GetDefalutCashMode()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetDefalutCash");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int UpdatePOSUserCredential(string Password)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@Password", Password);
                return conn.executeUpdateQuery("sp_InsertOrUpdate_POS_Login", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void ChangePassword(int UserId, string currentPassword, string NewPassword)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@userId", UserId);
                sqlParameters[1] = new SqlParameter("@currentPassword", currentPassword);
                sqlParameters[2] = new SqlParameter("@password", NewPassword);
                conn.executeUpdateQuery("sp_ChangeUserPassword", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable GetAllDiscounts()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetDiscounts");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetDisplayGroup(int dispalyGroupId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@displayGroupId", dispalyGroupId);
                return conn.executeSelectQuery("sp_GetDisplayGroup", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetProducts()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProducts");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetProductsByScreenGroup(int screenGroupId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@displayGroupId", screenGroupId);
                return conn.executeSelectQuery("sp_GetProductsByScreenGroup", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductTypeLookUp()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductTypeLookUp");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetListItemsByGroupId()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductTypeLookUp");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductCategoryLookUp()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductCategoryLookUp");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductById(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@id", id);
                return conn.executeSelectQuery("sp_GetProductById", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetDiscountById(int id)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@id", id);
                return conn.executeSelectQuery("sp_GetDiscountById", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateProduct(Product product)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[28];
                sqlParameters[0] = new SqlParameter("@name", string.IsNullOrEmpty(product.Name) ? "" : product.Name);
                sqlParameters[1] = new SqlParameter("@type", string.IsNullOrEmpty(product.Type) ? "" : product.Type);
                sqlParameters[2] = new SqlParameter("@active", product.Active);
                sqlParameters[3] = new SqlParameter("@price", product.Price);
                sqlParameters[4] = new SqlParameter("@effectivePrice", product.EffectivePrice);
                sqlParameters[5] = new SqlParameter("@finalPrice", product.FinalPrice);
                sqlParameters[6] = new SqlParameter("@faceValue", product.FaceValue);
                sqlParameters[7] = new SqlParameter("@displayGroupId", product.DisplayGroupId);
                sqlParameters[8] = new SqlParameter("@displayInPOS", product.DisplayInPOS);
                sqlParameters[9] = new SqlParameter("@autoGenerateCardNumber", product.AutoGenerateCardNumber);
                sqlParameters[10] = new SqlParameter("@category", string.IsNullOrEmpty(product.Category) ? "" : product.Category);
                sqlParameters[11] = new SqlParameter("@onlyVIP", product.OnlyVIP);
                sqlParameters[12] = new SqlParameter("@posCounter", string.IsNullOrEmpty(product.POSCounter) ? "" : product.POSCounter);
                sqlParameters[13] = new SqlParameter("@taxInclusive", product.TaxInclusive);
                sqlParameters[14] = new SqlParameter("@taxPercentage", product.Taxpercent);
                sqlParameters[15] = new SqlParameter("@id", product.Id);
                sqlParameters[16] = new SqlParameter("@Bonus", product.Bonus);
                sqlParameters[17] = new SqlParameter("@LastUpdatedUser", string.IsNullOrEmpty(product.LastUpdatedUser) ? "" : product.LastUpdatedUser);
                sqlParameters[18] = new SqlParameter("@TaxName", product.TaxName);
                sqlParameters[19] = new SqlParameter("@StartDate", DateTime.Now);
                sqlParameters[20] = new SqlParameter("@LastUpdatedDate", DateTime.Now);
                sqlParameters[21] = new SqlParameter("@Games", product.Games);
                sqlParameters[22] = new SqlParameter("@CreditsPlus", product.CreditsPlus);
                sqlParameters[23] = new SqlParameter("@Credits", product.Credits);
                sqlParameters[24] = new SqlParameter("@CardValidFor", product.CardValidFor);
                sqlParameters[25] = new SqlParameter("@Courtesy", product.Courtesy);
                sqlParameters[26] = new SqlParameter("@ExpiryDate", product.ExpiryDate);
                sqlParameters[27] = new SqlParameter("@taxId", product.TaxId);
                return conn.executeUpdateQuery("sp_InsertOrUpdateProduct", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
        public int SaveDiscount(bool ActiveFlag, bool AutomaticApply, bool CouponMendatory, float DiscountAmount, int DiscountID, string DiscountName, decimal DiscountPercentage, string DiscountType, bool DisplayInPOS, int DisplayOrder, DateTime LastUpdatedDate, string LastUpdatedUser, bool ManagerApproval, float MinimumSaleAmount, float MinimumUsedCredits, bool RemarkMendatory, bool Type)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[17];
                sqlParameters[0] = new SqlParameter("@ActiveFlag", ActiveFlag);
                sqlParameters[1] = new SqlParameter("@AutomaticApply", AutomaticApply);
                sqlParameters[2] = new SqlParameter("@CouponMendatory", CouponMendatory);
                sqlParameters[3] = new SqlParameter("@DiscountAmount", DiscountAmount);
                sqlParameters[4] = new SqlParameter("@DiscountID", DiscountID);
                sqlParameters[5] = new SqlParameter("@DiscountName", DiscountName);
                sqlParameters[6] = new SqlParameter("@DiscountPercentage", DiscountPercentage);
                sqlParameters[7] = new SqlParameter("@DiscountType", DiscountType);
                sqlParameters[8] = new SqlParameter("@DisplayInPOS", DisplayInPOS);
                sqlParameters[9] = new SqlParameter("@DisplayOrder", DisplayOrder);
                sqlParameters[10] = new SqlParameter("@LastUpdatedDate", DateTime.Now);
                sqlParameters[11] = new SqlParameter("@LastUpdatedUser", LastUpdatedUser);
                sqlParameters[12] = new SqlParameter("@ManagerApproval", ManagerApproval);
                sqlParameters[13] = new SqlParameter("@MinimumSaleAmount", MinimumSaleAmount);

                sqlParameters[14] = new SqlParameter("@MinimumUsedCredits", MinimumUsedCredits);
                sqlParameters[15] = new SqlParameter("@RemarkMendatory", RemarkMendatory);
                sqlParameters[16] = new SqlParameter("@Type", Type);


                return conn.executeInsertQuery("sp_Insert_Discount", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductTypes()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductTypes");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductCategory()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductCategory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAllGameDiscount()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetGameDiscounts");
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetProductDisplayGroup()
        {
            try
            {
                return conn.executeSelectQuery("Adminsp_GetDisplayGroup");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdateProductTypes(List<ProductType> types)
        {
            try
            {
                foreach (var type in types)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[7];
                    sqlParameters[0] = new SqlParameter("@id", type.Id);
                    sqlParameters[1] = new SqlParameter("@type", type.Type);
                    sqlParameters[2] = new SqlParameter("@description", type.Description);
                    sqlParameters[3] = new SqlParameter("@reportgroup", type.ReportGroup);
                    sqlParameters[4] = new SqlParameter("@cardsale", type.CardSale);
                    sqlParameters[5] = new SqlParameter("@active", type.Active);
                    sqlParameters[6] = new SqlParameter("@lastupdatedby", type.LastUpdatedBy == null ? "Harish" : type.LastUpdatedBy);
                    conn.executeUpdateQuery("sp_InsertOrUpdateProductType", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int DeleteDisplayGroup(int Id)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@Id", Id);


            return conn.executeInsertQuery("sp_DeleteDisplayGroup", sqlParameters);
        }
        public int UpdateProductDispalyGroup(List<DisplayGroupModel> model)
        {
            try
            {
                foreach (var dispaly in model)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[4];
                    sqlParameters[0] = new SqlParameter("@Id", dispaly.Id);
                    sqlParameters[1] = new SqlParameter("@DisplayGroup", dispaly.DisplayGroup);
                    sqlParameters[2] = new SqlParameter("@Description", dispaly.Description);
                    sqlParameters[3] = new SqlParameter("@SortOrder", dispaly.SortOrder);
                    conn.executeUpdateQuery("sp_InsertOrUpdateDisplayGroup", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int UpdateProductCategory(List<ProductCategory> categories)
        {
            try
            {
                foreach (var cat in categories)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[4];
                    sqlParameters[0] = new SqlParameter("@id", cat.Id);
                    sqlParameters[1] = new SqlParameter("@Name", cat.Name);
                    sqlParameters[2] = new SqlParameter("@Active", cat.Active);
                    sqlParameters[3] = new SqlParameter("@ParentCategory", cat.ParentCategory);
                    conn.executeUpdateQuery("sp_InsertUpdateOrProductCategory", sqlParameters);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }



        public DataTable GetTaxSet()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetTaxSet");
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetTaxStructure()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetTaxStructure");
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertUpdateTax(BusinessObject.Tax.TaxSet taxset)
        {
           
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter("@TaxId", taxset.TaxId);
                sqlParameters[1] = new SqlParameter("@TaxName", taxset.TaxName);
                sqlParameters[2] = new SqlParameter("@TaxPercent", taxset.TaxPercent);
                sqlParameters[3] = new SqlParameter("@ActiveFlag", taxset.ActiveFlag);
             return   conn.executeUpdateQuery("sp_InsertOrUpdateTax", sqlParameters);
            
        }
        public int InsertUpdateTax(BusinessObject.Tax.TaxStructure taxstructure)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@TaxId", taxstructure.TaxId);
            sqlParameters[1] = new SqlParameter("@TaxStructureId", taxstructure.TaxStructureId);
            sqlParameters[2] = new SqlParameter("@TaxStructurePercentage", taxstructure.TaxStructurePercentage);
            sqlParameters[3] = new SqlParameter("@TaxStructureName", taxstructure.TaxStructureName);
            return conn.executeUpdateQuery("sp_InsertOrUpdateTaxStructure", sqlParameters);
        }

        public int DeleteProductbyId(int Id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Id",Id);
            return conn.executeUpdateQuery("sp_DeleteProductById", sqlParameters);
        }

        public DataTable GetProductTaxLookUp()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetProductTaxLookUp");
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public void LoadTicketBonusToCards(int cardId, int tickets, int bonus, string user)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@cardId", cardId);
            sqlParameters[1] = new SqlParameter("@bonus", bonus);
            sqlParameters[2] = new SqlParameter("@ticket", tickets);
            sqlParameters[3] = new SqlParameter("@lastupdatedBy", user);

            conn.executeUpdateQuery("sp_loadTicketBonusTocard", sqlParameters);
        }
    }
}
