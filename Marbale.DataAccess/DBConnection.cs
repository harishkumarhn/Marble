using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Marbale.DataAccess
{
    public class DBConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public DBConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection("Data Source=HARISH-PC\\SQLEXPRESS;Initial Catalog=Marbale;Trusted_Connection=True;");
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// select data by stored procedure
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DataTable executeSelectQuery(String sp)
        {
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.Connection = openConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    myAdapter.SelectCommand = cmd;
                    myAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
            }
            catch (SqlException e)
            {
                // Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            return dataTable;
        }
        /// <method>
        /// Select with parameter
        /// </method>
        public DataTable executeSelectQuery(String sp, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.Connection = openConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameter);
                    cmd.ExecuteNonQuery();
                    myAdapter.SelectCommand = cmd;
                    myAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
            }
            catch (SqlException e)
            {
                // Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            return dataTable;
        }

        /// <method>
        /// Insert sp
        /// </method>
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }
        /// <method>
        /// insert/Update sp
        /// </method>
        public int executeUpdateQuery(String sp, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            int result = 0;
            try
            {
               using (SqlCommand cmd = new SqlCommand(sp, conn)) {
                    cmd.Connection = openConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameter);
                    result = cmd.ExecuteNonQuery();
                 }
            }
            catch (SqlException e)
            {
               // Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
            }
            return result;
        }
    }
}