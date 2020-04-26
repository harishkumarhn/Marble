using Marbale.BusinessObject;
using Marbale.BusinessObject.Tax;
using Marbale.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marbale.DataAccess.Data;
using Marble.Business;
using Marbale.BusinessObject.Inventory;
using Marbale.DataAccess.Data.Inventory;

namespace Marble.Business.InventoryBL
{
    public class UnitOfMeasureBL
    {
        private UnitOfMeasureData Uomdata;

        public UnitOfMeasureBL()
        {
            Uomdata = new UnitOfMeasureData();
        }


        public List<UnitOfMeasure> GetUom()
        {
            DataTable dt = Uomdata.GetUOM();
            List<UnitOfMeasure> lstCategroy = new List<UnitOfMeasure>();
            UnitOfMeasure uom;

            foreach (DataRow dr in dt.Rows)
            {
                uom = new UnitOfMeasure();
                uom.UOMId = dr.IsNull("UomId") ? 0 : int.Parse(dr["UomId"].ToString());
                uom.isActive = dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString());
                uom.UomName = dr.IsNull("UomName") ? "" : dr["UomName"].ToString();
                uom.Notes = dr.IsNull("Notes") ? "" : dr["Notes"].ToString();
                uom.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                uom.CreatedDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                uom.LastUpdatedBy = dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString();
                uom.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                lstCategroy.Add(uom);
            }

            return lstCategroy;
        }


        public int Save(UnitOfMeasure uom, string userId)
        {
            try
            {
                return Uomdata.InsertOrUpdateUOM(uom, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
