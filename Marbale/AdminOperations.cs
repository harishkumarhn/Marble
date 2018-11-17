using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Marbale
{
  public  class AdminOperations
    {
        SqlConnection con;
        SqlCommand cmd;
        public AdminOperations()
        {
        
            con = new SqlConnection();
            con.ConnectionString = @"data source=SRIDHARNAIK-PC\SQLEXPRESS;integrated security=true;database=MARBLE";
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public bool LoginAdmin(string UserEmail,string Password)
        {
            DataTable dtAdmin = new DataTable();
            bool LoginStatus;
              SqlParameter[] sqlParams = new SqlParameter[]
            {
            new SqlParameter("UserEmail", UserEmail),
            new SqlParameter("Password", Password),
            };
              SqlCommand command = new SqlCommand("AdminLogin", con);
                command.CommandType = CommandType.StoredProcedure;

                if ((sqlParams != null) && !(sqlParams.Length == 0))
                {
                    command.Parameters.AddRange(sqlParams);
                }
                con.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default);
                command.Parameters.Clear();
                dtAdmin.Load(reader);
                reader.Close();
                LoginStatus = Convert.ToBoolean(dtAdmin.Rows[0]["LoginStatus"].ToString());
                return LoginStatus;
        }


}
    }

