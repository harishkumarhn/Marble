using Marbale.Business;
using Marbale.BusinessObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class ProductController : Controller
    {
        public ProductBusiness productBussiness;
        public ProductController()
        {
            productBussiness = new ProductBusiness();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSetup()
        {
            var products = productBussiness.GetProducts();
            ViewBag.productDetails = products;
            return View();
        }

        public ActionResult GetProduct(int id)
        {
            var product = productBussiness.GetProductById(id);
            return View("Create",product);
        }

        public ActionResult Create(int id)
        {
            var product = productBussiness.GetProductById(id);
            return View(product);
        }

        public int InsertOrUpdate(Product pObject)
        {
            var result = productBussiness.InsertOrUpdateProduct(pObject);
            return result;
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
            return View(productTypes);
        }

        public int UpdateProductType(List<ProductType> productTypes)
        {
            return productBussiness.UpdateProductTypes(productTypes);
        }
        public ActionResult Category()
        {
            List<string> domains = new List<string>();
            domains.Add("DomainA");

            ViewBag.Dropdow = domains.Select(m => new SelectListItem { Text = "hello", Value = "1" });
            var procat = productBussiness.GetProductCategory();
            return View(procat);
        }
        public ActionResult SaveProductCategory(Category data)
        {
            productBussiness.SaveProductCategory(data);
        //  var procat=  productBussiness.GetProductCategory();
         // return View("Category", procat);
             return Json(1, JsonRequestBehavior.AllowGet);
        }

    }
}
