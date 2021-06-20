using Marbale.Business;
using Marbale.Business.Enum;
using Marbale.BusinessObject;
using Marbale.BusinessObject.Tax;
using MarbaleManagementStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{

    // [LogCustomExceptionFilter]
    [AuthorizationFilter]
    public class ProductController : Controller
    {
        public ProductBL productBl;

        public ProductController()
        {
            productBl = new ProductBL();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductSetup()
        {
            try
            {
                var products = productBl.GetProducts((int)ProductTypeEnum.Card);
                Session["TaxList"] = products[0].TaxList;
                Session["TypeList"] = products[0].TypeList;
                Session["CategoryList"] = products[0].CategoryList;
                Session["DisplayGroupList"] = products[0].DisplayGroupList;
                ViewBag.productDetails = products;
                return View();
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("ProductSetup", e);
                throw;
            }

        }
        public ActionResult NonCardProductSetup()
        {
            try
            {
                var products = productBl.GetProducts((int)ProductTypeEnum.Manual);
                Session["TaxList"] = products[0].TaxList;
                Session["TypeList"] = products[0].TypeList;
                Session["CategoryList"] = products[0].CategoryList;
                Session["DisplayGroupList"] = products[0].DisplayGroupList;
                ViewBag.productDetails = products;
                return View();
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("NonCardProductSetup", e);
                throw;
            }

        }
        [HttpGet]
        public ActionResult NonCardEdit()
        {
            Product a = new Product();
            a.TaxList = Session["TaxList"] as List<TaxSet>;
            a.Active = true;
            return View(a);
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string Name, int Id)
        {
            return Json(IsUserAvailable(Name, Id));
        }

        private bool IsUserAvailable(string ProductName, int Id)
        {
            bool status = true;
            if (Id == 0)
            {
                List<Product> ProList = (List<Product>)Session["ProductList"];
                var result = ProList.Where(x => x.Name.ToLower() == ProductName.ToLower() ? true : false).ToList();
                if (result.Count() >= 1)
                {
                    status = false;
                }
                else
                {
                    status = true;
                }
            }
            return status;
        }
        public ActionResult NonCardEdit(int id = 0)
        {
            try
            {
                var product = productBl.GetProductById(id);
                Session["TypeList"] = product.TypeList;
                product.Active = id == 0 ? true : product.Active;
                product.TaxId = -1;
                return View(product);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("Edit", e);
                throw;
            }
        }

        public ActionResult Edit(int id = 0)
        {
            try
            {
                var product = productBl.GetProductById(id);
                Session["TaxList"] = product.TaxList;
                Session["TypeList"] = product.TypeList;
                Session["CategoryList"] = product.CategoryList;
                Session["DisplayGroupList"] = product.DisplayGroupList;
                product.Active = id == 0 ? true : product.Active;
                return View(product);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("Edit", e);
                throw;
            }
        }
        public ActionResult ClosePopUp()
        {
            return View();
        }
        public JsonResult DeleteProduct(int Id)
        {
            try
            {
                int result = productBl.DeleteProductbyId(Id,"product");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("DeleteProduct", e);
                throw;
            }

        }
        [HttpPost]
        public string InsertOrUpdate(Product pObject, string submit)
        {
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    switch (submit)
                    {
                        case "Save":
                            var result = productBl.InsertOrUpdateProduct(pObject);
                            break;
                        case "Duplicate":
                            pObject.Id = 0;
                            var result1 = productBl.InsertOrUpdateProduct(pObject);
                            break;

                    }
                }
                else
                {
                    message = string.Join(" | ", ModelState.Values
                                  .SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage));
                }
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("InsertOrUpdateProduct", e);
                throw;
            }
            return message;
        }

        public int UpdateProducts(List<Product> products)
        {
            try
            {
                var result = 0;
                foreach (var product in products)
                {
                    result = productBl.InsertOrUpdateProduct(product);
                }
                return result;

            }
            catch (Exception e)
            {
                LogError.Instance.LogException("UpdateProducts", e);
                throw;
            }

        }
        public ActionResult Types()
        {
            try
            {
                var productTypes = productBl.GetProductTypes();
                ViewBag.productTypes = productTypes;
                return View(productTypes);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("UpdateProductType", e);
                throw;
            }

        }

        public int UpdateProductType(List<ProductType> productTypes)
        {
            try
            {
                return productBl.UpdateProductTypes(productTypes);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("UpdateProductType", e);
                throw;
            }

        }
        public ActionResult DeleteDisplayGroup(int Id)
        {
            int a = productBl.DeleteDisplayGroup(Id);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayGroup()
        {
            List<DisplayGroupModel> DispalyGroups = productBl.GetProductDisplayGroup();
            return View(DispalyGroups);
        }
        public int UpdateProductDispalyGroup(List<DisplayGroupModel> model)
        {
            return productBl.UpdateProductDispalyGroup(model);

        }
        public ActionResult Category()
        {
            var categories = productBl.GetProductCategory();
            ViewBag.categories = categories;
            return View();
        }
        public int UpdateProductCategories(List<ProductCategory> categories)
        {
            try
            {
                return productBl.UpdateProductCategory(categories);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("UpdateProductCategories", e);
                throw;
            }

        }
        public JsonResult TaxDetails(Product model)
        {
            //  Product p = new Product();
            if (Session["TaxList"] != null)
            {
                model.TaxList = Session["TaxList"] as List<TaxSet>;
                List<TaxSet> TaxDetails = model.TaxList.Where(a => a.TaxId == model.Id).ToList();
                if (model.TaxInclusive == true)
                {
                    var divider = (TaxDetails[0].TaxPercent / 100) + 1;
                    model.EffectivePrice = (model.Price - (model.FaceValue != null ? model.FaceValue : 0)) / divider;
                    model.FinalPrice = model.Price;
                    model.Taxpercent = TaxDetails[0].TaxPercent;
                }
                else
                {
                    model.EffectivePrice = model.Price;
                    var tempPrice = (model.Price - (model.FaceValue != null ? model.FaceValue : 0));
                    model.FinalPrice = tempPrice + ( tempPrice* (TaxDetails[0].TaxPercent / 100));
                    model.Taxpercent = TaxDetails[0].TaxPercent;
                }
            }
            var result = new
            {
                EffectivePrice = string.Format("{0:F2}", model.EffectivePrice),
                FinalPrice = string.Format("{0:F2}", model.FinalPrice),
                Taxpercent = model.Taxpercent
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
