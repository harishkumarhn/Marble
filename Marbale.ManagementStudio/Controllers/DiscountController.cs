using MarbaleManagementStudio.Models;
using System.Web.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marbale.Business;
using Marble.Business.ViewModels;

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

            //inventoryList.Add(new Discounts { DiscountID = "P101", DiscountName = "Computer", LastUpdatedDate = "All type of computers", MinimumSaleAmount = 800,CouponMendatory=true });
            //inventoryList.Add(new Discounts { DiscountId = "P102", DiscountName = "Laptop", LastUpdatedDate = "All models of Laptops", MinimumSaleAmount = 500 });
            //inventoryList.Add(new Discounts { DiscountId = "P103", DiscountName = "Camera", LastUpdatedDate = "Hd  cameras", MinimumSaleAmount = 300 });
            //inventoryList.Add(new Discounts { DiscountId = "P104", DiscountName = "Mobile", LastUpdatedDate = "All Smartphones", MinimumSaleAmount = 450 });
            //inventoryList.Add(new Discounts { DiscountId = "P105", DiscountName = "Notepad", LastUpdatedDate = "All branded of notepads", MinimumSaleAmount = 670 });
            //inventoryList.Add(new Discounts { DiscountId = "P106", DiscountName = "Harddisk", LastUpdatedDate = "All type of Harddisk", MinimumSaleAmount = 1200 });
            //inventoryList.Add(new Discounts { DiscountId = "P107", DiscountName = "PenDrive", LastUpdatedDate = "All type of Pendrive", MinimumSaleAmount = 370 });
            
            //return View(inventoryList);
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
