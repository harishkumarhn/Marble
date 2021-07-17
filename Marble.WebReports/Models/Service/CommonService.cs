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

        public DataTable GetCustomReports(bool isall)
        {
            DataTable dt = null;
            try
            {
                string sql = "select   * from Report where isactive=1 and  IsCustomReport=1";
                if (!isall)
                {
                    sql = "select   * from Report ";
                }

                SqlParameter[] sqlParameters = { };
                dt = dBConnection.executeSelectScript(sql, sqlParameters);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public Report GetReport(int id)
        {
            DataTable dt = null;
            Report report = new Report();
            try
            {
                string sql = "select   * from Report where Id=" + id;
                SqlParameter[] sqlParameters = { };
                dt = dBConnection.executeSelectScript(sql, sqlParameters);
                if (dt != null && dt.Rows.Count == 1)
                {
                    report.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    report.IsCustomReport = Convert.ToBoolean(dt.Rows[0]["IsCustomReport"].ToString());
                    report.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                    report.OutputFormat = dt.Rows[0]["OutputFormat"].ToString();
                    report.ReportGroup = dt.Rows[0]["ReportGroup"].ToString();
                    report.ReportKey = dt.Rows[0]["ReportKey"].ToString();
                    report.ReportName = dt.Rows[0]["ReportName"].ToString();
                    report.DBQuery = dt.Rows[0]["DBQuery"].ToString();

                }
            }
            catch (Exception ex)
            {
            }
            return report;
        }

        public ResultStatus SaveReports(Report report)
        {
            ResultStatus resultStatus = new ResultStatus(0, "Failed to save");
            if (report.Id > 0)
            {
                resultStatus = UpdateReports(report);
            }
            else
            {
                report.IsCustomReport = true;
                report.ReportKey = report.ReportName.Replace(" ", "");
                resultStatus = InsertReports(report);
            }
            return resultStatus;
        }
        private ResultStatus InsertReports(Report report)
        {
            ResultStatus resultStatus = new ResultStatus(0, "Failed to save");
            //DataTable dt = null;
            try
            {
                string sql = @"INSERT INTO  Report
                                (ReportName
                                ,ReportKey
                                ,IsCustomReport
                                ,OutputFormat
                                ,DBQuery
                                ,ReportGroup
                                ,IsActive)
                                VALUES
                                (@ReportName
                                ,@ReportKey 
                                ,@IsCustomReport  
                                ,@OutputFormat 
                                ,@DBQuery 
                                ,@ReportGroup 
                                ,@IsActive  )SELECT CAST(scope_identity() AS int)";
                List<SqlParameter> sqParameters = new List<SqlParameter>();

                //sqParameters.Add(new SqlParameter("@Id", report.Id));
                sqParameters.Add(new SqlParameter("@ReportName", report.ReportName));

                sqParameters.Add(new SqlParameter("@IsCustomReport", Convert.ToBoolean(report.IsCustomReport)));
                sqParameters.Add(new SqlParameter("@ReportKey", report.ReportKey));



                if (string.IsNullOrEmpty(report.DBQuery))
                {
                    sqParameters.Add(new SqlParameter("@DBQuery", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@DBQuery", report.DBQuery));
                }
                if (string.IsNullOrEmpty(report.ReportGroup))
                {
                    sqParameters.Add(new SqlParameter("@ReportGroup", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@ReportGroup", report.ReportGroup));
                }
                if (string.IsNullOrEmpty(report.OutputFormat))
                {
                    sqParameters.Add(new SqlParameter("@OutputFormat", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@OutputFormat", report.OutputFormat));
                }
                sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(report.IsActive)));

                int i = dBConnection.executeInsertScript(sql, sqParameters.ToArray());
                resultStatus = new ResultStatus(1, "Saved successfully");
            }
            catch (Exception ex)
            {
            }
            return resultStatus;
        }

        private ResultStatus UpdateReports(Report report)
        {
            ResultStatus resultStatus = new ResultStatus(0, "Failed to save");
            DataTable dt = null;
            try
            {
                //-,ReportKey = @ReportKey ,IsCustomReport = @IsCustomReport

                string sql = @"UPDATE  Report
                                SET ReportName = @ReportName
                                 
                                
                                ,OutputFormat = @OutputFormat  
                                ,DBQuery = @DBQuery
                                ,ReportGroup = @ReportGroup
                                ,IsActive = @IsActive  
                                WHERE Id=@Id";
                List<SqlParameter> sqParameters = new List<SqlParameter>();
                sqParameters.Add(new SqlParameter("@Id", report.Id));

                sqParameters.Add(new SqlParameter("@ReportName", report.ReportName));

                //sqParameters.Add(new SqlParameter("@IsCustomReport", Convert.ToBoolean(report.IsCustomReport)));
                //sqParameters.Add(new SqlParameter("@ReportKey", report.ReportKey));



                if (string.IsNullOrEmpty(report.DBQuery))
                {
                    sqParameters.Add(new SqlParameter("@DBQuery", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@DBQuery", report.DBQuery));
                }
                if (string.IsNullOrEmpty(report.ReportGroup))
                {
                    sqParameters.Add(new SqlParameter("@ReportGroup", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@ReportGroup", report.ReportGroup));
                }
                if (string.IsNullOrEmpty(report.OutputFormat))
                {
                    sqParameters.Add(new SqlParameter("@OutputFormat", DBNull.Value));
                }
                else
                {
                    sqParameters.Add(new SqlParameter("@OutputFormat", report.OutputFormat));
                }
                sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(report.IsActive)));

                int i = dBConnection.executeUpdateScript(sql, sqParameters.ToArray());
                resultStatus = new ResultStatus(1, "Saved successfully");
            }
            catch (Exception ex)
            {
            }
            return resultStatus;
        }
        public List<UIMenu> GetReportMenuList(string activemenu)
        {
            DataTable dt = null;
            List<UIMenu> menus = new List<UIMenu>();
            List<SubMenu> submenus = new List<SubMenu>();
            try
            {

                dt = GetCustomReports(false);
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
                            SubMenu s1 = new SubMenu(dataRow["ReportGroup"].ToString(), dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString());

                            if (activemenu == dataRow["ReportKey"].ToString())
                            {
                                s1.SubClassName = s1.SubClassName + " active";
                                menu.ClassName = menu.ClassName + " active";
                            }
                            submenus.Add(s1);
                        }
                        else
                        {
                            //submenus.Add(new SubMenu(dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString()));

                            SubMenu s1 = new SubMenu(dataRow["ReportGroup"].ToString(), dataRow["ReportName"].ToString(), Convert.ToBoolean(dataRow["IsCustomReport"].ToString()), dataRow["ReportKey"].ToString());

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