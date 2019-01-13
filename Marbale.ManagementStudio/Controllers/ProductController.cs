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
            ObservableCollection<ProductObject> list = new ObservableCollection<ProductObject>();
            list.Add(new ProductObject() { Id = 1 });
            return View("ProductSetup",list);
        }

    }
}
