using Marble.WebReports.Models.Service;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Marble.WebReports.ReportPages
{
    public partial class CustomReport : System.Web.UI.Page
    {
        public string ReportName { get; set; }
        public string ReportTitle { get; set; }
        public string Reportkey { get; set; }

        CommonService commonService = new CommonService();
        DBWebConnection dBConnection = new DBWebConnection();

        CardService cardService = new CardService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                DateTime from = DateTime.Now.AddDays(-10) ;
                DateTime to = DateTime.Now;
                txtFromDate.Text = from.ToString("MM/dd/yyyy");
                txtToDate.Text = to.ToString("MM/dd/yyyy");
                ReportBinding(from,   to);
            }
            string reportkey = Request.Params["Report"] == null ? "" : Request.Params["Report"].ToString();

            HttpContext.Current.Session["ReportKey"] = "reportkey";

        }

        private void ReportBinding(DateTime from, DateTime to)
        {
            try
            {
                string reportkey = Request.Params["Report"].ToString();
                Reportkey = reportkey;
                DataTable dtreport = commonService.GetCustomQuery(reportkey);


                if (dtreport == null || dtreport.Rows.Count == 0)
                {
                    //No report alert
                }
                else
                {
                    this.ReportName = dtreport.Rows[0]["ReportKey"].ToString();
                    this.ReportTitle = dtreport.Rows[0]["ReportName"].ToString();
                    //DataTable dt = cardService.GetCards();
                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dt);

                    if(dtreport.Rows[0]["DBQuery"].ToString()!="")
                    {
                        List<SqlParameter> sqlParameterlist = new List<SqlParameter>();
                        sqlParameterlist.Add(new SqlParameter("@dateFrom", from.ToString("yyyy-MM-dd")));
                        sqlParameterlist.Add(new SqlParameter("@dateTo", to.ToString("yyyy-MM-dd")));

                        DataTable searchdt = dBConnection.executeSelectScript(dtreport.Rows[0]["DBQuery"].ToString(), sqlParameterlist.ToArray());
                        DataSet dsbind = new DataSet();
                        if (searchdt != null && searchdt.Rows.Count > 0)
                        {
                            dsbind.Tables.Add(searchdt.Copy());
                            DataBind(ref dsbind);
                        }

                        else
                        {
                            //No record
                            ClientScript.RegisterStartupScript(this.GetType(), "JSScript", "<script> alert('No Data') </script>");
                        }
                    }
                    else
                    {
                        //No record
                        ClientScript.RegisterStartupScript(this.GetType(), "JSScript", "<script> alert('No Data') </script>");
                    }



                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", "<script> alert('ERROR') </script>");
            }
            
           


        }



        
        /// <summary>
        /// Bind Report With DataSet
        /// </summary>
        /// <param name="ds">DataSet</param>
        public void DataBind(ref DataSet ds)
        {

            int count = 0;
            foreach (DataTable dt in ds.Tables)
            {
                count++;
                var report_name = "Report" + count;
                DataTable dt1 = new DataTable(report_name.ToString());
                dt1 = ds.Tables[count - 1];
                dt1.TableName = report_name.ToString();
            }


            //Report Viewer, Builder and Engine 
            ReportViewer1.Reset();
            for (int i = 0; i < ds.Tables.Count; i++)
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(ds.Tables[i].TableName, ds.Tables[i]));

            ReportBuilder reportBuilder = new ReportBuilder();
            reportBuilder.DataSource = ds;

            reportBuilder.Page = new ReportPage();
            ReportSections reportFooter = new ReportSections();
            ReportItems reportFooterItems = new ReportItems();
            ReportTextBoxControl[] footerTxt = new ReportTextBoxControl[3];
            //string footer = string.Format("Copyright {0}         Report Generated On {1}          Page {2}", DateTime.Now.Year, DateTime.Now, ReportGlobalParameters.CurrentPageNumber);
            string footer = string.Format("Copyright  {0}         Report Generated On  {1}          Page  {2}  of {3} ", DateTime.Now.Year, DateTime.Now, ReportGlobalParameters.CurrentPageNumber, ReportGlobalParameters.TotalPages);
            footerTxt[0] = new ReportTextBoxControl() { Name = "txtCopyright", ValueOrExpression = new string[] { footer } };



            reportFooterItems.TextBoxControls = footerTxt;
            reportFooter.ReportControlItems = reportFooterItems;
            reportBuilder.Page.ReportFooter = reportFooter;

            ReportSections reportHeader = new ReportSections();
            reportHeader.Size = new ReportScale();
            reportHeader.Size.Height = 0.56849;

            ReportItems reportHeaderItems = new ReportItems();

            ReportTextBoxControl[] headerTxt = new ReportTextBoxControl[1];
            headerTxt[0] = new ReportTextBoxControl() { Name = "txtReportTitle", ValueOrExpression = new string[] { "Report Name: " + ReportTitle } };


            reportHeaderItems.TextBoxControls = headerTxt;
            reportHeader.ReportControlItems = reportHeaderItems;
            reportBuilder.Page.ReportHeader = reportHeader;

            ReportViewer1.LocalReport.LoadReportDefinition(ReportEngine.GenerateReport(reportBuilder));
            ReportViewer1.LocalReport.DisplayName = ReportName;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtFromDate.Text))
            {
            //    ScriptManager.RegisterClientScriptBlock( this.GetType(),"as","<script>alert('Please enter from date')</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", "<script> alert('Please enter from date') </script>");
                return;
            }

            if (string.IsNullOrEmpty(txtToDate.Text))
            {
                //    ScriptManager.RegisterClientScriptBlock( this.GetType(),"as","<script>alert('Please enter from date')</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", "<script> alert('Please enter to date') </script>");
                return;
            }
            DateTime from = txtFromDate.Text.ToDateTime1();
            DateTime to = txtToDate.Text.ToDateTime1();

            ReportBinding(from, to);
        }
    }
}