using Marbale.BusinessObject;
using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.Messages;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.DataAccess.Data
{
    public class UnitOfMeasureData
    {
        private DBConnection conn;

        public UnitOfMeasureData()
        {
            conn = new DBConnection();
        }

        public DataTable GetUOM()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetUnitOfMeasure");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertOrUpdateUOM(UnitOfMeasure unitOfMeasure, string userid)
        {
            try
            {
                if (unitOfMeasure.UOMId <=0)
                {
                    int id = InsertUOM(unitOfMeasure, userid);
                    return id;
                }
                else
                {
                    int id = UpdatedUOM(unitOfMeasure, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertUOM(UnitOfMeasure unitOfMeasure, string userId)
        {
            string query = @"INSERT INTO dbo.UnitOfMeasure
                                            (UomName
                                            ,Notes
                                            ,IsActive
                                            ,CreatedBy
                                            ,CreatedDate
                                            )
                                            VALUES
                                            (@UomName 
                                            ,@Notes 
                                            ,@IsActive 
                                            ,@CreatedBy 
                                            ,GETDATE() 
                                            
                                           )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(unitOfMeasure.UomName))
            {
                sqParameters.Add(new SqlParameter("@UomName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@UomName", unitOfMeasure.UomName));
            }

            if (string.IsNullOrEmpty(unitOfMeasure.Notes))
            {
                sqParameters.Add(new SqlParameter("@Notes", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Notes", unitOfMeasure.Notes));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(unitOfMeasure.IsActive)));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdatedUOM(UnitOfMeasure unitOfMeasure, string userId)
        {
            string query = @"UPDATE dbo.UnitOfMeasure
                                SET UomName = @UomName 
                                ,Notes = @Notes 
                                ,IsActive = @IsActive 
                                ,LastupdatedBy = @LastupdatedBy 
                                ,LastupdatedDate = GETDATE() 
                                WHERE UomId =@UomId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@UomId", unitOfMeasure.UOMId));
            if (string.IsNullOrEmpty(unitOfMeasure.UomName))
            {
                sqParameters.Add(new SqlParameter("@UomName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@UomName", unitOfMeasure.UomName));
            }

            if (string.IsNullOrEmpty(unitOfMeasure.Notes))
            {
                sqParameters.Add(new SqlParameter("@Notes", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Notes", unitOfMeasure.Notes));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(unitOfMeasure.IsActive)));
            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }

    }
}
