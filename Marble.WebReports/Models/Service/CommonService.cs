using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marble.WebReports.Models.Service
{
    public class CommonService
    {
        DBWebConnection dBConnection = new DBWebConnection();

        public DataTable GetReports()
        {
            DataTable dt = null;
            try
            {
                string sql = "select   * from Report where isactive=1";
                SqlParameter[] sqlParameters = { };
                dt = dBConnection.executeSelectScript(sql, sqlParameters);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public List<UIMenu>  GetReportMenuList(string activemenu)
        {
            DataTable dt = null;
            List<UIMenu> menus = new List<UIMenu>();
            List<SubMenu> submenus = new List<SubMenu>();
            try
            {
                
                dt = GetReports();
                if (dt != null && dt.Rows.Count > 0)
                {
                    string currentHeader = "";
                    UIMenu menu = new UIMenu();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        if (currentHeader == "" || currentHeader != dataRow["ReportGroup"].ToString())
                        {
                            if (currentHeader != "")
                            {
                                menu.SubMenuList = submenus;
                                menus.Add(menu);
                                //reset
                                menu = new UIMenu();
                                submenus = new List<SubMenu>();
                                //menus.Add(new Menu(dataRow["ReportGroup"].ToString()));
                            }



                            currentHeader = dataRow["ReportGroup"].ToString();
                            //menus.Add(new Menu(dataRow["ReportGroup"].ToString()));
                            menu = new UIMenu(dataRow["ReportGroup"].ToString());
                            SubMenu s1 = new SubMenu(dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString());

                            if(activemenu== dataRow["ReportKey"].ToString())
                            {
                                s1.SubClassName = s1.SubClassName + " active";
                                menu.ClassName = menu.ClassName + " active";
                            }
                            submenus.Add(s1);
                        }
                        else
                        {
                            //submenus.Add(new SubMenu(dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString()));

                            SubMenu s1 = new SubMenu(dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString());

                            if (activemenu == dataRow["ReportKey"].ToString())
                            {
                                s1.SubClassName = s1.SubClassName + " active";
                                menu.ClassName = menu.ClassName + " active";
                            }
                            submenus.Add(s1);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return menus;
        }
        public DataTable GetCustomQuery(string reportkey)
        {
            DataTable dt = null;
            try
            {
                string sql = "select   * from Report where ReportKey= '" + reportkey + "'";
                SqlParameter[] sqlParameters = { };
                dt = dBConnection.executeSelectScript(sql, sqlParameters);


            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
    }
}