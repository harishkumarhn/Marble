using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Marble.WebReports.Models.Service;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Services;

namespace Marble.WebReports
{
    public partial class WebApp : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }

        [System.Web.Services.WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetAllReports()
        {
            CommonService commonService = new CommonService();
            DataTable dt = commonService.GetCustomReports(true); 
            string jsonString = JsonConvert.SerializeObject(dt);
            return jsonString;
        }

        [System.Web.Services.WebMethod]
     
        public static string GetAllReports1()
        {
            CommonService commonService = new CommonService();
            DataTable dt = commonService.GetCustomReports(true);
            //string jsonString = JsonConvert.SerializeObject(dt);
           

            //convert to list with array of values for each row
            var list1 = dt.AsEnumerable().Select(r => r.ItemArray.ToList()).ToList();
            string jsonString = JsonConvert.SerializeObject(list1);
            return jsonString;

        }

        [System.Web.Services.WebMethod]
        public static string HelloWorld1()
        {
            return "Hello " ;
        }

        [System.Web.Services.WebMethod]
        public static ResultStatus SaveReport(string jsonData)
        {
            Report report = JsonConvert.DeserializeObject<Report>(jsonData);
            CommonService commonService = new CommonService();
            ResultStatus resultStatus = commonService.SaveReports(report);
           // return resultStatus;
            return resultStatus;
        }

        [System.Web.Services.WebMethod]
        public static string EditReport(string id)
        {
            CommonService commonService = new CommonService();
            Report report = commonService.GetReport(Convert.ToInt32(id));
            string jsonString = JsonConvert.SerializeObject(report);
            //ResultStatus resultStatus = new ResultStatus(0, "Test");
            // return resultStatus;
            return jsonString;
        }
    }
}