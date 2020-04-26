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
    public class LocationBL
    {
        private LocationData LocationData;

        public LocationBL()
        {
            LocationData = new LocationData();
        }


        public List<Location> GetLocation()
        {
            DataTable dt = LocationData.GetLocation();
            List<Location> lstLocation = new List<Location>();
            Location location;

            foreach (DataRow dr in dt.Rows)
            {
                location = new Location();
                location.LocationId = dr.IsNull("LocationId") ? 0 : int.Parse(dr["LocationId"].ToString());
                location.LocationTypeId = dr.IsNull("LocationTypeId") ? 0 : int.Parse(dr["LocationTypeId"].ToString());
                location.LocationName = dr.IsNull("Name") ? "" : dr["Name"].ToString();
                location.BarCode = dr.IsNull("barCode") ? "" : dr["barCode"].ToString();
                location.IsActive = dr.IsNull("IsActive") ? false : bool.Parse(dr["IsActive"].ToString());
                location.IsAvailableToSell = dr.IsNull("IsAvailableToSell") ? false : bool.Parse(dr["IsAvailableToSell"].ToString());
                location.IsTurnInLocation = dr.IsNull("IsTurnInLocation") ? false : bool.Parse(dr["IsTurnInLocation"].ToString());
                location.AllowForMassUpdate = dr.IsNull("AllowForMassUpdate") ? false : bool.Parse(dr["AllowForMassUpdate"].ToString());
                location.IsActive = dr.IsNull("IsStore") ? false : bool.Parse(dr["IsStore"].ToString());
                location.CreatedBy = dr.IsNull("CreatedBy") ? "" : dr["CreatedBy"].ToString();
                location.CreatedDate = dr.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(dr["CreatedDate"]);
                location.LastUpdatedBy = dr.IsNull("LastupdatedBy") ? "" : dr["LastupdatedBy"].ToString();
                location.LastUpdatedDate = dr.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(dr["LastUpdatedDate"]);
                lstLocation.Add(location);
            }

            return lstLocation;
        }


        public int Save(Location location, string userId)
        {
            try
            {
                return LocationData.InsertOrUpdateLocation(location, userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
