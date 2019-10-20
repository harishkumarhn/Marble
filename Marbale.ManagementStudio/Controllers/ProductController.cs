using Marbale.Business;
using Marbale.Business.Enum;
using Marbale.BusinessObject;

using Marbale.BusinessObject.Tax;
using MarbaleManagementStudio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarbaleManagementStudio.Controllers
{

    // [LogCustomExceptionFilter]
    public class ProductController : Controller
    {
        public ProductBL productBussiness;
        public ProductController()
        {
            productBussiness = new ProductBL();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ProductSetup()
        {
            try
            {
                var products = productBussiness.GetProducts((int)ProductTypeEnum.Card);
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
                var products = productBussiness.GetProducts((int)ProductTypeEnum.Manual);
                Session["TaxList"] = products[0].TaxList;
                Session["TypeList"] = products[0].TypeList;
                Session["CategoryList"] = products[0].CategoryList;
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
            return View(a);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            Product a = new Product();
            a.TaxList = Session["TaxList"] as List<TaxSet>;
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
        public ActionResult NonCardEdit(int id)
        {
            try
            {
                var product = productBussiness.GetProductById(id);
                return View(product);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("Edit", e);
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var product = productBussiness.GetProductById(id);
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
                int result = productBussiness.DeleteProductbyId(Id);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("DeleteProduct", e);
                throw;
            }

        }

        public ActionResult InsertOrUpdate(Product pObject, string submit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    switch (submit)
                    {
                        case "Save":
                            var result = productBussiness.InsertOrUpdateProduct(pObject);
                            break;
                        case "Duplicate":
                            pObject.Id = 0;
                            var result1 = productBussiness.InsertOrUpdateProduct(pObject);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("InsertOrUpdateProduct", e);
                throw;
            }


            return RedirectToAction("ProductSetup", "Product");
        }

        public int UpdateProducts(List<Product> products)
        {
            try
            {
                var result = 0;


                foreach (var product in products)
                {
                    result = productBussiness.InsertOrUpdateProduct(product);
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
                var productTypes = productBussiness.GetProductTypes();
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
                return productBussiness.UpdateProductTypes(productTypes);
            }
            catch (Exception e)
            {
                LogError.Instance.LogException("UpdateProductType", e);
                throw;
            }

        }
        public ActionResult DeleteDisplayGroup(int Id)
        {
            int a = productBussiness.DeleteDisplayGroup(Id);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DisplayGroup()
        {
            List<DisplayGroupModel> DispalyGroups = productBussiness.GetProductDisplayGroup();
           // ViewBag.categories = categories;
            return View(DispalyGroups);
        }
        public int UpdateProductDispalyGroup(List<DisplayGroupModel> model)
        {
          return productBussiness.UpdateProductDispalyGroup(model);
           
        }
        public ActionResult Category()
        {
            var categories = productBussiness.GetProductCategory();
            ViewBag.categories = categories;
            return View();
        }
        public int UpdateProductCategories(List<ProductCategory> categories)
        {
            try
            {
                return productBussiness.UpdateProductCategory(categories);
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
                    model.Price = model.Price - model.FaceValue;
                    model.EffectivePrice = (model.Price * TaxDetails[0].TaxPercent) / (100 + (TaxDetails[0].TaxPercent));
                    model.EffectivePrice = model.Price - model.EffectivePrice;
                    model.FinalPrice = model.Price + model.FaceValue;
                    model.Taxpercent = TaxDetails[0].TaxPercent;
                }
                else
                {
                    model.Price = model.Price - model.FaceValue;
                    model.EffectivePrice = model.Price * (TaxDetails[0].TaxPercent / 100);
                    model.FinalPrice = model.Price + model.EffectivePrice;
                    model.EffectivePrice = model.Price;
                    model.Taxpercent = TaxDetails[0].TaxPercent;
                }
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
