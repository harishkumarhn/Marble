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
    [AuthorizationFilter]
    public class DiscountController : Controller
    {
        ProductBL productBLObject = new ProductBL();
        //
        // GET: /Discount/

        public ActionResult Index()
        {
           MasterDiscounts datatable= productBLObject.GetAllDiscounts();
            return View("Discount", datatable);
        }

        public ActionResult SaveDiscount(TransactionDiscount data)
        {
            int s = productBLObject.SaveDiscount(data);
           // return View();
           return Json(1, JsonRequestBehavior.AllowGet);
         
           
        }

    }
}
