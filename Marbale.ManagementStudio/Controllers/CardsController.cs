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
    [AuthorizationFilter]
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
        public ActionResult NewCard()
        {
            var data = cardBussiness.gettechcardtype();
            Session["TechCardType"] = data;
            //var products = cardBussiness.GetProducts();
            //Session["CategoryList"] = products[0].CategoryList;
            return View();
        }

        [HttpGet]
        public ActionResult ViewCards(ViewCard cardSearchCriteria)
        {
            bool isSearch = !string.IsNullOrWhiteSpace(Request.QueryString["submit"]);

            if (isSearch)
            {
                List<CardsModel> data = cardBussiness.GetAllCards(cardSearchCriteria);
                cardSearchCriteria.IssueDate = cardSearchCriteria.ToDate = DateTime.Now;
                ViewBag.cardsDetails = data;
                Session["TechCardType"] = Session["TechCardType"] ?? cardBussiness.gettechcardtype();
            }
            else
            {
                cardSearchCriteria.ValidFlag =true;
            }
            return View(cardSearchCriteria);
        }

        public ActionResult Cards(int CardId)
        {
            var data = cardBussiness.gettechcardtype();
            Session["TechCardType"] = data;
            CardsModel card = cardBussiness.getCardById(CardId);
            return View(card);
        }
        public ActionResult InsertOrUpdateCards(CardsModel card)
        {
            try
            {
                int result = cardBussiness.InsertOrUpdateCards(card);
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
            int result = cardBussiness.DeleteCardById(Id,"card");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region Inventory

        public ActionResult Inventory()
        {
            Inventory m = new Marbale.BusinessObject.Cards.Inventory();
            m.User = Session["UserID"].ToString();
            m.From = m.To = DateTime.Now;
            m.RecievedDate = DateTime.Now.ToString();
            List<Inventory> data = cardBussiness.GetInventory(m);
            if (data.Count > 0)
            {
                ViewBag.TotalNumberOfCards = data[0].TotalNumberOfCards;
            }
            else
            {
                ViewBag.TotalNumberOfCards = 0;
            }
            return View(m);
        }
        public int AddDeleteInventory(int NumberOfCards, string ActionName)
        {
            var inventory = new Inventory();
            inventory.NumberOfCards = NumberOfCards;
            inventory.ActionName = ActionName;
            inventory.ActionBy = Session["UserID"].ToString();
            int NoOfCards = cardBussiness.AddDeleteInventory(inventory);
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
