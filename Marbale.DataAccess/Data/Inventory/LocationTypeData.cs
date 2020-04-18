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
    public class LocationTypeData
    {
        private DBConnection conn;
        private static readonly Dictionary<LocationType.SearchByLocationTypeParameters, string> DBSearchParameters = new Dictionary<LocationType.SearchByLocationTypeParameters, string>
               {
                    {LocationType.SearchByLocationTypeParameters.IS_ACTIVE, "isActive"},

    };
        public LocationTypeData()
        {
            conn = new DBConnection();
        }

        public DataTable GetLocationType()
        {
            try
            {
                return conn.executeSelectQuery("sp_GetLocationType");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertOrUpdateLocationType(LocationType locationType, string userid)
        {
            try
            {
                if (locationType.LocationTypeId <= 0)
                {
                    int id = InsertLocationType(locationType, userid);
                    return id;
                }
                else
                {
                    int id = UpdateLocationType(locationType, userid);
                    return id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int InsertLocationType(LocationType locationType, string userId)
        {
            string query = @"INSERT INTO dbo.LocationType
                                            (LocationType
                                            ,isActive
                                            ,Notes
                                            ,CreatedBy
                                            ,CreatedDate
                                            )
                                            VALUES
                                            (@LocationType
                                            ,@isActive
                                            ,@Notes 
                                            ,@CreatedBy 
                                            ,getdate() 
                                           )SELECT CAST(scope_identity() AS int)";
            List<SqlParameter> sqParameters = new List<SqlParameter>();

            if (string.IsNullOrEmpty(locationType.LocationTypeName))
            {
                sqParameters.Add(new SqlParameter("@LocationType", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationType", locationType.LocationTypeName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(locationType.IsActive)));
            if (string.IsNullOrEmpty(locationType.Notes))
            {
                sqParameters.Add(new SqlParameter("@Notes", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Notes", locationType.Notes));
            }
            sqParameters.Add(new SqlParameter("@CreatedBy", userId));

            int idOfRowInserted = conn.executeInsertScript(query, sqParameters.ToArray());
            return idOfRowInserted;
        }

        public int UpdateLocationType(LocationType locationType, string userId)
        {
            string query = @"UPDATE dbo.LocationType
                                SET LocationType = @LocationType 
                                ,isActive = @isActive 
                                ,Notes = @Notes 
                                ,LastupdatedBy = @LastupdatedBy 
                                ,LastupdatedDate = getdate() 
                                WHERE LocationTypeId  =@LocationTypeId
                 ";
            List<SqlParameter> sqParameters = new List<SqlParameter>();
            sqParameters.Add(new SqlParameter("@LocationTypeId", locationType.LocationTypeId));
            if (string.IsNullOrEmpty(locationType.LocationTypeName))
            {
                sqParameters.Add(new SqlParameter("@LocationType", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@LocationType", locationType.LocationTypeName));
            }
            sqParameters.Add(new SqlParameter("@IsActive", Convert.ToBoolean(locationType.IsActive)));
            if (string.IsNullOrEmpty(locationType.Notes))
            {
                sqParameters.Add(new SqlParameter("@Notes", DBNull.Value));
            }
            else
            {
                sqParameters.Add(new SqlParameter("@Notes", locationType.Notes));
            }
            sqParameters.Add(new SqlParameter("@LastupdatedBy", userId));
            int rowsUpdated = conn.executeUpdateScript(query, sqParameters.ToArray());
            return rowsUpdated;
        }


        private LocationType GetLocationType(DataRow locationDataRow)
        {
            LocationType location = new LocationType(
             locationDataRow["LocationType"] == DBNull.Value ? 0: Convert.ToInt32(locationDataRow["LocationTypeId"]),
            locationDataRow["LocationType"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["LocationType"]),
            locationDataRow["Notes"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["Notes"]),
            locationDataRow["CreatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["CreatedBy"]),
            locationDataRow["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(locationDataRow["CreatedDate"]),
            locationDataRow["LastupdatedBy"] == DBNull.Value ? string.Empty : Convert.ToString(locationDataRow["LastupdatedBy"]),
            locationDataRow["LastupdatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(locationDataRow["LastupdatedDate"]),
            locationDataRow["isActive"] == DBNull.Value ? false : Convert.ToBoolean(locationDataRow["isActive"])
            );

            return location;
        }



        public List<LocationType> GetLocationTypeList(List<KeyValuePair<LocationType.SearchByLocationTypeParameters, string>> searchParameters)
        {
            int count = 0;
            string selectLocationQuery = @"select *
                                         from LocationType";
            if (searchParameters != null)
            {
                string joiner = " ";
                StringBuilder query = new StringBuilder(" where ");
                foreach (KeyValuePair<LocationType.SearchByLocationTypeParameters, string> searchParameter in searchParameters)
                {
                    if (DBSearchParameters.ContainsKey(searchParameter.Key))
                    {
                        joiner = (count == 0) ? " " : " and ";
                        if (searchParameter.Key.Equals(LocationType.SearchByLocationTypeParameters.IS_ACTIVE)  )
                        {
                            query.Append(joiner + DBSearchParameters[searchParameter.Key] + " = " + searchParameter.Value);
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
                if (searchParameters.Count > 0)
                    selectLocationQuery = selectLocationQuery + query;
            }

            DataTable locationTypeData = conn.executeSelectScript(selectLocationQuery, null);
            if (locationTypeData.Rows.Count > 0)
            {
                List<LocationType> locationTypeList = new List<LocationType>();
                foreach (DataRow locationDataRow in locationTypeData.Rows)
                {
                    LocationType locationDataObject = GetLocationType(locationDataRow);
                    locationTypeList.Add(locationDataObject);
                }
                return locationTypeList;
            }
            else
            {
                return null;
            }
        }
    }
}
