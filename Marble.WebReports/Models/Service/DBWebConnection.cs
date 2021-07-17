﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Marble.WebReports.Models.Service
{
    public class DBWebConnection
    {
            private SqlDataAdapter myAdapter;
            private SqlConnection conn;
            //RegistryKey objRegistryKey = Registry.LocalMachine;

            /// <constructor>
            /// Initialise Connection
            /// </constructor>
            public DBWebConnection()
            {
                myAdapter = new SqlDataAdapter();
            //conn = new SqlConnection(@"Data Source=ROCK\SQLSERVER;Initial Catalog=MarbleMg;Trusted_Connection=True;");


            string ConStr = ConfigurationManager.ConnectionStrings["DemoCon1"].ConnectionString;
            conn = new SqlConnection(ConStr);
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
                        return dataTable;

                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
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
                    throw e;
                }
                return dataTable;
            }
            /// <method>
            /// Insert sp
            /// </method>
            public int executeInsertQuery(String sp, SqlParameter[] sqlParameter)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.Connection = openConnection();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameter);
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
            /// <method>
            /// insert/Update sp
            /// </method>
            public int executeUpdateQuery(String sp, SqlParameter[] sqlParameter)
            {
                SqlCommand myCommand = new SqlCommand();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.Connection = openConnection();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameter);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

            public DataSet executeSelectdatasetQuery(String sp, SqlParameter[] sqlParameter)
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
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                return ds;
            }

            public DataTable executeSelectScript(String query, SqlParameter[] sqlParameter)
            {

                SqlCommand sqlCommand = new SqlCommand();
                DataTable dataTable = new DataTable();
                dataTable = null;
                DataSet ds = new DataSet();
                try
                {
                    sqlCommand.Connection = openConnection();

                    sqlCommand.CommandText = query;
                    if (sqlParameter != null)
                        sqlCommand.Parameters.AddRange(sqlParameter);
                    //sqlCommand.ExecuteNonQuery();                
                    myAdapter.SelectCommand = sqlCommand;
                    myAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
                catch (SqlException ex)
                {
                    throw;
                }
                finally
                {
                    sqlCommand.Connection.Close();
                }
                return dataTable;
            }
            public int executeUpdateScript(string query, SqlParameter[] sqlParameter)
            {
                SqlCommand updateCommand = new SqlCommand();
                try
                {

                    updateCommand.Connection = openConnection();
                    updateCommand.CommandText = query;
                    updateCommand.Parameters.AddRange(sqlParameter);
                    myAdapter.UpdateCommand = updateCommand;
                    int numberOfRecords = updateCommand.ExecuteNonQuery();

                    return numberOfRecords;
                }
                catch (SqlException ex)
                {
                    throw;
                }
                finally
                {
                    updateCommand.Connection.Close();
                }
            }

            public int executeInsertScript(String query, SqlParameter[] sqlParameter)
            {
                SqlCommand insertCommand = new SqlCommand();
                try
                {
                    insertCommand.Connection = openConnection();
                    insertCommand.CommandText = query;
                    insertCommand.Parameters.AddRange(sqlParameter);
                    myAdapter.InsertCommand = insertCommand;
                    int insertRecordId = (int)insertCommand.ExecuteScalar();
                    return insertRecordId;
                }
                catch (SqlException ex)
                {
                    throw;
                }
                finally
                {
                    insertCommand.Connection.Close();
                }
            }
        }
    }