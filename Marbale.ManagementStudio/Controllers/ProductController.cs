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
        public MarbaleBusiness mb;
        public ProductController()
        {
            mb = new MarbaleBusiness();
        }
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSetup()
        {
            ObservableCollection<ProductObject> list = new ObservableCollection<ProductObject>();
            list.Add(new ProductObject() { Id = 1 });
            return View(list);
        }

        public ActionResult GetProduct(int id)
        {
            var product = new ProductObject();
            return View(product);
        }

        public ActionResult Insert(ProductObject pObject)
        {
            return null;
        }
        public ActionResult Update(ProductObject pObject)
        {
            return null;
        }

        public ActionResult Types()
        {
            var productTypes = mb.GetProductTypes();
            return View(productTypes);
        }

        public int UpdateProductType(List<ProductType> productTypes)
        {
            return mb.UpdateProductTypes(productTypes);
        }
    }
}
