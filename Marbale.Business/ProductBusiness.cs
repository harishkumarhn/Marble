﻿using Marbale.BusinessObject;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.Business
{
    public class ProductBusiness
    {
        private ProductData productData;

        public ProductBusiness()
        {
            productData = new ProductData();
        }
        #region settings
        public List<Settings> GetSettings()
        {
            try
            {
                var dataTable = productData.GetSettings();
                List<Settings> listSettings = new List<Settings>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    Settings setting = new Settings();
                    setting.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    setting.DefaultValue = dr.IsNull("DefaultValue") ? "" : dr["DefaultValue"].ToString();
                    setting.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                    setting.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();
                    setting.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    setting.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    setting.PosLevel = dr.IsNull("PosLevel") ? false : bool.Parse(dr["PosLevel"].ToString());
                    setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();
                    setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    setting.UserLevel = dr.IsNull("UserLevel") ? false : bool.Parse(dr["UserLevel"].ToString());

                    listSettings.Add(setting);
                }
                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<AppSetting> GetAppSettings(string screen)
        {
            try
            {
                var dataTable = productData.GetAppSettings(screen);
                List<AppSetting> listSettings = new List<AppSetting>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    AppSetting setting = new AppSetting();
                    setting.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    setting.Caption = dr.IsNull("Caption") ? "" : dr["Caption"].ToString();
                    setting.Value = dr.IsNull("Value") ? "" : dr["Value"].ToString();
                    setting.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    setting.ScreenGroup = dr.IsNull("ScreenGroup") ? "" : dr["ScreenGroup"].ToString();

                    listSettings.Add(setting);
                }
                return listSettings;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SaveSettings(List<Settings> settings)
        {
            try
            {
                foreach (var setting in settings)
                {
                    productData.UpdateSettings(setting.Id, setting.Name, setting.Caption, setting.Description, setting.DefaultValue, setting.Type,
                        setting.ScreenGroup, setting.LastUpdatedBy, setting.Active, setting.UserLevel, setting.PosLevel);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool SavePOSConfiguration(List<AppSetting> appSetting)
        {
            try
            {
                foreach (var setting in appSetting)
                {
                    productData.SaveAppSettings(setting.Name, setting.Value, setting.ScreenGroup);
                }
                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region products
        public Product GetProduct(int id)
        {
            return null;
        }
        public int AddProduct(Product product)
        {
            try
            {
                return productData.AddProduct(product);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int UpdateProduct(Product product)
        {
            return 0;
        }
        public List<ProductType> GetProductTypes()
        {        
            try
            {
                var dataTable = productData.GetProductTypes();
                List<ProductType> listProductTypes = new List<ProductType>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    ProductType pType = new ProductType();
                    pType.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    pType.CardSale = dr.IsNull("CardSale") ? false : bool.Parse(dr["CardSale"].ToString());
                    pType.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                    pType.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    pType.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    pType.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                    pType.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    pType.ReportGroup = dr.IsNull("ReportGroup") ? "" : dr["ReportGroup"].ToString();

                    listProductTypes.Add(pType);
                }
                return listProductTypes;
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
               return productData.UpdateProductTypes(types);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region discounts
        public MasterDiscounts GetAllDiscounts()
        {

            DataTable transactiondiscount = new DataTable(); ;
            DataTable gamedisc = new DataTable();
            List<GameDiscount> gamediscount = new List<GameDiscount>();
            MasterDiscounts m = new MasterDiscounts();
            DataTable dataTable = productData.GetAllDiscounts();
            try
            {
                 transactiondiscount = dataTable.AsEnumerable()
                                .Where(r => r.Field<string>("discount_type") == "T")
                                .CopyToDataTable();
            }
            catch { }
            try
            {
                 gamedisc = dataTable.AsEnumerable()
                                .Where(r => r.Field<string>("discount_type") != "T")
                                .CopyToDataTable();
            }
            catch { }
            MasterDiscounts masterdiscount = new MasterDiscounts();
            foreach (DataRow dr in transactiondiscount.Rows)
            {
               
                TransactionDiscount discount = new TransactionDiscount();
                discount.DiscountID = dr.IsNull("discount_id") ? 0 : int.Parse(dr["discount_id"].ToString());
                discount.DiscountName = dr.IsNull("discount_name") ? "" : (dr["discount_name"].ToString());
                discount.DiscountPercentage = dr.IsNull("discount_percentage") ? 0 : int.Parse(dr["discount_percentage"].ToString());
                discount.DiscountType = dr.IsNull("discount_type") ? "" : (dr["discount_type"].ToString());
                discount.RemarksMandatory = dr.IsNull("RemarksMandatory") ? false : bool.Parse(dr["RemarksMandatory"].ToString());
                discount.ActiveFlag = dr.IsNull("active_flag") ? false : bool.Parse(dr["active_flag"].ToString());
                discount.AutomaticApply = dr.IsNull("automatic_apply") ? false : bool.Parse(dr["automatic_apply"].ToString());
                discount.CouponMendatory = dr.IsNull("CouponMandatory") ? false : bool.Parse(dr["CouponMandatory"].ToString());
                discount.DiscountAmount = dr.IsNull("DiscountAmount") ? 0 : float.Parse(dr["DiscountAmount"].ToString());
                discount.MinimumSaleAmount = dr.IsNull("minimum_sale_amount") ? 0 : int.Parse(dr["minimum_sale_amount"].ToString());
                discount.MinimumUsedCredits = dr.IsNull("minimum_credits") ? 0 : int.Parse(dr["minimum_credits"].ToString());
                discount.DisplayInPOS = dr.IsNull("display_in_POS") ? false : bool.Parse(dr["display_in_POS"].ToString());
                discount.ManagerApproval = dr.IsNull("manager_approval_required") ? false : bool.Parse(dr["manager_approval_required"].ToString());
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString()));
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());
                masterdiscount.transactiondiscount.Add(discount);
            }
            foreach (DataRow dr in gamedisc.Rows)
            {
              
                GameDiscount discount = new GameDiscount();
                discount.DiscountID = dr.IsNull("discount_id") ? 0 : int.Parse(dr["discount_id"].ToString());
                discount.DiscountName = dr.IsNull("discount_name") ? "" : (dr["discount_name"].ToString());
                discount.DiscountPercentage = dr.IsNull("discount_percentage") ? 0 : int.Parse(dr["discount_percentage"].ToString());
                discount.ActiveFlag = dr.IsNull("active_flag") ? false : bool.Parse(dr["active_flag"].ToString());
                discount.MinimumUsedCredits = dr.IsNull("minimum_credits") ? 0 : int.Parse(dr["minimum_credits"].ToString());
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString()));
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());
                masterdiscount.gaamediscount.Add(discount);
            }

            return masterdiscount;

           
           
        }
        public int SaveDiscount(TransactionDiscount discount)
        {
            int status = productData.SaveDiscount(discount.ActiveFlag, discount.AutomaticApply, discount.CouponMendatory, discount.DiscountAmount, discount.DiscountID, discount.DiscountName, discount.DiscountPercentage, discount.DiscountType, discount.DisplayInPOS, discount.DisplayOrder, discount.LastUpdatedDate, discount.LastUpdatedUser, discount.ManagerApproval, discount.MinimumSaleAmount, discount.MinimumUsedCredits, discount.RemarkMendatory, discount.Type);
            return status;
        }

        public List<GameDiscount> GetAllGameDiscount()
        {
            List<GameDiscount> GameDiscountList = new List<GameDiscount>();
            var dataTable = productData.GetAllGameDiscount();
            foreach (DataRow dr in dataTable.Rows)
            {
                GameDiscount discount = new GameDiscount();
                discount.DiscountID = dr.IsNull("discount_id") ? 0 : int.Parse(dr["discount_id"].ToString());
                discount.DiscountName = dr.IsNull("discount_name") ? "" : (dr["discount_name"].ToString());
                discount.DiscountPercentage = dr.IsNull("discount_percentage") ? 0 : int.Parse(dr["discount_percentage"].ToString());
              
                discount.ActiveFlag = dr.IsNull("active_flag") ? false : bool.Parse(dr["active_flag"].ToString());
                discount.MinimumUsedCredits = dr.IsNull("minimum_credits") ? 0 : int.Parse(dr["minimum_credits"].ToString());
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString()));
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());

                GameDiscountList.Add(discount);
            }
            return GameDiscountList;

        }
        #endregion

        public List<Category> GetProductCategory()
        {
            try
            {
                var dataTable = productData.GetProductCategory();
                List<Category> listProductCat = new List<Category>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    Category pCat = new Category();
                    pCat.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    pCat.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    pCat.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    pCat.ParentCategory = dr.IsNull("ParentCategory") ? "" : (dr["ParentCategory"].ToString());
                    listProductCat.Add(pCat);
                }
                return listProductCat;
            }
                
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public int SaveProductCategory(Category cat)
        {
            try
            {
                return productData.SaveProductCategory(cat);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
