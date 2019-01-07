using Marbale.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class DiscountController : Controller
    {
        MarbaleBusiness mb;
        public DiscountController()
        {
            this.mb = new MarbaleBusiness();
        }
        //semnox
        
        // GET: /Discount/

        public ActionResult Index()
        {
            var d = mb.GetAllDiscounts();
           // ViewData["AllDiscounts"] = d; 
            ViewBag.AllDiscounts = d;
            return View("Discount",d);
        }

    }
}
