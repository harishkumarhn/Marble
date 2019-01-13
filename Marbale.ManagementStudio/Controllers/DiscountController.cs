using System.Web.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marbale.Business;
using Marbale.BusinessObject;

namespace MarbaleManagementStudio.Controllers
{
    public class DiscountController : Controller
    {
        MarbaleBusiness b = new MarbaleBusiness();
        //
        // GET: /Discount/

        public ActionResult Index()
        {
            ObservableCollection<Discounts> inventoryList = new ObservableCollection<Discounts>();
            var datatable = b.GetAllDiscounts();
            return View("Discount", datatable);
        }
      
        public ActionResult SaveDiscount(Discounts data)
        {
            int s = b.SaveDiscount(data);
           // return View();
           return Json(1, JsonRequestBehavior.AllowGet);
         
           
        }

    }
}
