using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingApplication.DTO
{
    public class Vehicle
    {
        private int Id;
        private char Type;
        private String Name;
        private String Desc;
        private int UserId;
        private int LId;

        public int VLevelId
        {
            get { return LId; }
            set { LId = value; }
        }

        public int VehicleId
        {
            get { return Id; }
            set { Id = value; }
        }
        public int VUserId
        {
            get { return UserId; }
            set { UserId = value; }
        }
        public char VehicleType
        {
            get { return Type; }
            set { Type = value; }
        }
        public String VehicleName
        {
            get { return Name; }
            set { Name = value; }
        }

        public String VehicleDesc
        {
            get { return Desc; }
            set { Desc = value; }
        }

    }
}