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
        public ActionResult Profiles()
        {
            var gameProfiles = gameBussiness.GetGameProfiles();
            ViewBag.gameProfiles = gameProfiles;
            return View();
        }
        public int UpdateProfiles(List<GameProfile> gameProfiles)
        {
            var result = 0;
            foreach (var gameProfile in gameProfiles)
            {
                result = gameBussiness.InsertOrUpdateGameProfile(gameProfile);
            }
            return result;
        }
        public ActionResult Games()
        {
            var games = gameBussiness.GetGames();
            ViewBag.games = games;
            return View();
        }
        public int UpdateGames(List<Game> games)
        {
            var result = 0;
            foreach (var game in games)
            {
                result = gameBussiness.InsertOrUpdateGame(game);
            }
            return result;
        }
    }
}
