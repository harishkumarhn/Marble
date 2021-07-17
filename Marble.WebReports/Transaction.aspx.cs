using Marble.WebReports;
using Marble.WebReports.Models.Service;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Marble.WebReports
{
    public partial class Transaction : System.Web.UI.Page
    {
        TransactionService transactionService = new TransactionService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime from = DateTime.Now.AddDays(-10);
                DateTime to = DateTime.Now;
                txtFromDate.Text = from.ToString("MM/dd/yyyy");
                txtDate.Text = to.ToString("MM/dd/yyyy");
                loadData();
            }
        }

        public void loadData()
        {
            DateTime? fromDate = txtFromDate.Text.ToDateTime();
            //if (!string.IsNullOrEmpty(txtFromDate.Text))
            //{
            //    fromDate = Convert.ToDateTime(txtFromDate.Text);
            //}
            DateTime? toDate = txtDate.Text.ToDateTime();
            //if (!string.IsNullOrEmpty(txtDate.Text))
            //{
            //    toDate = Convert.ToDateTime(txtDate.Text);
            //}
            DataTable dsemp = transactionService.GetTransactionData(fromDate, toDate);

            //set Processing Mode of Report as Local   
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report   
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RDLC/Transaction.rdlc");
            //creating object of DataSet dsMember and filling the DataSet using SQLDataAdapter   
            ReportDataSource rds = new ReportDataSource("Transaction", dsemp);
            ReportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource   
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //ReportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;


            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }
        //private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        //{
        //    int trxid =Convert.ToInt32( e.Parameters[0].Values[0]);
        //    DataTable trxlineDt = transactionService.GetTransactionLine(trxid);

        //    ReportDataSource rds = new ReportDataSource("TransactionLine", trxlineDt);
        //    e.DataSources.Add(rds);

        //}
        protected void ReportViewer1_Drillthrough(object sender, Microsoft.Reporting.WebForms.DrillthroughEventArgs e)
        {
            string trxid = "";

            LocalReport report = (LocalReport)e.Report;

            //Get all the parameters passed from the main report to the target report.  
            //OriginalParametersToDrillthrough actually returns a Generic list of   
            //type ReportParameter.  
            IList<ReportParameter> list = report.OriginalParametersToDrillthrough;

            //Parse through each parameters to fetch the values passed along with them.  
            foreach (ReportParameter param in list)
            {
                //Since we know the report has only one parameter and it is not a multivalued,   
                //we can directly fetch the first value from the Values array.  
                trxid = param.Values[0].ToString();
            }

            DataTable trxlineDt = transactionService.GetTransactionLine(Convert.ToInt32(trxid));
            //  ReportDataSource rds = new ReportDataSource("TransactionLine", trxlineDt);
            //ReportViewer1.LocalReport.DataSources.Add(rds);
            LocalReport localreport = (LocalReport)e.Report;
            ReportDataSource level1datasource = new ReportDataSource("TransactionLine", trxlineDt);
            localreport.DataSources.Clear();
            localreport.DataSources.Add(level1datasource);
            localreport.Refresh();
            //ReportViewer1.LocalReport.Refresh();
            //ReportViewer1.DataBind();
        }

        protected void bttestdownlad_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;


            DateTime? fromDate = txtFromDate.Text.ToDateTime();
            DateTime? toDate = txtDate.Text.ToDateTime();
            DataTable dsemp = transactionService.GetTransactionData(fromDate, toDate);

            ReportViewer reportViewerPrg = new ReportViewer();
            reportViewerPrg.ProcessingMode = ProcessingMode.Local;
            reportViewerPrg.LocalReport.ReportPath = Server.MapPath("~/RDLC/Transaction.rdlc");
            ReportDataSource rds = new ReportDataSource("Transaction", dsemp);
            reportViewerPrg.LocalReport.DataSources.Clear();
            reportViewerPrg.LocalReport.DataSources.Add(rds);
            reportViewerPrg.LocalReport.Refresh();
            //reportViewerPrg.DataBind();


            //Export the RDLC Report to Byte Array.
            byte[] bytes = reportViewerPrg.LocalReport.Render("Pdf", null, out contentType, out encoding, out extension, out streamIds, out warnings);

            //Download the RDLC Report in Word, Excel, PDF and Image formats.
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}