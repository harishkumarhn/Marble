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
            ObservableCollection<Product> list = new ObservableCollection<Product>();
            list.Add(new Product() { Id = 1 });
            return View(list);
        }

        public ActionResult GetProduct(int id)
        {
            var product = new Product();
            return View(product);
        }

        public ActionResult Insert(Product pObject)
        {
            return null;
        }
        public ActionResult Update(Product pObject)
        {
            return null;
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
    }
}
