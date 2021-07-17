using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marble.WebReports.Models.Service
{
    public class TransactionService
    {
        DBWebConnection dBWebConnection = new DBWebConnection();

        public DataTable GetTransactionData(DateTime? fromDate, DateTime? toDate)
        {
            DataTable dsemp = null;
            try
            {
                if (fromDate == null || toDate == null)
                {
                    fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
                }
                if (toDate == null)
                {
                    toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 999);
                }
                dsemp = new DataTable();
                //string ConStr = ConfigurationManager.ConnectionStrings["DemoCon1"].ConnectionString;
                //SqlConnection con = new SqlConnection(ConStr);
                //con.Open();
                //SqlDataAdapter adapt = new SqlDataAdapter($"exec Transaction_Report '{fromDate?.ToString("yyyy-MM-dd")}' , '{toDate?.ToString("yyyy-MM-dd")}'", con);
                //adapt.Fill(dsemp);
                //con.Close();
                List<SqlParameter> sqlParameterlist = new List<SqlParameter>();
                sqlParameterlist.Add(new SqlParameter("@trdDateFrom", fromDate?.ToString("yyyy-MM-dd")));
                sqlParameterlist.Add(new SqlParameter("@trdDateTo", toDate?.ToString("yyyy-MM-dd")));
                dsemp=dBWebConnection.executeSelectQuery("Transaction_Report", sqlParameterlist.ToArray());


            }
            catch (Exception ex)
            {

            }

            return dsemp;
        }
        public DataTable GetTransactionLine(int trxid)
        {
            DataTable dsemp = null;
            try
            {

                dsemp = new DataTable();
                string ConStr = ConfigurationManager.ConnectionStrings["DemoCon1"].ConnectionString;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter($"exec TransactionLine_Report {trxid}  ", con);
                adapt.Fill(dsemp);
                con.Close();
            }
            catch (Exception ex)
            {

            }

            return dsemp;
        }


    }
}