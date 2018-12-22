using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Marbale.POS
{
  public  class DataConnectionExcess
    {
      internal static DataTable ExecuteReader(CommandType commandType, string commandText, SqlConnection con, SqlParameter[] commandParameters)
      {
          DataTable result = new DataTable();

          // SqlConnection connection = new SqlConnection(con);


          SqlCommand command = new SqlCommand(commandText, con);
          command.CommandType = commandType;

          if ((commandParameters != null) && !(commandParameters.Length == 0))
          {
              command.Parameters.AddRange(commandParameters);
          }

          con.Open();
          SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default);
          command.Parameters.Clear();
          result.Load(reader);
          con.Close();
          reader.Close();
          return result;
          
      }
      
    }
}
