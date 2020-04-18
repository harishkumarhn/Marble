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
