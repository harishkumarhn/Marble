using Marbale.BusinessObject.Game;
using Marble.Business;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{

    public class GameController : Controller
    {
        public GameBL gameBussiness;
        public GameController()
        {
            gameBussiness = new GameBL();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hubs()
        {
            var hubs = gameBussiness.GetHubs();
            ViewBag.hubDetails = hubs;
            return View();
        }
        public int UpdateHubs(List<Hub> hubs)
        {
            var result = 0;
            foreach (var hub in hubs)
            {
                result = gameBussiness.InsertOrUpdateHub(hub);
            }
            return result;
        }

    }
}
