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

namespace Marbale.DataAccess.Data.Inventory
{
    public class CategoryData
    {
        private DBConnection conn;

        public CategoryData()
        {
            conn = new DBConnection();
        }

        public DataTable GetCategory()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetCategory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateCategroy(Category category,string userid)
        {
            try
            {
                if (category.CategoryId < 0)
                {
                    int id = InsertCategory(category, userid);
                    return id;
                }
                else
                {
                    int id = UpdateCategory(category, userid);
                    return id;
                }
                }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int InsertCategory(Category  category, string userId )
        {
            string query = @"INSERT INTO dbo.Category
                                           (CategoryName
                                           ,IsActive
                                           ,CreatedBy
                                           ,CreatedDate
                                            )
                                     VALUES
                                           (@CategoryName
                                           ,@IsActive
                                           ,@CreatedBy
                                           ,getdate()
                                         
                                           )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
           
            if (string.IsNullOrEmpty(category.CategoryName))
            {
                sqParameters.Add(new SqlParameter("@CategoryName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CategoryName", category.CategoryName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean( category.IsActive)));
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));
            
            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateCategory(Category category, string userId)
        {
                            string query = @"UPDATE dbo.Category
                            SET CategoryName = @CategoryName
                            ,IsActive =@IsActive
                            ,LastupdatedBy = @LastupdatedBy
                            ,LastupdatedDate =getdate()
                            WHERE CategoryId =@CategoryId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@categoryId", category.CategoryId));
            if (string.IsNullOrEmpty(category.CategoryName))
            {
                sqParameters.Add(new SqlParameter("@CategoryName", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@CategoryName", category.CategoryName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(category.IsActive)));
            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            
            return rowsUpdated;
        }
    }
}
