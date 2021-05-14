using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingApplication.DAO;
using System.Data;
using ParkingApplication.DTO;

namespace ParkingApplication.Controller
{
    public class ParkingController
    {

        public DataTable GetAllLevel()
        {
            return new ParkingDAO().GetAllLevel();
        }
        public DataTable GetLevelById(int levelid)
        {
            return new ParkingDAO().GetLevelById(levelid);
        }

        public int InsertUpdate(User user, Vehicle veh, Level lev, Space[] space)
        {
            return new ParkingDAO().InsertUpdate(user, veh, lev, space);
        }
        public DataTable GetSpaceByLevel(int Levelid)
        {
            return new ParkingDAO().GetSpaceByLevel(Levelid);
        }

        }
}