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
    public class LocationTypeBL
    {
        private LocationTypeData locationTypeData;

        public LocationTypeBL()
        {
            locationTypeData = new LocationTypeData();
        }


        public List<LocationType> GetlocationType()
        {
            DataTable dt = locationTypeData.GetLocationType();
            List<LocationType> lstLocationType = new List<LocationType>();
            LocationType locationType;

            foreach (DataRow dr in dt.Rows)
            {
                locationType = new LocationType();
                locationType.LocationTypeId = dr.IsNull("LocationTypeId") ?0 : int.Parse(dr["LocationTypeId"].ToString());
                locationType.LocationTypeName = dr.IsNull("LocationType") ? "" : dr["LocationType"].ToString();
                locationType.IsActive = dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString());
                locationType.Notes = dr.IsNull("Notes") ? "" : dr["Notes"].ToString();
                locationType.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                locationType.CreatedDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                locationType.LastUpdatedBy = dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString();
                locationType.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                lstLocationType.Add(locationType);
            }

            return lstLocationType;
        }

        public List<LocationType> GetLocationTypeList(List<KeyValuePair<LocationType.SearchByLocationTypeParameters, string>> searchParameters)
        {
            return locationTypeData.GetLocationTypeList(searchParameters);


        }
        public int Save(LocationType locationType, string userId)
        {
            try
            {
                return locationTypeData.InsertOrUpdateLocationType(locationType, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
