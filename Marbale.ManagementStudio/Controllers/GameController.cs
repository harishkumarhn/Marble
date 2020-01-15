using Marbale.BusinessObject;
using Marbale.BusinessObject.Game;
using MarbaleManagementStudio.Models;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace MarbaleManagementStudio.Controllers
{
    [AuthorizationFilter]
    public class GameController : Controller
    {
        public GameBL gameBussiness;
        public SiteSetupBL siteSetupBussiness;
        public GameController()
        {
            gameBussiness = new GameBL();
            siteSetupBussiness = new SiteSetupBL();
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
        public ActionResult Machines()
        {
            var machines = gameBussiness.GetMachines();
            ViewBag.machines = machines;
            return View();
        }
        public int UpdateMachines(List<Machine> machines)
        {
            var result = 0;
            foreach (var machine in machines)
            {
                result = gameBussiness.InsertOrUpdateMachine(machine);
            }
            return result;
        }
        public ActionResult Configuration()
        {
            var configurations = siteSetupBussiness.GetAppSettings("Configuration");
            Configuration conf = new Configuration();

            foreach (var setting in configurations)
            {
                PropertyInfo propertyInfo = conf.GetType().GetProperty(setting.Name);
                if(propertyInfo.PropertyType.Name == "Boolean")
                {
                    setting.Value = string.IsNullOrWhiteSpace(setting.Value) ? "false" : setting.Value;
                    propertyInfo.SetValue(conf, Convert.ChangeType(Convert.ToBoolean(setting.Value), propertyInfo.PropertyType), null);
                }
                else
                {
                propertyInfo.SetValue(conf, Convert.ChangeType(setting.Value, propertyInfo.PropertyType), null);
                }
            }
            return View();
        }
        public bool UpdateConfiguration(Configuration configurations)
        {
            var configurationList = new List<AppSetting>();
            foreach (PropertyInfo propertyInfo in configurations.GetType().GetProperties())
            {
                var setting = new AppSetting();
                if (propertyInfo.CanRead)
                {
                    setting.Name = propertyInfo.Name;
                    setting.Value = propertyInfo.GetValue(configurations, null).ToString();
                    setting.ScreenGroup = "Configuration";
                }
                configurationList.Add(setting);
            }
            return siteSetupBussiness.SaveGameConfiguration(configurationList);
        }
    }
}
