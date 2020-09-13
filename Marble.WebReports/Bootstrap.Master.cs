using Marble.WebReports.Models;
using Marble.WebReports.Models.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Marble.WebReports
{
    public partial class Bootstrap : System.Web.UI.MasterPage
    {
        CommonService commonService = new CommonService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadControl();
            string reportkey = Request.Params["Report"] == null ? "" : Request.Params["Report"].ToString();
            string mainMenu = Request.Params["mn"] == null ? "" : Request.Params["mn"].ToString();

            HttpContext.Current.Session["ReportKey"] = "reportkey";
            HttpContext.Current.Session["mainMenu"] = mainMenu;
            //HttpContext.Current.Session["ReportKey"] = "reportkey";

            List<UIMenu> menus = commonService.GetReportMenuList(reportkey);
            rptmenu.DataSource = menus;
            rptmenu.DataBind();
            
        }


        public void LoadControl()
        {

            DataTable reportDt = commonService.GetCustomReports(false);

            if(reportDt !=null &&  reportDt.Rows.Count>0)
            {
                string currentHeader = "";
                HtmlGenericControl tabs = new HtmlGenericControl();
                
                tabs = new HtmlGenericControl("ul");
                tabs.ID = "myTopnav22 ";
                tabs.Attributes.Add("class", "nav navbar-nav side-nav");
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl ianchor = new HtmlGenericControl("a");

                li = new HtmlGenericControl("li");
                ianchor = new HtmlGenericControl("a");
                ianchor.ID ="Ss22";
                ianchor.InnerHtml = "asdasd  <i class='fa fa-bars  pull-right' aria-hidden='true'></i>";
                li.Controls.Add(ianchor);
                tabs.Controls.Add(li);

                foreach (DataRow dataRow in reportDt.Rows)
                { 

                    //|| currentHeader ==dataRow["ReportGroup"].ToString();
                    if (currentHeader == ""  || currentHeader != dataRow["ReportGroup"].ToString())
                    {
                        if(currentHeader!="")
                        {
                           ControlContainer.Controls.Add(tabs);
                        }
                        currentHeader = dataRow["ReportGroup"].ToString();

                        //insert lI

                        li = new HtmlGenericControl("li");
                          ianchor = new HtmlGenericControl("a");

                        li = new HtmlGenericControl("li");
                        ianchor = new HtmlGenericControl("a");
                        ianchor.InnerText = dataRow["ReportGroup"].ToString();
                       
                        li.Controls.Add(ianchor);
                        tabs.Controls.Add(li);
                        ControlContainer.Controls.Add(tabs);

                        tabs = new HtmlGenericControl("ul");
                        tabs.ID = "sub" + dataRow["Id"].ToString();
                        tabs.Attributes.Add("class", "ssss");



                        li = new HtmlGenericControl("li");
                        ianchor = new HtmlGenericControl("a");

                        li = new HtmlGenericControl("li");
                        ianchor = new HtmlGenericControl("a");
                        ianchor.ID = "Home" + dataRow["Id"].ToString(); ;

                        if (Convert.ToBoolean(dataRow["IsCustomReport"]))
                        {
                            ianchor.Attributes.Add("href", "/" + "CustomReport?Report=" + dataRow["ReportKey"].ToString());
                        }
                        else
                        {
                            ianchor.Attributes.Add("href", "/" + dataRow["ReportKey"].ToString());
                        }
                        //ianchor.Attributes.Add("class", "active");
                        ianchor.InnerText = dataRow["ReportName"].ToString();
                        li.Controls.Add(ianchor);
                        tabs.Controls.Add(li);

                    }
                    else
                    {
                          li = new HtmlGenericControl("li");
                          ianchor = new HtmlGenericControl("a");

                        li = new HtmlGenericControl("li");
                        ianchor = new HtmlGenericControl("a");
                        ianchor.ID = "rpLi" + dataRow["Id"].ToString(); ;
                        if (Convert.ToBoolean(dataRow["IsCustomReport"]))
                        {
                            ianchor.Attributes.Add("href", "/" + "CustomReport?Report=" + dataRow["ReportKey"].ToString());
                        }
                        else
                        {
                            ianchor.Attributes.Add("href", "/" + dataRow["ReportKey"].ToString());
                        }
                        ianchor.Attributes.Add("class", "active");
                        ianchor.InnerText = dataRow["ReportName"].ToString();
                        li.Controls.Add(ianchor);
                        tabs.Controls.Add(li);

                    }
                }
                 ControlContainer.Controls.Add(tabs);
            }

            
            

             
             
        }
    }
}