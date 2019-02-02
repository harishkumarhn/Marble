using Marbale.BusinessObject;
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

        public DataTable GetSettings()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetSettings");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetAppSettings(string screen)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@screen", screen);
                return conn.executeSelectQuery("sp_GetAppSettings", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateSettings(int id, string name, string caption,string description, string defaultvalue,
            string type, string screenGroup,string updatedby, bool active, bool userLevel, bool posLevel)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[11];
                sqlParameters[0] = new SqlParameter("@id", id);
                sqlParameters[1] = new SqlParameter("@name", name);
                sqlParameters[2] = new SqlParameter("@description", description);
                sqlParameters[3] = new SqlParameter("@defaultvalue", defaultvalue);
                sqlParameters[4] = new SqlParameter("@type", type);
                sqlParameters[5] = new SqlParameter("@screengroup", screenGroup);
                sqlParameters[6] = new SqlParameter("@active", active);
                sqlParameters[7] = new SqlParameter("@userlevel", userLevel);
                sqlParameters[8] = new SqlParameter("@poslevel", posLevel);
                sqlParameters[9] = new SqlParameter("@updatedby", updatedby);
                sqlParameters[10] = new SqlParameter("@caption", caption);
                return conn.executeUpdateQuery("sp_UpdateSettings", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveAppSettings(string name, string value, string screen)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@name", name);
                sqlParameters[1] = new SqlParameter("@value", value);
                sqlParameters[2] = new SqlParameter("@screen", screen);
                return conn.executeUpdateQuery("sp_InsertOrUpdateAppSetting", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

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
        public int InsertOrUpdateProduct(Product product)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[16];
                sqlParameters[0] = new SqlParameter("@name", product.Name);
                sqlParameters[1] = new SqlParameter("@type", product.Type);
                sqlParameters[2] = new SqlParameter("@active", product.Active);
                sqlParameters[3] = new SqlParameter("@price", product.Price);
                sqlParameters[4] = new SqlParameter("@effectivePrice", product.EffectivePrice);
                sqlParameters[5] = new SqlParameter("@finalPrice", product.FinalPrice);
                sqlParameters[6] = new SqlParameter("@faceValue", product.FaceValue);
                sqlParameters[7] = new SqlParameter("@displayGroup", product.DisplayGroup);
                sqlParameters[8] = new SqlParameter("@displayInPOS", product.DisplayInPOS);
                sqlParameters[9] = new SqlParameter("@autoGenerateCardNumber", product.AutoGenerateCardNumber);
                sqlParameters[10] = new SqlParameter("@category", product.Category);
                sqlParameters[11] = new SqlParameter("@onlyVIP", product.OnlyVIP);
                sqlParameters[12] = new SqlParameter("@posCounter", product.POSCounter);
                sqlParameters[13] = new SqlParameter("@taxInclusive", product.TaxInclusive);
                sqlParameters[14] = new SqlParameter("@taxPercentage", product.TaxPercentage);
                sqlParameters[15] = new SqlParameter("@id", product.Id);


                return conn.executeUpdateQuery("sp_InsertOrUpdateProduct", sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public int SaveDiscount(bool ActiveFlag, bool AutomaticApply, bool CouponMendatory, float DiscountAmount, int DiscountID, string DiscountName, int DiscountPercentage, string DiscountType, bool DisplayInPOS, int DisplayOrder, DateTime LastUpdatedDate, string LastUpdatedUser, bool ManagerApproval, float MinimumSaleAmount, float MinimumUsedCredits, bool RemarkMendatory,bool Type)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[16];
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
                sqlParameters[15] = new SqlParameter("@Type", Type);


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
        public int SaveProductCategory(Category cat)
        {
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@id", cat.Id);
            sqlParameters[1] = new SqlParameter("@Name", cat.Name);
            sqlParameters[2] = new SqlParameter("@Active", cat.Active);
            sqlParameters[3] = new SqlParameter("@ParentCategory", cat.ParentCategory);
            return conn.executeUpdateQuery("sp_UpdateOrInsertProductCategory", sqlParameters); 
        }
        
        
    }
}
