using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ParkingApplication.DTO;

namespace ParkingApplication.DAO
{
    public class ParkingDAO
    {
        SqlConnection con;
        private SqlConnection GetDBConnection()
        {
            con = new SqlConnection("data source=.; database=NayanTrainee; integrated security=SSPI");
            return con;
        }

        public DataTable GetAllLevel()
        {
            DataTable dtLevel = new DataTable();
            
            try
            {
                SqlConnection con = GetDBConnection();
                String myProcedure = "spGetAllLevelInfo";
                SqlCommand cmd = new SqlCommand(myProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;               
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dtLevel.Load(sdr);

            }
            catch (Exception ee)
            {
                ee.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }

            return dtLevel;
        }


        public DataTable GetLevelById(int levelid)
        {
            DataTable dtLevel = new DataTable();
            try
            {
                SqlConnection con = GetDBConnection();
                String myProcedure = "spGetLevelInfoByID  @id";
                SqlCommand cmd = new SqlCommand(myProcedure, con);
                cmd.Parameters.AddWithValue("@id", levelid);
              //  cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dtLevel.Load(sdr);

            }
            catch (Exception ee)
            {
                ee.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }
            return dtLevel;
        }

        public int InsertUpdate(User user, Vehicle veh, Level lev, Space[] space)
        {
            int result = 0;
            #region LEVEL UPDATE
            if (lev != null)
            {
                try
                {
                    con = GetDBConnection();
                    SqlCommand sqlCmd = new SqlCommand("spUpdateLevelInfo", con);
                    //@alot int , @free int, @noof2w int, @noofcar int, @noofbus int , @levelid int
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@noofbus", lev.NoOfBus);
                    sqlCmd.Parameters.AddWithValue("@noofcar", lev.NoOfCars);
                    sqlCmd.Parameters.AddWithValue("@noof2w", lev.TwoWheelerNo);
                    sqlCmd.Parameters.AddWithValue("@free", lev.FreeSpace);
                    sqlCmd.Parameters.AddWithValue("@alot", lev.AlottedSpace);
                    sqlCmd.Parameters.AddWithValue("@levelid", lev.LevelId);
                    con.Open();
                    result = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ee)
                {
                    ee.ToString();
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                result = 0;
            }

            #endregion

            #region Insert User

            if (result!=0 && lev!=null&& user!=null)
            {
                try
                {
                    con = null;
                    con = GetDBConnection();
                    SqlCommand sqlCmd = new SqlCommand("spInsertUser", con);
                    //@name nvarchar(50),@mobno nvarchar(50)
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@name",user.UserName);
                    sqlCmd.Parameters.AddWithValue("@mobno",user.MobileNo);
                    con.Open();
                    result = sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ee)
                {
                    ee.ToString();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                result = 0;
            }

            #endregion

            #region  Vehicle Insert 
            if (result!=0&&user!=null&&lev!=null&& veh!=null)
            {
                try
                {
                    int MaxUser_ID = GetMaxUserId();

                    con = null;
                    con = GetDBConnection();
                    SqlCommand sqlCmd = new SqlCommand("spInsertVehicle", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //@levelid int, @Userid int, @name nvarchar(50),@desc nvarchar(50),@type char
                    sqlCmd.Parameters.AddWithValue("@levelid", veh.VLevelId);
                    //              User ID NEEDED
                    sqlCmd.Parameters.AddWithValue("@Userid", MaxUser_ID);
                    sqlCmd.Parameters.AddWithValue("@name", veh.VehicleName);
                    sqlCmd.Parameters.AddWithValue("@desc", veh.VehicleDesc);
                    sqlCmd.Parameters.AddWithValue("@type", veh.VehicleType);
                    con.Open();
                    result = sqlCmd.ExecuteNonQuery();

                }
                catch (Exception ee)
                {
                    ee.ToString();
                    throw;
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                result = 0;
            }
            #endregion
            #region Insert Space
            if (result!=0&&user!=null&&lev!=null&&veh!=null&&space.Length!=0)
            {
                try
                {
                    int MaxVehID = GetMaxVehId();
                    con = null;
                    con = GetDBConnection();
                    SqlCommand sqlCmd = null;
                    con.Open();
                    for (int i = 0; i < space.Length; i++)
                    {
                         sqlCmd = new SqlCommand("spInsertSpace", con);
                        //@levelid int, @vehid int, @btnid nvarchar(50),@userControlid nvarchar(50)
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@levelid",space[i].LevelId);
                        //              VEHICLE ID NEEDED
                        sqlCmd.Parameters.AddWithValue("@vehid", MaxVehID);
                        sqlCmd.Parameters.AddWithValue("@btnid", space[i].btnId);
                        sqlCmd.Parameters.AddWithValue("@userControlid", space[i].UserContId);
                        
                        result += sqlCmd.ExecuteNonQuery();
                        sqlCmd = null;
                    }

                }
                catch (Exception ee)
                {
                    ee.ToString();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                result = 0;
            }
            if (result==0)
            {
                //Roll Back Code
            }
            #endregion

            return result;
        }

        public int GetMaxUserId()
        {
            int id = 0;
            try
            {
                con = GetDBConnection();
                SqlCommand sqlCmd = new SqlCommand("spGetMaxUserID", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                id = Convert.ToInt32( sqlCmd.ExecuteScalar());
            }
            catch (Exception ee)
            {
                ee.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }

            return id;
        }

        public int GetMaxVehId()
        {
            int id = 0;
            try
            {
                con = GetDBConnection();
                SqlCommand sqlCmd = new SqlCommand("spGetMaxVehicleID", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                id = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ee)
            {
                ee.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }

            return id;
        }

        public DataTable GetSpaceByLevel(int Levelid)
        {
            DataTable dtSpace = new DataTable();
            try
            {
                con = GetDBConnection();
                SqlCommand sqlCmd = new SqlCommand("spGetAllSpaceBylevelId", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@levelid", Levelid);
                con.Open();
                dtSpace.Load(sqlCmd.ExecuteReader());
            }
            catch (Exception ee)
            {
                ee.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }
            return dtSpace;
        }

    }
}