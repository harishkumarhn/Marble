using Marbale.Business;
using Marbale.BusinessObject;
using MarbaleManagementStudio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
          
          
            var products = productBussiness.GetProducts();
            Session["ProductList"] = products;
            Session["CategoryList"] = products[0].CategoryList;
            Session["TypeList"] = products[0].TypeList;
            ViewBag.productDetails = products;
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            Product a = new Product();
            return View(a);
        }

        public ActionResult Edit(int id)
        {
        //    List<Product> ProductList = Session["ProductList"] as List<Product>;
           // var p = ProductList.Where(s => s.Id == id).FirstOrDefault();
            var product = productBussiness.GetProductById(id);

            return View(product);
        }
        public ActionResult ClosePopUp()
        {
            return View();
        }
        public JsonResult DeleteProducts(int Id)
        {
            int result = productBussiness.DeleteProductbyId(Id);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertOrUpdate(Product pObject,string submit)
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
       
            return RedirectToAction("ProductSetup", "Product");
        }
        public int UpdateProducts(List<Product> products)
        {
            var result = 0;
          
               
                foreach (var product in products)
                {
                    result = productBussiness.InsertOrUpdateProduct(product);
                }

            return result;
        }
        public ActionResult Types()
        {
            var productTypes = productBussiness.GetProductTypes();
            ViewBag.productTypes = productTypes;
            return View(productTypes);
        }

        public int UpdateProductType(List<ProductType> productTypes)
        {
            return productBussiness.UpdateProductTypes(productTypes);
        }
        public ActionResult Category()
        {
            var categories = productBussiness.GetProductCategory();
            ViewBag.categories = categories;
            return View();
        }
        public int UpdateProductCategories(List<ProductCategory> categories)
        {
            return productBussiness.UpdateProductCategory(categories);
        }

    }
}
