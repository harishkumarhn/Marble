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

        public ActionResult CreateProduct()
        {
            var product = new ProductObject();
            return View(product);
        }
    }
}
