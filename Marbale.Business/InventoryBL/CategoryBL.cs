 
 
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.DataAccess.Data;
using Marble.Business;
using Marbale.DataAccess.Data.Inventory;
using Marbale.BusinessObject.Inventory;

namespace Marble.Business.InventoryBL
{
    public class CategoryBL
    {
        private CategoryData Categorydata;

        public CategoryBL()
        {
            Categorydata = new CategoryData();
        }


        public List<Category> GetCategory()
        {
            DataTable dt = Categorydata.GetCategory();
            List<Category> lstCategroy = new List<Category>();
            Category category;

            foreach (DataRow dr in dt.Rows)
            {
                category = new Category();
                category.CategoryId = dr.IsNull("CategoryId") ? 0 : int.Parse(dr["CategoryId"].ToString());
                category.IsActive = dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString());
                category.CategoryName = dr.IsNull("CategoryName") ? "" : dr["CategoryName"].ToString();
                category.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                category.CreatedDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                category.LastUpdatedBy = dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString();
                category.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                lstCategroy.Add(category);
            }

            return lstCategroy;
        }

        public int Save(Category category ,string userId)
        {
            try
            {
                return Categorydata.InsertOrUpdateCategroy(category, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
