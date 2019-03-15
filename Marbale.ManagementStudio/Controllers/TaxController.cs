using Marbale.Business;
using Marbale.BusinessObject.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    public class TaxController : Controller
    {
        //
        // GET: /Tax/
        ProductBL PTax = new ProductBL();
        public ActionResult Index()
        {
          MasterTax TaxList=  PTax.GetAllTaxes();
          Session["TaxStructure"] = TaxList.Taxstructure;
            return View("Tax",TaxList);
        }
        public int InsertUpdateTax( TaxSet taxmaster)
        {
            int status = PTax.InsertUpdateTax(taxmaster);
            return 0;
        }
        public ActionResult GetTaxStructure(int TaxId)
        {
            List<TaxStructure> taxs = Session["TaxStructure"] as List<TaxStructure>;
         taxs = taxs.Where(c => c.TaxId == TaxId).ToList();
         return View("TaxStructure", taxs);
        }
        public int InsertUpdateTaxStructure(TaxStructure taxstructure)
        {
            int status = PTax.InsertUpdateTax(taxstructure);
            return status;
        }

    }
}
