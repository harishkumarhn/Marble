using Marbale.Business.Enum;
using Marbale.BusinessObject;

using Marbale.BusinessObject.Tax;
using Marbale.DataAccess;
using Marble.Business.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Marbale.Business
{
    public class ProductBL
    {
        private ProductData productData;
        private CommonData commonData;

       
        public ProductBL()
        {
            productData = new ProductData();
            commonData = new CommonData();
        }
       
        #region products
        public Product GetProductById(int id, int productType = (int)ProductTypeEnum.CardAndManual)
        {   
            try
            {
                Product product = null;
                var typeList = new List<IdValue>();
                var categoryList = new List<IdValue>();
                var TaxList = new List<TaxSet>();
                var DisplayGroupList = new List<IdValue>();
                GetSessionData(typeList, categoryList, TaxList, DisplayGroupList);
                if (productType == (int)ProductTypeEnum.Manual)
                {
                    typeList = typeList.Where(x => x.Value.ToLower() == ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                }
                else
                {
                    typeList = typeList.Where(x => x.Value.ToLower() != ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                }
                typeList.Insert(0, new IdValue() { Id = null, Value = "Select" });

                if (id > 0)
                {
                    var dataTable = productData.GetProductById(id);
                    
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        product = new Product();
                        product.DisplayInPOS = dr.IsNull("DisplayInPOS") ? false : bool.Parse(dr["DisplayInPOS"].ToString());
                        product.Bonus = dr.IsNull("Bonus") ? 0 : decimal.Parse(dr["Bonus"].ToString());
                        product.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                        product.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                        product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                        product.TypeName = dr.IsNull("TypeName") ? "" : dr["TypeName"].ToString();
                        product.Category = dr.IsNull("Category") ? "" : dr["Category"].ToString();
                        product.DisplayGroupId = dr.IsNull("DisplayGroupId") ? 0 : int.Parse(dr["DisplayGroupId"].ToString());
                        product.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                        product.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime().ToString("MMMM dd yyyy HH:mm:ss") : Convert.ToDateTime(dr["LastUpdatedDate"]).ToString("MMMM dd yyyy HH:mm:ss");
                        product.TaxName = dr.IsNull("TaxName") ? "" : dr["TaxName"].ToString();
                        product.AutoGenerateCardNumber = dr.IsNull("AutoGenerateCardNumber") ? false : bool.Parse(dr["AutoGenerateCardNumber"].ToString());
                        product.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                        product.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                        product.EffectivePrice = dr.IsNull("EffectivePrice") ? 0 : Convert.ToDecimal(dr["EffectivePrice"]);
                        product.Price = dr.IsNull("Price") ? 0 : Convert.ToDecimal(dr["Price"]);
                        product.FaceValue = dr.IsNull("FaceValue") ? 0 : Convert.ToDecimal(dr["FaceValue"]);
                        product.FinalPrice = dr.IsNull("FinalPrice") ? 0 : Convert.ToDecimal(dr["FinalPrice"]);
                        product.TaxPercentage = product.Taxpercent = dr.IsNull("TaxPercentage") ? 0 : Convert.ToDecimal(dr["TaxPercentage"]);
                        product.OnlyVIP = dr.IsNull("OnlyVIP") ? false : bool.Parse(dr["OnlyVIP"].ToString());
                        product.TaxInclusive = dr.IsNull("TaxInclusive") ? false : bool.Parse(dr["TaxInclusive"].ToString());
                        product.StartDate = dr["StartDate"].ToString();
                        product.Games = dr.IsNull("Games") ? 0 : Convert.ToDecimal(dr["Games"]);
                        product.Credits = dr.IsNull("Credits") ? 0 : Convert.ToDecimal(dr["Credits"]);
                        product.CardValidFor = dr.IsNull("CardValidFor") ? 0 : Convert.ToInt32(dr["CardValidFor"]);
                        product.ExpiryDate = dr["ExpiryDate"].ToString();
                        product.Courtesy = dr.IsNull("Courtesy") ? 0 : Convert.ToDecimal(dr["Courtesy"]);
                        product.TaxId = dr.IsNull("Taxid") ? 0 : Convert.ToInt32(dr["Taxid"]);
                        product.TicketAllowed = dr.IsNull("TicketAllowed") ? false : bool.Parse(dr["TicketAllowed"].ToString());
                        product.ManagerApprovalRequired = dr.IsNull("ManagerApprovalRequired") ? false : bool.Parse(dr["ManagerApprovalRequired"].ToString());
                        product.Tickets = dr.IsNull("Tickets") ? 0 : Convert.ToInt32(dr["Tickets"]);
                        product.TrxHeaderRemarksMandatory = dr.IsNull("TrxHeaderRemarksMandatory") ? false : bool.Parse(dr["TrxHeaderRemarksMandatory"].ToString());
                        product.TrxLineRemarksMandatory = dr.IsNull("TrxLineRemarksMandatory") ? false : bool.Parse(dr["TrxLineRemarksMandatory"].ToString());
                        product.QuantityPrompt = dr.IsNull("QuantityPrompt") ? false : bool.Parse(dr["QuantityPrompt"].ToString());
                        product.AllowPriceOverride = dr.IsNull("AllowPriceOverride") ? false : bool.Parse(dr["AllowPriceOverride"].ToString());
                        product.Time = dr.IsNull("Time") ? new DateTime() : Convert.ToDateTime(dr["Time"]);
                        product.MinimumQuantity = dr.IsNull("MinimumQuantity") ? 0 : Convert.ToInt32(dr["MinimumQuantity"]);
                        product.DisplayOrder = dr.IsNull("DisplayOrder") ? 0 : Convert.ToInt32(dr["DisplayOrder"]);
                        product.CardExpiryDate = dr["CardExpiryDate"].ToString();
                        product.MaximumQuantity = dr.IsNull("MaximumQuantity") ? 0 : Convert.ToInt32(dr["MaximumQuantity"]);
                        product.HSNSACCode = dr.IsNull("HSNSACCode") ? "" : dr["HSNSACCode"].ToString();
                        product.vipCard = dr.IsNull("vipCard") ? false : bool.Parse(dr["vipCard"].ToString());
                        product.LineRemarksMandatory = dr.IsNull("LineRemarksMandatory") ? false : bool.Parse(dr["LineRemarksMandatory"].ToString());
                        product.InvokeCustomerRegistration = dr.IsNull("InvokeCustomerRegistration") ? false : bool.Parse(dr["InvokeCustomerRegistration"].ToString());
                        product.Discount = dr.IsNull("Discount") ? 0 : Convert.ToInt32(dr["Discount"]);
                        product.InventoryProductCode = dr.IsNull("InventoryProductCode") ? 0 : Convert.ToInt32(dr["InventoryProductCode"]);
                        product.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();

                        product.CategoryList = categoryList;
                        product.TaxList = TaxList;
                        product.DisplayGroupList = DisplayGroupList;
                        product.TypeList = typeList;

                    }
                }
                else
                {
                    product = new Product() { TaxList = TaxList,DisplayGroupList=DisplayGroupList,CategoryList=categoryList,TypeList=typeList};
                }
                return product;
            }
            catch (Exception e)
            {
            
              //  LogError
                throw e;
            }

        }
        public List<Product> GetProducts(int productType = (int)ProductTypeEnum.CardAndManual)
        {
            try
            {
                var typeList = new List<IdValue>();
                var categoryList = new List<IdValue>();
                var TaxList = new List<TaxSet>();
                var DisplayGroupList = new List<IdValue>();

                GetSessionData(typeList, categoryList, TaxList, DisplayGroupList);

                var productDataTable = productData.GetProducts();
                List<Product> products = new List<Product>();
               
                foreach (DataRow dr in productDataTable.Rows)
                {
                    Product product = new Product();
                    product.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    product.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    product.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    product.Category = dr.IsNull("Category") ? "" : dr["Category"].ToString();
                    product.DisplayInPOS = dr.IsNull("DisplayInPOS") ? false : bool.Parse(dr["DisplayInPOS"].ToString());
                    product.DisplayGroupId = dr.IsNull("DisplayGroupId") ? 0 : int.Parse(dr["DisplayGroupId"].ToString());
                    product.AutoGenerateCardNumber = dr.IsNull("AutoGenerateCardNumber") ? false : bool.Parse(dr["AutoGenerateCardNumber"].ToString());
                    product.POSCounter = dr.IsNull("POSCounter") ? "" : dr["POSCounter"].ToString();
                    product.Type = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                    product.EffectivePrice = dr.IsNull("EffectivePrice") ? 0 : Convert.ToDecimal(dr["EffectivePrice"]);
                    product.Price = dr.IsNull("Price") ? 0 : Convert.ToDecimal(dr["Price"]);
                    product.FaceValue = dr.IsNull("FaceValue") ? 0 : Convert.ToDecimal(dr["FaceValue"]);
                    product.FinalPrice = dr.IsNull("FinalPrice") ? 0 : Convert.ToDecimal(dr["FinalPrice"]);
                    product.TaxPercentage = product.Taxpercent = dr.IsNull("TaxPercentage") ? 0 : Convert.ToDecimal(dr["TaxPercentage"]);
                    product.OnlyVIP = dr.IsNull("OnlyVIP") ? false : bool.Parse(dr["OnlyVIP"].ToString());
                    product.TaxInclusive = dr.IsNull("TaxInclusive") ? false : bool.Parse(dr["TaxInclusive"].ToString());
                    product.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    product.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime().ToString("MMMM dd yyyy HH:mm:ss") : Convert.ToDateTime(dr["LastUpdatedDate"]).ToString("MMMM dd yyyy HH:mm:ss");
                    product.TaxName = dr.IsNull("TaxId") ? "" : dr["TaxId"].ToString();
                    product.TypeName = dr.IsNull("TypeName") ? "" : dr["TypeName"].ToString();
                    product.Credits = dr.IsNull("Credits") ? 0 : Convert.ToDecimal(dr["Credits"]);
                    product.CardValidFor = dr.IsNull("CardValidFor") ? 0 : Convert.ToInt32(dr["CardValidFor"]);                    
                    product.Courtesy = dr.IsNull("Courtesy") ? 0 : Convert.ToDecimal(dr["Courtesy"]);
                    product.Bonus = dr.IsNull("Bonus") ? 0 : decimal.Parse(dr["Bonus"].ToString());
                    product.Time = dr.IsNull("Time") ? new DateTime() : Convert.ToDateTime(dr["Time"]);
                    product.TaxId = dr.IsNull("TaxId") ? 0 : Convert.ToInt32(dr["TaxId"].ToString());
                    product.TicketAllowed = dr.IsNull("TicketAllowed") ? false : bool.Parse(dr["TicketAllowed"].ToString());
                    product.ManagerApprovalRequired = dr.IsNull("ManagerApprovalRequired") ? false : bool.Parse(dr["ManagerApprovalRequired"].ToString());
                    product.Tickets = dr.IsNull("Tickets") ? 0 : Convert.ToInt32(dr["Tickets"]);
                    product.TrxHeaderRemarksMandatory = dr.IsNull("TrxHeaderRemarksMandatory") ? false : bool.Parse(dr["TrxHeaderRemarksMandatory"].ToString());
                    product.TrxLineRemarksMandatory = dr.IsNull("TrxLineRemarksMandatory") ? false : bool.Parse(dr["TrxLineRemarksMandatory"].ToString());
                    product.QuantityPrompt = dr.IsNull("QuantityPrompt") ? false : bool.Parse(dr["QuantityPrompt"].ToString());
                    product.AllowPriceOverride = dr.IsNull("AllowPriceOverride") ? false : bool.Parse(dr["AllowPriceOverride"].ToString());
                    product.MinimumQuantity = dr.IsNull("MinimumQuantity") ? 0 : Convert.ToInt32(dr["MinimumQuantity"]);
                    product.DisplayOrder = dr.IsNull("DisplayOrder") ? 0 : Convert.ToInt32(dr["DisplayOrder"]);
                    product.CardExpiryDate = dr.IsNull("CardExpiryDate") ? null : dr["CardExpiryDate"].ToString();
                    product.MaximumQuantity = dr.IsNull("MaximumQuantity") ? 0 : Convert.ToInt32(dr["MaximumQuantity"]);
                    product.HSNSACCode = dr.IsNull("HSNSACCode") ? "" : dr["HSNSACCode"].ToString();
                    product.vipCard = dr.IsNull("vipCard") ? false : bool.Parse(dr["vipCard"].ToString());
                    product.LineRemarksMandatory = dr.IsNull("LineRemarksMandatory") ? false : bool.Parse(dr["LineRemarksMandatory"].ToString());
                    product.InvokeCustomerRegistration = dr.IsNull("InvokeCustomerRegistration") ? false : bool.Parse(dr["InvokeCustomerRegistration"].ToString());
                    product.Discount = dr.IsNull("Discount") ? 0 : Convert.ToInt32(dr["Discount"]);
                    product.InventoryProductCode = dr.IsNull("InventoryProductCode") ? 0 : Convert.ToInt32(dr["InventoryProductCode"]);
                    product.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                    product.StartDate = dr["StartDate"].ToString();
                    product.ExpiryDate = dr["ExpiryDate"].ToString();

                    product.CategoryList = categoryList;
                    product.TaxList = TaxList;
                    product.DisplayGroupList = DisplayGroupList;
                    if (productType == (int)ProductTypeEnum.Card && product.TypeName.ToLower() != ProductTypeEnum.Manual.ToString().ToLower())
                    {
                        product.TypeList = typeList.Where(x => x.Value.ToLower() != ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                        product.TypeList.Insert(0,new IdValue() { Id = null, Value = "Select" });
                        products.Add(product);
                    }
                    else if ((int)ProductTypeEnum.Manual == productType && product.TypeName.ToLower() == ProductTypeEnum.Manual.ToString().ToLower())
                    {
                        product.TypeList = typeList.Where(x => x.Value.ToLower() == ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                        product.TypeList.Insert(0, new IdValue() { Id = null, Value = "Select" });
                        products.Add(product);
                    }
                }
                //products = productType == (int)ProductTypeEnum.Manual ? products.Where(x => x.TypeName.ToLower() == ProductTypeEnum.Manual.ToString().ToLower()).ToList() :
                //    products.Where(x => x.TypeName.ToLower() != ProductTypeEnum.Manual.ToString().ToLower()).ToList();

                if (products.Count == 0)
                {
                    var defaultTypeList = new List<IdValue>();
                    if (productType == (int)ProductTypeEnum.Card)
                    {
                        var cardTypes = typeList.Where(x => x.Value.ToLower() != ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                        defaultTypeList.AddRange(cardTypes);
                    }
                    else if ((int)ProductTypeEnum.Manual == productType)
                    {
                        var manualTypes = typeList.Where(x => x.Value.ToLower() == ProductTypeEnum.Manual.ToString().ToLower()).ToList();
                        defaultTypeList.AddRange(manualTypes);
                    }
                    defaultTypeList.Insert(0, new IdValue() { Id = null, Value = "Select" });

                    var p = new Product() 
                    {
                        TypeList = defaultTypeList, 
                        CategoryList = categoryList,
                        TaxList=TaxList,
                        DisplayGroupList = DisplayGroupList,
                        Type = productType.ToString()
                    };
                    products.Add(p);
                }
                return products;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GetSessionData(List<IdValue> typeList, List<IdValue> categoryList, List<TaxSet> TaxList, List<IdValue> DisplayGroupList)
        {

            var typeListDataTable = productData.GetActiveProductTypes();
            foreach (DataRow dr in typeListDataTable.Rows)
            {
                IdValue idValues = new IdValue();
                idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.Value = dr.IsNull("Type") ? "" : dr["Type"].ToString();
                typeList.Add(idValues);
            }

            var catrgoryListDataTable = productData.GetProductCategoryLookUp();
            categoryList.Add(new IdValue() { Id = null, Value = "Select" });
            foreach (DataRow dr in catrgoryListDataTable.Rows)
            {
                IdValue idValues = new IdValue();
                idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.Value = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                categoryList.Add(idValues);
            }
            var TaxListDataTable = productData.GetProductTaxLookUp();
            TaxList.Add(new TaxSet() { Id = null, Value = "Select" });
            foreach (DataRow dr in TaxListDataTable.Rows)
            {
                TaxSet idValues = new TaxSet();
                idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.TaxId = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.Value = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                idValues.TaxPercent = dr.IsNull("TaxPercent") ? 0 : decimal.Parse(dr["TaxPercent"].ToString());
                TaxList.Add(idValues);
            }

            var DisplayGroupDataTable = commonData.GetListItems((int)ListItemGroup.DisplayGroup);
            DisplayGroupList.Add(new IdValue() { Id = null, Value = "Select" });
            foreach (DataRow dr in DisplayGroupDataTable.Rows)
            {
                IdValue idValues = new IdValue();
                idValues.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                idValues.Value = dr.IsNull("DisplayGroup") ? "" : dr["DisplayGroup"].ToString();
                DisplayGroupList.Add(idValues);
            }
        }

        public int InsertOrUpdateProduct(Product product)
        {
            try
            {
                return productData.InsertOrUpdateProduct(product);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                    pType.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime().ToString("MMMM dd yyyy HH:mm:ss") : Convert.ToDateTime(dr["LastUpdatedDate"]).ToString("MMMM dd yyyy HH:mm:ss");
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
        public List<DisplayGroupModel> GetProductDisplayGroup()
        {
            try
            {
                List<DisplayGroupModel> listProductGroups = new List<DisplayGroupModel>();

                var dataTable = productData.GetProductDisplayGroup();
                foreach (DataRow dr in dataTable.Rows)
                {
                    DisplayGroupModel display = new DisplayGroupModel();
                    display.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    display.DisplayGroup = dr.IsNull("DisplayGroup") ? "" : (dr["DisplayGroup"].ToString());
                    display.Description = dr.IsNull("Description") ? "" : dr["Description"].ToString();
                    display.SortOrder = dr.IsNull("SortOrder") ? 0 : int.Parse(dr["SortOrder"].ToString());
                    display.LastUpdatedBy = dr.IsNull("LastUpdatedBy") ? "" : dr["LastUpdatedBy"].ToString();
                    display.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? "": Convert.ToDateTime((dr["LastUpdatedDate"])).ToString("MMMM dd yyyy HH:mm:ss");

                    listProductGroups.Add(display);
                }
                return listProductGroups;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int DeleteDisplayGroup(int Id)
        {
            try
            {
                return productData.DeleteDisplayGroup(Id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdateProductDispalyGroup(List<DisplayGroupModel> model)
        {
            try
            {
                return productData.UpdateProductDispalyGroup(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ProductCategory> GetProductCategory()
        {
            try
            {
                var ctys = new List<IdValue>();
                ctys.Add(new IdValue() { Id = 0, Value = "Select" });
                var dataTable = productData.GetProductCategory();
                List<ProductCategory> listProductCat = new List<ProductCategory>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    ProductCategory pCat = new ProductCategory();
                    pCat.Active = dr.IsNull("Active") ? false : bool.Parse(dr["Active"].ToString());
                    pCat.Id = dr.IsNull("Id") ? 0 : int.Parse(dr["Id"].ToString());
                    pCat.Name = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                    pCat.ParentCategory = dr.IsNull("ParentCategory") ? "" : (dr["ParentCategory"].ToString());
                    listProductCat.Add(pCat);
                }
                if (listProductCat.Count != 0)
                {
                    foreach (var cty in listProductCat)
                    {
                        ctys.Add(new IdValue() { Id = cty.Id, Value = cty.Name });
                    }
                }
                else
                {
                    listProductCat.Add(new ProductCategory());
                }
                foreach (var cty in listProductCat)
                {
                    cty.Categories = ctys;
                }
                return listProductCat;
            }

            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateProductCategory(List<ProductCategory> categories)
        {
            try
            {
                return productData.UpdateProductCategory(categories);
            }
            catch (Exception)
            {

                throw;
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
            catch(Exception e1)
            {
            }
            MasterDiscounts masterdiscount = new MasterDiscounts();
            foreach (DataRow dr in transactiondiscount.Rows)
            {

                TransactionDiscount discount = new TransactionDiscount();
                discount.DiscountID = dr.IsNull("discount_id") ? 0 : int.Parse(dr["discount_id"].ToString());
                discount.DiscountName = dr.IsNull("discount_name") ? "" : (dr["discount_name"].ToString());
                discount.DiscountPercentage = dr.IsNull("discount_percentage") ? 0 : decimal.Parse(dr["discount_percentage"].ToString());
                discount.DiscountType = dr.IsNull("discount_type") ? "" : (dr["discount_type"].ToString());
                discount.RemarkMendatory = dr.IsNull("RemarksMandatory") ? false : bool.Parse(dr["RemarksMandatory"].ToString());
                discount.ActiveFlag = dr.IsNull("active_flag") ? false : bool.Parse(dr["active_flag"].ToString());
                discount.AutomaticApply = dr.IsNull("automatic_apply") ? false : bool.Parse(dr["automatic_apply"].ToString());
                discount.CouponMendatory = dr.IsNull("CouponMandatory") ? false : bool.Parse(dr["CouponMandatory"].ToString());
                discount.DiscountAmount = dr.IsNull("DiscountAmount") ? 0 : float.Parse(dr["DiscountAmount"].ToString());
                discount.MinimumSaleAmount = dr.IsNull("minimum_sale_amount") ? 0 : int.Parse(dr["minimum_sale_amount"].ToString());
                discount.MinimumUsedCredits = dr.IsNull("minimum_credits") ? 0 : int.Parse(dr["minimum_credits"].ToString());
                discount.DisplayInPOS = dr.IsNull("display_in_POS") ? false : bool.Parse(dr["display_in_POS"].ToString());
                discount.ManagerApproval = dr.IsNull("manager_approval_required") ? false : bool.Parse(dr["manager_approval_required"].ToString());
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString())).ToString("MMMM dd yyyy HH:mm:ss");
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());
                discount.DisplayOrder = dr.IsNull("sort_order") ? 0 : int.Parse(dr["sort_order"].ToString());
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
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString())).ToString("MMMM dd yyyy HH:mm:ss");
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());
               //discount.DisplayOrder = dr.IsNull("sort_order") ? 0 : int.Parse(dr["sort_order"].ToString());
                masterdiscount.gaamediscount.Add(discount);
            }

            return masterdiscount;
        }

        public TransactionDiscount GetDiscountById(int id)
        {
            try
            {
                var dataTable = productData.GetDiscountById(id);
                TransactionDiscount discount = null;

                //To Do : get only top 1 discount
                //dataTable.Rows[0][0]
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        discount = new TransactionDiscount();
                        discount.DiscountID = dr.IsNull("discount_id") ? 0 : int.Parse(dr["discount_id"].ToString());
                        discount.DiscountName = dr.IsNull("discount_name") ? "" : (dr["discount_name"].ToString());
                        discount.DiscountPercentage = dr.IsNull("discount_percentage") ? 0 : decimal.Parse(dr["discount_percentage"].ToString());
                        discount.DiscountType = dr.IsNull("discount_type") ? "" : (dr["discount_type"].ToString());
                        discount.RemarkMendatory = dr.IsNull("RemarksMandatory") ? false : bool.Parse(dr["RemarksMandatory"].ToString());
                        discount.ActiveFlag = dr.IsNull("active_flag") ? false : bool.Parse(dr["active_flag"].ToString());
                        discount.AutomaticApply = dr.IsNull("automatic_apply") ? false : bool.Parse(dr["automatic_apply"].ToString());
                        discount.CouponMendatory = dr.IsNull("CouponMandatory") ? false : bool.Parse(dr["CouponMandatory"].ToString());
                        discount.DiscountAmount = dr.IsNull("DiscountAmount") ? 0 : float.Parse(dr["DiscountAmount"].ToString());
                        discount.MinimumSaleAmount = dr.IsNull("minimum_sale_amount") ? 0 : int.Parse(dr["minimum_sale_amount"].ToString());
                        discount.MinimumUsedCredits = dr.IsNull("minimum_credits") ? 0 : int.Parse(dr["minimum_credits"].ToString());
                        discount.DisplayInPOS = dr.IsNull("display_in_POS") ? false : bool.Parse(dr["display_in_POS"].ToString());
                        discount.ManagerApproval = dr.IsNull("manager_approval_required") ? false : bool.Parse(dr["manager_approval_required"].ToString());
                        discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString())).ToString("MMMM dd yyyy HH:mm:ss");
                        discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());
                        discount.DisplayOrder = dr.IsNull("sort_order") ? 0 : int.Parse(dr["sort_order"].ToString());
                        break;
                    }
                }

                if (discount == null)
                    discount = new TransactionDiscount();
                return discount;
            }
            catch (Exception e)
            {

                //  LogError
                throw e;
            }

        }

        public int SaveDiscount(TransactionDiscount discount)
        {
            int status = productData.SaveDiscount(discount.ActiveFlag, discount.AutomaticApply, discount.CouponMendatory, discount.DiscountAmount, discount.DiscountID, discount.DiscountName, discount.DiscountPercentage, discount.DiscountType, discount.DisplayInPOS, discount.DisplayOrder, Convert.ToDateTime(discount.LastUpdatedDate), discount.LastUpdatedUser, discount.ManagerApproval, discount.MinimumSaleAmount, discount.MinimumUsedCredits, discount.RemarkMendatory, discount.Type);
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
                discount.LastUpdatedDate = Convert.ToDateTime(dr.IsNull("last_updated_date") ? "01/01/2019" : (dr["last_updated_date"].ToString())).ToString("MMMM dd yyyy HH:mm:ss");
                discount.LastUpdatedUser = dr.IsNull("last_updated_user") ? "" : (dr["last_updated_user"].ToString());

                GameDiscountList.Add(discount);
            }
            return GameDiscountList;

        }
        #endregion


        public MasterTax GetAllTaxes()
        {
            DataTable Taxset = productData.GetTaxSet();
            DataTable TaxStructure = productData.GetTaxStructure();
            MasterTax taxlist = new MasterTax();
            List<TaxSet> taxsetlist = new List<TaxSet>();
            List<TaxStructure> taxstructurelist = new List<TaxStructure>();

            foreach (DataRow dr in Taxset.Rows)
            {
                TaxSet tmodel = new TaxSet();
                tmodel.TaxId = dr.IsNull("TaxId") ? 0 : int.Parse(dr["TaxId"].ToString());
                tmodel.TaxName = dr.IsNull("TaxName") ? "" : (dr["TaxName"].ToString());
                tmodel.TaxPercent = dr.IsNull("TaxPercent") ? 0 : decimal.Parse(dr["TaxPercent"].ToString());
                tmodel.ActiveFlag = dr.IsNull("ActiveFlag") ? false : bool.Parse(dr["ActiveFlag"].ToString());
                taxlist.Taxset.Add(tmodel);
            }

            foreach (DataRow dr in TaxStructure.Rows)
            {
                TaxStructure tsmodel = new TaxStructure();
                tsmodel.TaxId = dr.IsNull("TaxId") ? 0 : int.Parse(dr["TaxId"].ToString());
                tsmodel.TaxStructureId = dr.IsNull("TaxStructureId") ? 0 : int.Parse(dr["TaxStructureId"].ToString());
                tsmodel.TaxStructureName = dr.IsNull("TaxStructureName") ? "" : (dr["TaxStructureName"].ToString());
                tsmodel.TaxStructurePercentage = dr.IsNull("TaxStructurePercentage") ? 0 : decimal.Parse(dr["TaxStructurePercentage"].ToString());
                taxlist.Taxstructure.Add(tsmodel);
            }
            return taxlist;
        }

        public int InsertUpdateTax(TaxSet taxmaster)
        {
            try
            {
                return productData.InsertUpdateTax(taxmaster);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertUpdateTax(TaxStructure taxstructure)
        {
            try
            {
                return productData.InsertUpdateTax(taxstructure);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int DeleteProductbyId(int Id,string from)
        {
            try
            {
                return commonData.DeleteById(Id,from);
            }
            catch (Exception e)
            {
             //   LogError.Instance.LogException("DeleteProductbyId", e);
               throw e;
            }
        }

        public void LoadTicketBonusToCards(int cardId, int tickets, int bonus, string user)
        {
            try
            {
                productData.LoadTicketBonusToCards(cardId, tickets, bonus, user);
            }
            catch (Exception e)
            {
                //   LogError.Instance.LogException("DeleteProductbyId", e);
                throw e;
            }
        }
    }
}
