using Marbale.Business;
using Marbale.BusinessObject.Cards;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarbaleManagementStudio.Controllers
{
    public class CardsController : Controller
    {
        public CardsBL cardBussiness;
        //
        // GET: /Card/

        #region AddViewCards
        public CardsController()
        {
            cardBussiness = new CardsBL();
        }

        [HttpGet]
        public ActionResult Cards()
        {
            var data = cardBussiness.gettechcardtype();
            Session["TechCardType"] = data;
            //var products = cardBussiness.GetProducts();
            //Session["CategoryList"] = products[0].CategoryList;
            return View();
        }

         [HttpGet]
         public ActionResult ViewCards(CardsModel c)
         {
             var data1 = cardBussiness.gettechcardtype();
             Session["TechCardType"] = data1;
             if ( c.VIPCustomer == false && c.TechnicianCard == false)
             {
                 c.VIPCustomer = false;
                 c.TechnicianCard = false;
                 c.CardNumber = "";
                 c.Custemer = "";
                 c.IssueDate = DateTime.Now;
                 c.ToDate = DateTime.Now;
             } 
             List<CardsModel> data = cardBussiness.GetAllCards(c);
             ViewBag.cardsDetails = data;
             return View();
         }

    public ActionResult Cards(int CardId)
    {
        var data = cardBussiness.gettechcardtype();
        Session["TechCardType"] = data;
        CardsModel card = cardBussiness.getCardById(CardId);
        return View(card);
    }
    public ActionResult InsertOrUpdateCards(CardsModel product)
         {
             try
             {
                 int result= cardBussiness.InsertOrUpdateCards(product);
             }
             catch (Exception e)
             {
                 throw e;
             }
             return RedirectToAction("ViewCards", "Cards");
         }
        #endregion
    #region DeleteCard
    public JsonResult DeleteCard(int Id)
    {
        int i = cardBussiness.DeleteCardById(Id);
        return Json(i,JsonRequestBehavior.AllowGet);
    }

#endregion
    #region Inventory

    public ActionResult Inventory()
         {
           Inventory m = new Marbale.BusinessObject.Cards.Inventory();
              List<Inventory>data = cardBussiness.GetInventory(m);
              if (data.Count > 0)
              {
                  ViewBag.TotalNumberOfCards = data[0].TotalNumberOfCards;
              }
              else
              {
                  ViewBag.TotalNumberOfCards = 0;
              }
              return View();
         }
         public int AddDeleteInventory(Inventory inventory)
         {
         int NoOfCards=    cardBussiness.AddDeleteInventory(inventory);
         return NoOfCards;
         }
         public ActionResult GetInventory(Inventory myObject)
         {
             List<Inventory> inventory = cardBussiness.GetInventory(myObject);
             return Json(inventory, JsonRequestBehavior.AllowGet);
         }

        #endregion
    }
}
