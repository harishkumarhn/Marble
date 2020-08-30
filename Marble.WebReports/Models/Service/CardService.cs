using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marble.WebReports.Models.Service
{
    public class CardService
    {

        DBWebConnection dBConnection = new DBWebConnection();

        public DataTable GetCards()
        {
            DataTable dt = null;
            try
            {
                string sql = "select  CardNumber [Card_Number],IssueDate,FaceValue,RefundFlag,RefundAmount,ValidFlag,TicketCount from Card";
                SqlParameter[] sqlParameters = { };
                dt = dBConnection.executeSelectQuery(sql, sqlParameters);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}