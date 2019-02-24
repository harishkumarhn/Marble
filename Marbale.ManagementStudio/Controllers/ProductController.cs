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
            ViewBag.productDetails = products;
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var product = productBussiness.GetProductById(id);
            return View(product);
        }

        public ActionResult InsertOrUpdate(Product pObject)
        {
            var result = productBussiness.InsertOrUpdateProduct(pObject);
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
