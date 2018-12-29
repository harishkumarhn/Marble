using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Marbale.POS
{
  public  class POSOperations
    {

        SqlConnection con;
        SqlCommand cmd;
        public POSOperations()
        {
        
            con = new SqlConnection();
            con.ConnectionString = @"data source=SRIDHARNAIK-PC\SQLEXPRESS;integrated security=true;database=MARBALE";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
      public IList<POSProperties> IssuedCards()
      {
          IList<POSProperties> AllIssuedCards;
          DataTable dtAdmin = new DataTable();
          dtAdmin = DataConnectionExcess.ExecuteReader(CommandType.StoredProcedure, "GetNewAndIssuedCard", con, null);
          AllIssuedCards = (from DataRow row in dtAdmin.Rows
                            select new POSProperties
                            {
                                CardNumber = (!dtAdmin.Columns.Contains("CardNumber") || row["CardNumber"] == null || row["CardNumber"] == DBNull.Value ? string.Empty : row["CardNumber"].ToString()),
                                IssuedDate = Convert.ToString((!dtAdmin.Columns.Contains("CardNumber") || row["CardNumber"] == null || row["CardNumber"] == DBNull.Value ? string.Empty : row["CardNumber"].ToString()))
                            }).ToList();
          return AllIssuedCards;
      }
      public void InserCardNumber(string CardNumber)
      {
          DataTable dtAdmin = new DataTable();
         // bool LoginStatus = true;
          SqlParameter[] sqlParams = new SqlParameter[]
            {
            new SqlParameter("CardNumber", CardNumber)
            };
          dtAdmin = DataConnectionExcess.ExecuteReader(CommandType.StoredProcedure, "InserCardNumber", con, sqlParams);

      }




      internal DataTable GetCardDetails(string CardNumber)
      {
          DataTable dt = new DataTable();
          SqlParameter[] sqlParams = new SqlParameter[]
            {
            new SqlParameter("CardNumber", CardNumber)
            };
          dt = DataConnectionExcess.ExecuteReader(CommandType.StoredProcedure, "GetCardDetails", con, sqlParams);
          return dt;
      }
    }
}
