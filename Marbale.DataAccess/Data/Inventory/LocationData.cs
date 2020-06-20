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
    public class LocationData
    {
        private DBConnection conn;
        private static readonly Dictionary<Location.SearchByLocationParameters, string> DBSearchParameters = new Dictionary<Location.SearchByLocationParameters, string>
               {
                    {Location.SearchByLocationParameters.IS_ACTIVE, "IsActive"},  
                      {Location.SearchByLocationParameters.LOCATION_ID, "LocationId"},


        };
        public LocationData()
        {
            conn = new DBConnection();
        }

        public DataTable GetLocation()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetLocation");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Location> GetLocationList(List<KeyValuePair<Location.SearchByLocationParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @" select * from Location ";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<Location.SearchByLocationParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(Location.SearchByLocationParameters.IS_ACTIVE))
                        {
                           query.Append(joiner + " " + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else if (  searchParameter.Key.Equals(Location.SearchByLocationParameters.LOCATION_ID))
                        {
                            query.Append(joiner + " " + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
                        }
                        else
                        {
                            query.Append(joiner + "Isnull(" + DBSearchParameters[searchParameter.Key] + ",'') = '" + searchParameter.Value + "'");
                        }

                        count++;
                    }
                    else
                    {
                        throw new Exception("The query parameter does not exist " + searchParameter.Key);
                    }
                }
                //query.Append(" Order by LastModDttm, LocationId ASC");
                if (searchParameters.Count > 0)
                    selectLocationQuery = selectLocationQuery + query;
            }
            DataTable data = conn.executeSelectScript(selectLocationQuery, null);
            if (data.Rows.Count > 0)
            {
                List<Location> LocationList = new List<Location>();
                foreach (DataRow row in data.Rows)
                {
                    Location location = GetLocation(row);
                    LocationList.Add(location);
                }
                return LocationList;
            }
            else
            {
                return null;
            }
        }


        public Location GetLocation(DataRow row)
        {
            Location location = new Location();
           

            location.LocationId = row.IsNull("LocationId") ? 0 : int.Parse(row["LocationId"].ToString());
            location.LocationTypeId = row.IsNull("LocationTypeId") ? 0 : int.Parse(row["LocationTypeId"].ToString());
            location.LocationName = row.IsNull("Name") ? "" : row["Name"].ToString();
            location.BarCode = row.IsNull("barCode") ? "" : row["barCode"].ToString();
            location.IsActive = row.IsNull("IsActive") ? false : bool.Parse(row["IsActive"].ToString());
            location.IsAvailableToSell = row.IsNull("IsAvailableToSell") ? false : bool.Parse(row["IsAvailableToSell"].ToString());
            location.IsTurnInLocation = row.IsNull("IsTurnInLocation") ? false : bool.Parse(row["IsTurnInLocation"].ToString());
            location.AllowForMassUpdate = row.IsNull("AllowForMassUpdate") ? false : bool.Parse(row["AllowForMassUpdate"].ToString());
            location.IsActive = row.IsNull("IsActive") ? false : bool.Parse(row["IsActive"].ToString());
            location.IsStore = row.IsNull("IsStore") ? false : bool.Parse(row["IsStore"].ToString());
            location.CreatedBy = row.IsNull("CreatedBy") ? "" : row["CreatedBy"].ToString();
            location.CreatedDate = row.IsNull("CreatedDate") ? new DateTime() : Convert.ToDateTime(row["CreatedDate"]);
            location.LastUpdatedBy = row.IsNull("LastupdatedBy") ? "" : row["LastupdatedBy"].ToString();
            location.LastUpdatedDate = row.IsNull("LastUpdatedDate") ? new DateTime() : Convert.ToDateTime(row["LastUpdatedDate"]);
            location.IsChanged = false;

            return location;
        }

        public int InsertOrUpdateLocation(Location location, string userid)
        {
            try
            {
                if (location.LocationId <= 0 )
                {
                    int id = InsertLocation(location, userid);
                    return id;
                }
                else
                {
                    int id = UpdateLocation(location, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int InsertLocation(Location location, string userId)
        {
            string query = @"INSERT INTO dbo.Location
                                        (Name
                                        ,IsActive
                                        ,IsAvailableToSell
                                        ,barCode
                                        ,IsTurnInLocation
                                        ,IsStore
                                        ,AllowForMassUpdate
                                        ,LocationTypeId
                                        ,CreatedBy
                                        ,CreatedDate
                                        )
                                        VALUES
                                        (@Name
                                        ,@IsActive
                                        ,@IsAvailableToSell
                                        ,@barCode
                                        ,@IsTurnInLocation
                                        ,@IsStore
                                        ,@AllowForMassUpdate
                                        ,@LocationTypeId
                                        ,@CreatedBy
                                        ,getdate()
            
			)SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(location.LocationName))
            {
                sqParameters.Add(new SqlParameter("@Name", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Name", location.LocationName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(location.IsActive)));
            sqParameters.Add(new SqlParameter("@IsAvailableToSell", Convert.ToBoolean(location.IsAvailableToSell)));

            if (string.IsNullOrEmpty(location.BarCode))
            {
                sqParameters.Add(new SqlParameter("@barCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@barCode", location.BarCode));
            }
            sqParameters.Add(new SqlParameter("@IsTurnInLocation", Convert.ToBoolean(location.IsTurnInLocation)));
            sqParameters.Add(new SqlParameter("@IsStore", Convert.ToBoolean(location.IsStore)));
            sqParameters.Add(new SqlParameter("@AllowForMassUpdate", Convert.ToBoolean(location.AllowForMassUpdate)));
            if ( location.LocationTypeId==-1)
            {
                sqParameters.Add(new SqlParameter("@LocationTypeId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationTypeId", location.LocationTypeId));
            }

            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateLocation(Location location, string userId)
        {
            string query = @"UPDATE dbo.Location
                                    SET Name = @Name
                                    ,IsActive =@IsActive  
                                    ,IsAvailableToSell = @IsAvailableToSell 
                                    ,barCode = @barCode
                                    ,IsTurnInLocation = @IsTurnInLocation
                                    ,IsStore = @IsStore
                                    ,AllowForMassUpdate = @AllowForMassUpdate 
                                    ,LocationTypeId = @LocationTypeId
                               
                                    ,LastupdatedBy = @LastupdatedBy
                                    ,LastupdatedDate = getdate() 
                                    WHERE LocationId=@LocationId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@LocationId", location.LocationId));
            if (string.IsNullOrEmpty(location.LocationName))
            {
                sqParameters.Add(new SqlParameter("@Name", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Name", location.LocationName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(location.IsActive)));
            sqParameters.Add(new SqlParameter("@IsAvailableToSell", Convert.ToBoolean(location.IsAvailableToSell)));

            if (string.IsNullOrEmpty(location.BarCode))
            {
                sqParameters.Add(new SqlParameter("@barCode", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@barCode", location.BarCode));
            }
            sqParameters.Add(new SqlParameter("@IsTurnInLocation", Convert.ToBoolean(location.IsTurnInLocation)));
            sqParameters.Add(new SqlParameter("@IsStore", Convert.ToBoolean(location.IsStore)));
            sqParameters.Add(new SqlParameter("@AllowForMassUpdate", Convert.ToBoolean(location.AllowForMassUpdate)));
            if (location.LocationTypeId == -1)
            {
                sqParameters.Add(new SqlParameter("@LocationTypeId", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationTypeId", location.LocationTypeId));
            }

            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());

            return rowsUpdated;
        }
    }
}
